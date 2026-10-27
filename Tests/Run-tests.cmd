@echo off
setlocal
cd /d "%~dp0"
set "testCompiler=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if not exist "%testCompiler%" set "testCompiler=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\csc.exe"
if not exist "%testCompiler%" (
 echo .NET Framework compiler not found. Run these tests on the Windows development machine.
 exit /b 1
)
"%testCompiler%" /nologo /target:exe /out:RulesTests.exe RulesTests.cs "..\TutAcadApp\Services\Rules.cs"
if errorlevel 1 exit /b 1
RulesTests.exe
exit /b %errorlevel%
