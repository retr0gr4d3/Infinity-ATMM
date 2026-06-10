@echo off
setlocal enabledelayedexpansion

:: All paths are relative to this bat file.
set ROOT=%~dp0
set SLN=%ROOT%Infinity_TestMod.sln
set OUT=%ROOT%Infinity-Beyond\bin\Release
set BUILD=%ROOT%build

echo ========================================
echo  Building Infinity-Beyond Mod
echo ========================================
echo.

dotnet build "%SLN%" -c Release

if !ERRORLEVEL! NEQ 0 (
    echo.
    echo BUILD FAILED. Check errors above.
    pause
    exit /b 1
)

:: Find most recently modified Beyond DLL
set "DLL="

for /f "delims=" %%F in ('
    powershell -NoProfile -ExecutionPolicy Bypass -Command ^
    "(Get-ChildItem '%OUT%\Beyond_*.dll' -ErrorAction SilentlyContinue | Sort-Object LastWriteTime -Descending | Select-Object -First 1).Name"
') do (
    set "DLL=%%F"
)

if not defined DLL (
    echo.
    echo ERROR: No Beyond DLL found.
    echo Searched:
    echo %OUT%\Beyond_*.dll
    pause
    exit /b 1
)

if not exist "%BUILD%" mkdir "%BUILD%"

copy /Y "%OUT%\!DLL!" "%BUILD%\" >nul

if !ERRORLEVEL! NEQ 0 (
    echo.
    echo ERROR: Failed to copy DLL.
    pause
    exit /b 1
)

echo.
echo Build succeeded!
echo.
echo DLL:
echo !DLL!
echo.
echo Copied to:
echo %BUILD%
echo.
echo Closing in 3 seconds...
timeout /t 3 /nobreak >nul
exit /b 0