@ echo ------ORACLE�Զ����ݿ�ʼ...  Zhang Junming���� @2012-----------  
REM ======================================================  
REM ���ݷ�����  SZYYϵͳ������  
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

REM ����ļ�������ҪСʱ�����ӣ��������һ�����
REM set BACK_NAME=%ORACLE_DB%_%ORACLE_USERNAME%_%TODAY%(%time:~0,2%ʱ%time:~3,2%��%time:~6,2%��)
set BACK_NAME=%ORACLE_DB%_%ORACLE_USERNAME%_%TODAY%
REM set BACK_NAME=%ORACLE_DB%_%TODAY%_%time:~0,2%ʱ%time:~3,2%��%time:~6,2%��
rem set BACK_NAME=%ORACLE_DB%_%TODAY%
set BACK_FULL_NAME=%BACKUP_DIR%\%BACK_NAME%


REM ������������������־ %BACK_FULL_NAME%_bat.log

echo ==================���ݷ����� SZYY������================= >>%BACK_FULL_NAME%_bat.log
echo ���ݿ�ʼ...... >>%BACK_FULL_NAME%_bat.log
echo ��ʼ��ʱ���ǣ� %DATE% %time% >>%BACK_FULL_NAME%_bat.log


REM ����exp����
rem %ORACLE_USERNAME%/%ORACLE_PASSWORD%@%IP%/%ORACLE_DB% grants=Y
exp userid='%ORACLE_USERNAME%/%ORACLE_PASSWORD%@%IP%/%ORACLE_DB% as sysdba' full=y grants=Y  file="%BACK_FULL_NAME%.dmp"

rem  log="%BACK_FULL_NAME%_exp.log"

rem ���DMP����ļ���
if not exist %BACKUP_WAREHOUSE%\DMP  md %BACKUP_WAREHOUSE%\DMP

echo ѹ����ɾ��ԭ��dmp�ļ�...... >>%BACK_FULL_NAME%_bat.log
echo ��ǰ��ʱ���ǣ� %DATE% %time% >>%BACK_FULL_NAME%_bat.log

rem %RAR_CMD% a -df "%BACK_FULL_NAME%_dmp.rar" "%BACK_FULL_NAME%.dmp"
%RAR_CMD% a -df "%BACK_FULL_NAME%_dmp.rar" "%BACK_FULL_NAME%.dmp"
echo rarѹ��==> %BACK_FULL_NAME%_dmp.rar>>%BACK_FULL_NAME%_bat.log
REM "%BACK_FULL_NAME%exp.log"
echo ѹ����ɾ��ԭ��dmp�ļ�����! >>%BACK_FULL_NAME%_bat.log
echo ��ǰ��ʱ���ǣ� %DATE% %time% >>%BACK_FULL_NAME%_bat.log

echo ��ʼ�ƶ�ѹ����ı����ļ�...... >>%BACK_FULL_NAME%_bat.log
echo ��ǰ��ʱ���ǣ� %DATE% %time% >>%BACK_FULL_NAME%_bat.log
move %BACKUP_DIR%\*.rar %BACKUP_WAREHOUSE%\DMP\
  
echo ��ǰ��ʱ���ǣ� %DATE% %time% >>%BACK_FULL_NAME%_bat.log
  
REM net send %userdomain% "���ݿ��߼���������:%DATE% %time% ��ɣ�"

echo .
echo �������!!! >>%BACK_FULL_NAME%_bat.log
echo ��ɵ�ʱ���ǣ� %DATE% %time% >>%BACK_FULL_NAME%_bat.log
echo ===============���ݷ����� SZYY���������!!!============== >>%BACK_FULL_NAME%_bat.log  
  
if not exist %BACKUP_WAREHOUSE%\LOG md %BACKUP_WAREHOUSE%\LOG  
move %BACKUP_DIR%\*.log %BACKUP_WAREHOUSE%\LOG\  
  
echo ����ɾ�����ڱ��ݣ����Ե�...... 
cd %BACKUP_WAREHOUSE%\DMP
dir /o-d *.rar /O:D> dir.txt
for /F "skip=%delDays% tokens=4" %%a in (dir.txt) do @if exist %%a del %%a
rem ɾ������ǰ��rar�����ļ�  
rem forfiles /p %BACKUP_WAREHOUSE%\DMP /s /m *.rar /d -%delDays% /c "cmd /c del @file"  

echo ɾ��������ɣ�
echo . 