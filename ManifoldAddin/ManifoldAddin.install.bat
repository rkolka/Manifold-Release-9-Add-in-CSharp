@echo off
setlocal

rem set M9=C:\Program Files\Manifold\v9.0\shared
set M9=%MANIFOLD9_HOME%\shared

if exist "%M9%\$safeprojectname$\" GOTO ALREADYINSTALLED
GOTO DOINST


:DOINST
echo ------- Creating directory $safeprojectname$ 
echo ------- under %M9%\ 
mkdir "%M9%\$safeprojectname$"
if exist "%M9%\$safeprojectname$\" GOTO COPYFILES 
GOTO CANNOTCREATEDIR

:COPYFILES
echo ------- Copying add-in files
copy $safeprojectname$.dll "%M9%\$safeprojectname$\"
copy $safeprojectname$.dll.addin "%M9%\$safeprojectname$\"
copy $safeprojectname$.uninstall.bat "%M9%\$safeprojectname$\"
copy $safeprojectname$.readme.txt "%M9%\$safeprojectname$\"
goto END

:CANNOTCREATEDIR
echo Error: Cannot create Addin directory.
echo You must have write permission for %M9%
goto END

:ALREADYINSTALLED
echo Error: Cannot install
echo $safeprojectname$ directory already exists
echo Try running %M9%\$safeprojectname$\$safeprojectname$.uninstall.bat first
GOTO END

:END
endlocal
pause
