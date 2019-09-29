@echo off
setlocal


set M9=C:\Program Files\Manifold\v9.0\shared


if exist "%M9%\$safeprojectname$\" GOTO PROMPT
GOTO NOTHINGTOUNINSTALL

:PROMPT
SET /P AREYOUSURE=Are you sure you want to delete $safeprojectname$ ([Y]/N)?
IF /I "%AREYOUSURE%" NEQ "N" GOTO DOUNINST
GOTO DONOTWANT


:DOUNINST
cd..
del "%M9%\$safeprojectname$\$safeprojectname$.dll"
if exist "%M9%\$safeprojectname$\$safeprojectname$.dll" GOTO NOLUCK
echo $safeprojectname$.dll deleted. 
rmdir /S /Q "%M9%\$safeprojectname$\"
if exist "%M9%\$safeprojectname$\" GOTO NOLUCK
goto END

:NOLUCK
echo Error: Cannot delete $safeprojectname$.dll. Perhaps you have Manifold running.
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
