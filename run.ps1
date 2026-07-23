# PowerShell Launcher Script for Library Information System

Write-Host "========================================================" -ForegroundColor Cyan
Write-Host "       Library Information System Launcher" -ForegroundColor Cyan
Write-Host "========================================================" -ForegroundColor Cyan
Write-Host ""

# 1. Start LocalDB
Write-Host "[1/3] Ensuring SQL Server LocalDB service is running..." -ForegroundColor Yellow
sqllocaldb start MSSQLLocalDB | Out-Null

# 2. Seed Database
Write-Host "[2/3] Initializing Database Schema & Seed Data (LibraryDB)..." -ForegroundColor Yellow
$schemaPath = Join-Path $PSScriptRoot "Library\Database\schema.sql"
$seedPath = Join-Path $PSScriptRoot "Library\Database\seed.sql"
sqlcmd -S "(localdb)\MSSQLLocalDB" -i $schemaPath | Out-Null
sqlcmd -S "(localdb)\MSSQLLocalDB" -i $seedPath | Out-Null

# 3. Build Solution
Write-Host "[3/3] Building solution..." -ForegroundColor Yellow
$msbuild = "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"
if (Test-Path $msbuild) {
    & $msbuild "$PSScriptRoot\Library.sln" /t:Build /p:Configuration=Debug /verbosity:quiet
} else {
    dotnet build "$PSScriptRoot\Library.sln" --configuration Debug
}

if ($LASTEXITCODE -ne 0) {
    Write-Host "[ERROR] Build failed!" -ForegroundColor Red
    exit $LASTEXITCODE
}

# 4. Launch Application
Write-Host ""
Write-Host "========================================================" -ForegroundColor Green
Write-Host "Launching Library Management Application..." -ForegroundColor Green
Write-Host "Default Credentials:" -ForegroundColor Green
Write-Host "  1. Username: admin   | Password: admin123" -ForegroundColor White
Write-Host "  2. Username: Keiji   | Password: 201124" -ForegroundColor White
Write-Host "========================================================" -ForegroundColor Green
Write-Host ""

$exePath = Join-Path $PSScriptRoot "Library\bin\Debug\Library.exe"
Start-Process -FilePath $exePath
