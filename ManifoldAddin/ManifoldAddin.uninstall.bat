@echo off
setlocal


rem set M9=C:\Program Files\Manifold\v9.0\shared
set M9=%MANIFOLD9_HOME%\shared


if exist "%M9%\$safeprojectname$\" GOTO PROMPT
GOTO NOTHINGTOUNINSTALL

:PROMPT
SET /P AREYOUSURE=Are you sure you want to delete $safeprojectname$ ([Y]/N)?
IF /I "%AREYOUSURE%" NEQ "N" GOTO DOUNINST
GOTO DONOTWANT


:DOUNINST
cd..
rmdir /S /Q "%M9%\$safeprojectname$\"
if exist "%M9%\$safeprojectname$\" GOTO NOLUCK
echo $safeprojectname$ successfully uninstalled
goto END

:NOLUCK
echo Error: Addin directory still exists. Perhaps you have Manifold running.
echo %M9%\$safeprojectname$\
GOTO END


:DONOTWANT
echo Uninstall skipped.
GOTO END

:NOTHINGTOUNINSTALL
echo Nothing to uninstall
echo $safeprojectname$ directory does not exist
GOTO END

:END
endlocal
pause
