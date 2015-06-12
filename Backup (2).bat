@ echo ------ORACLE自动备份开始...  Zhang Junming制作 @2012-----------  
REM ======================================================  
REM 备份服务器  SZYY系统的数据  
REM ======================================================  
  
@ echo off  
  
set BACKUP_DIR=C:\Backup
set BACKUP_WAREHOUSE=%BACKUP_DIR%\DATABACKUP_LOG_DMP
set ORACLE_USERNAME=weboa
set ORACLE_PASSWORD=weboa
set ORACLE_DB=orcl
set IP=192.168.154.138
set RAR_CMD="C:\Program Files\WinRAR\WinRAR.exe"
set delDays=20

rem if not exist "DATABACKUP"             md DATABACKUP
rem if not exist "DATABACKUP\DATABACKUP_LOG_DMP\"  md DATABACKUP\DATABACKUP_LOG_DMP\
if not exist "%BACKUP_WAREHOUSE%\"  md "%BACKUP_WAREHOUSE%\"

for /f "tokens=1,2" %%a in ('date/t') do set TODAY=%%a

REM 如果文件名中需要小时及分钟，用下面第一行语句
REM set BACK_NAME=%ORACLE_DB%_%ORACLE_USERNAME%_%TODAY%(%time:~0,2%时%time:~3,2%分%time:~6,2%秒)
set BACK_NAME=%ORACLE_DB%_%ORACLE_USERNAME%_%TODAY%
REM set BACK_NAME=%ORACLE_DB%_%TODAY%_%time:~0,2%时%time:~3,2%分%time:~6,2%秒
rem set BACK_NAME=%ORACLE_DB%_%TODAY%
set BACK_FULL_NAME=%BACKUP_DIR%\%BACK_NAME%


REM 将操作记入批处理日志 %BACK_FULL_NAME%_bat.log

echo ==================备份服务器 SZYY的数据================= >>%BACK_FULL_NAME%_bat.log
echo 备份开始...... >>%BACK_FULL_NAME%_bat.log
echo 开始的时间是： %DATE% %time% >>%BACK_FULL_NAME%_bat.log


REM 调用exp工具
rem %ORACLE_USERNAME%/%ORACLE_PASSWORD%@%IP%/%ORACLE_DB% grants=Y
exp userid='%ORACLE_USERNAME%/%ORACLE_PASSWORD%@%IP%/%ORACLE_DB% as sysdba' full=y grants=Y  file="%BACK_FULL_NAME%.dmp"

rem  log="%BACK_FULL_NAME%_exp.log"

rem 添加DMP存放文件夹
if not exist %BACKUP_WAREHOUSE%\DMP  md %BACKUP_WAREHOUSE%\DMP

echo 压缩并删除原有dmp文件...... >>%BACK_FULL_NAME%_bat.log
echo 当前的时间是： %DATE% %time% >>%BACK_FULL_NAME%_bat.log

rem %RAR_CMD% a -df "%BACK_FULL_NAME%_dmp.rar" "%BACK_FULL_NAME%.dmp"
%RAR_CMD% a -df "%BACK_FULL_NAME%_dmp.rar" "%BACK_FULL_NAME%.dmp"
echo rar压缩==> %BACK_FULL_NAME%_dmp.rar>>%BACK_FULL_NAME%_bat.log
REM "%BACK_FULL_NAME%exp.log"
echo 压缩并删除原有dmp文件结束! >>%BACK_FULL_NAME%_bat.log
echo 当前的时间是： %DATE% %time% >>%BACK_FULL_NAME%_bat.log

echo 开始移动压缩后的备份文件...... >>%BACK_FULL_NAME%_bat.log
echo 当前的时间是： %DATE% %time% >>%BACK_FULL_NAME%_bat.log
move %BACKUP_DIR%\*.rar %BACKUP_WAREHOUSE%\DMP\
  
echo 当前的时间是： %DATE% %time% >>%BACK_FULL_NAME%_bat.log
  
REM net send %userdomain% "数据库逻辑备份已于:%DATE% %time% 完成！"

echo .
echo 备份完成!!! >>%BACK_FULL_NAME%_bat.log
echo 完成的时间是： %DATE% %time% >>%BACK_FULL_NAME%_bat.log
echo ===============备份服务器 SZYY的数据完成!!!============== >>%BACK_FULL_NAME%_bat.log  
  
if not exist %BACKUP_WAREHOUSE%\LOG md %BACKUP_WAREHOUSE%\LOG  
move %BACKUP_DIR%\*.log %BACKUP_WAREHOUSE%\LOG\  
  
echo 正在删除过期备份，请稍等...... 
cd %BACKUP_WAREHOUSE%\DMP
dir /o-d *.rar /O:D> dir.txt
for /F "skip=%delDays% tokens=4" %%a in (dir.txt) do @if exist %%a del %%a
rem 删除七天前的rar备份文件  
rem forfiles /p %BACKUP_WAREHOUSE%\DMP /s /m *.rar /d -%delDays% /c "cmd /c del @file"  

echo 删除任务完成！
echo . 