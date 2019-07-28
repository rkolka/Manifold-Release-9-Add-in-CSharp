@echo off
setlocal

rem Default values 
set ZIP=%programfiles%\7-Zip\7z.exe
set ZIPFILE="Manifold Release 9 Add-in C#.zip"
set TEMPLATES=%userprofile%\Documents\Visual Studio 2019\Templates\ProjectTemplates\

GOTO CHECKZIP

:CHECKZIP
if exist "%ZIP%" GOTO DOZIP
GOTO PROMPTZIP

:PROMPTZIP
echo 7z.exe not found in 
echo      %ZIP%
SET /P ZIP=Enter path to 7z.exe or q to exit?
if /I "%ZIP%"=="Q" GOTO END
GOTO CHECKZIP

:DOZIP
if exist %ZIPFILE% del %ZIPFILE%
"%ZIP%" a -tzip %ZIPFILE% @___filestozip.txt 1> nul

GOTO CHECKVS

:CHECKVS
if exist "%TEMPLATES%" GOTO PROMPTINSTALL
GOTO PROMPTVS

:PROMPTVS
echo Visual Studio templates directory NOT found in 
echo     %TEMPLATES%
SET /P TEMPLATES=Enter path to Visual Studio templates directory or q to exit?
if /I "%TEMPLATES%"=="Q" GOTO END
GOTO CHECKVS




:PROMPTINSTALL
echo There is Visual Studio templates directory in 
echo      %TEMPLATES%
SET /P AREYOUSURE=Do you want to copy the template to Visual Studio (Y/[N])?
IF /I "%AREYOUSURE%" NEQ "Y" GOTO END
GOTO DOINSTALL

:DOINSTALL
copy %ZIPFILE% "%TEMPLATES%" 1> NUL
GOTO END

:END
endlocal
pause