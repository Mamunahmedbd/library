@echo off
title Library Information System Runner
echo ========================================================
echo        Library Information System Launcher
echo ========================================================
echo.

:: 1. Start LocalDB service if needed
echo [1/3] Ensuring SQL Server LocalDB service is running...
sqllocaldb start MSSQLLocalDB >nul 2>&1

:: 2. Initialize database & seed tables
echo [2/3] Initializing Database Schema & Seed Data (LibraryDB)...
sqlcmd -S "(localdb)\MSSQLLocalDB" -i "%~dp0Library\Database\schema.sql" >nul 2>&1
sqlcmd -S "(localdb)\MSSQLLocalDB" -i "%~dp0Library\Database\seed.sql" >nul 2>&1

:: 3. Build solution using MSBuild
echo [3/3] Building solution...
set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"
if exist "%MSBUILD_PATH%" (
    "%MSBUILD_PATH%" "%~dp0Library.sln" /t:Build /p:Configuration=Debug /verbosity:quiet
) else (
    dotnet build "%~dp0Library.sln" --configuration Debug
)

if %ERRORLEVEL% NEQ 0 (
    echo.
    echo [ERROR] Build failed! Please check code errors above.
    pause
    exit /b %ERRORLEVEL%
)

:: 4. Launch Application
echo.
echo ========================================================
echo Launching Library Management Application...
echo.
echo Default Credentials:
echo   1. Username: admin   ^| Password: admin123
echo   2. Username: Keiji   ^| Password: 201124
echo ========================================================
echo.

start "" "%~dp0Library\bin\Debug\Library.exe"
