using System.Diagnostics;
using System.Windows.Forms; // Ensure this is present
using System.IO; // Needed for file operations
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ZX_s_PC_Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button3.Click += button3_Click; // Attach the event handler
            button2.Click += button2_Click; // Attach the new event handler
            button4.Click += button4_Click; // Attach the new event handler
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Add these fields at the top of your Form1 class
        private static readonly string BotToken = "notoken4uLOL";
        // Replace with your actual #code channel ID (right-click the channel in Discord > Copy Channel ID)
        private static readonly string CodeChannelId = "1381273341221933076";

        // Fetch the latest message content from the Discord #code channel using the bot
        private async Task<string?> GetLatestPremiumCodeAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync("https://raw.githubusercontent.com/zxbot3/zxcheckercode/refs/heads/main/code");
                    response.EnsureSuccessStatusCode();
                    var code = await response.Content.ReadAsStringAsync();
                    return code.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to fetch premium code: " + ex.Message);
            }
            return null;
        }

        // Update your button3_Click handler to be async and check both codes
        private async void button3_Click(object sender, EventArgs e)
        {
            string inputCode = textBox1.Text.Trim();

            if (inputCode == "wellplayed")
            {
                MessageBox.Show("Correct code", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label6.Text = "Logged in as Lite Plan User";
                button1.Visible = true;
                button2.Visible = true;
                label6.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
            }
            else
            {
                string? premiumCode = await GetLatestPremiumCodeAsync();
                if (!string.IsNullOrEmpty(premiumCode) && inputCode == premiumCode)
                {
                    MessageBox.Show("Correct code", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label6.Text = "Logged in as Premium User";
                    button1.Visible = true;
                    button2.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    label6.Visible = true;
                }
                else
                {
                    MessageBox.Show("Incorrect code", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Define batch script content
                string batchScript = @"@echo off
setlocal EnableDelayedExpansion

:: Display banner
echo.
echo ============================
echo    ZX's PC CHECKER
echo ============================
timeout /t 3 >nul

:: Admin check
>nul 2>&1 ""%SYSTEMROOT%\system32\cacls.exe"" ""%SYSTEMROOT%\system32\config\system""
if '%errorlevel%' NEQ '0' (
    echo Requesting administrative privileges...
    powershell -Command ""Start-Process '%~f0' -Verb runAs""
    exit /b
)

:: Set up folder
set ""TARGETDIR=C:\ZXPCCHECK""
if not exist ""%TARGETDIR%"" (
    mkdir ""%TARGETDIR%""
)
cd /d ""%TARGETDIR%""

:: Download tools
call :Download ""https://www.voidtools.com/Everything-1.4.1.1026.x64.Lite-Setup.exe"" ""Everything-Setup.exe""
call :Download ""https://www.nirsoft.net/utils/executedprogramslist.zip"" ""executedprogramslist.zip""
call :Download ""https://github.com/ponei/JournalTrace/releases/download/1.0/JournalTrace.exe"" ""JournalTrace.exe""
call :Download ""https://www.nirsoft.net/utils/usbdeview.zip"" ""usbdeview.zip""
call :Download ""https://www.nirsoft.net/utils/windefthreatsview-x64.zip"" ""windefthreatsview-x64.zip""
call :Download ""https://github.com/kacos2000/Win10LiveInfo/releases/download/v.1.0.23.0/WinLiveInfo.exe"" ""WinLiveInfo.exe""
call :Download ""https://www.nirsoft.net/utils/winprefetchview-x64.zip"" ""winprefetchview-x64.zip""
call :Download ""https://www.nirsoft.net/utils/browserdownloadsview-x64.zip"" ""browserdownloadsview-x64.zip""
call :Download ""https://www.nirsoft.net/utils/appreadwritecounter-x64.zip"" ""appreadwritecounter-x64.zip""
call :Download ""https://www.nirsoft.net/utils/alternatestreamview-x64.zip"" ""alternatestreamview-x64.zip""
call :Download ""https://ixpeering.dl.sourceforge.net/project/processhacker/processhacker2/processhacker-2.37-setup.exe?viasf=1"" ""ProcessHacker-2.37-setup.exe""
call :Download ""https://win.cleverfiles.com/disk-drill-win.exe"" ""disk-drill-win.exe""

:: Extract ZIPs
echo.
echo Extracting ZIP files...
for %%f in (*.zip) do (
    echo Extracting %%f...
    powershell -Command ""Expand-Archive -Force '%%f' '.'""
)

:: Collect user input
set /p ""GAMENAME=Enter the name of the game you're checking for: ""
set /p ""CHECKER=Enter the PC Checker or admins name: ""
set /p ""CLIENTNAME=Enter your name (roblox and discord users): ""

:: Gather system info
for /f ""tokens=*"" %%u in ('net user ^| findstr /R /C:""^*""') do (
    set ""USERS=!USERS!%%u\n""
)

for /f ""tokens=*"" %%i in ('systeminfo ^| findstr /C:""Original Install Date""') do set INSTALL_DATE=%%i
for /f ""tokens=*"" %%j in ('net statistics workstation ^| findstr /C:""Statistics since""') do set LAST_BOOT=%%j

:: Write to local report file
set ""REPORT=%TARGETDIR%\PC_Report.txt""
(
    echo ZX PC Checker Report
    echo ---------------------
    echo Game Name: %GAMENAME%
    echo Checked By: %CHECKER%
    echo Clients username: %CLIENTNAME%
    echo.
    echo Users:
    net user
    echo.
    echo %INSTALL_DATE%
    echo %LAST_BOOT%
) > ""%REPORT%""

:: Write PowerShell script for sending to Discord
set ""PSFILE=%TEMP%\send_to_discord.ps1""
(
    echo $report = Get-Content -Path ""%REPORT%"" -Raw
    echo $payload = @{
    echo     username = ""ZX Manual PC Checker""
    echo     content = ""``````n$report`n``````""
    echo } ^| ConvertTo-Json -Compress
    echo Invoke-RestMethod -Uri ""https://discord.com/api/webhooks/1382145759713165373/0-msOzXWMdoIegNi_IYdYpsiURadpc5yYiZJDHuOe5zFC4O90xl5sBNGoQWaMEBe3RzW"" -Method Post -Body $payload -ContentType ""application/json""
) > ""%PSFILE%""

powershell -ExecutionPolicy Bypass -File ""%PSFILE%""
del ""%PSFILE%""
echo.
echo Report complete. Info saved to PC_Report.txt and sent to Discord.
pause
exit /b

:Download
:: %1 = URL, %2 = Output Filename
echo Downloading %2...
powershell -Command ""Invoke-WebRequest -Uri '%~1' -OutFile '%~2'"" >nul 2>&1
if exist ""%~2"" (
    echo Downloaded: %2
) else (
    echo Failed to download: %2
)
exit /b
";

                // Save to temporary file
                string tempFile = Path.Combine(Path.GetTempPath(), "ZXPCChecker.bat");
                File.WriteAllText(tempFile, batchScript);

                // Start it with admin rights
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true,
                    Verb = "runas" // Run as administrator
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run batch script: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string batchScript = @"@echo off
title ZX's AUTOMATIC PC CHECKER
color 0A
echo ZX's AUTOMATIC PC CHECKER
timeout /t 3 >nul

:: --- Check if running as admin ---
net session >nul 2>&1
if %errorLevel% NEQ 0 (
    echo Requesting administrator access...
    powershell -Command ""Start-Process '%~f0' -Verb RunAs""
    exit /b
)

:: --- Create folder ---
set ""output=C:\autocheck""
if not exist ""%output%"" mkdir ""%output%""

set ""result=%output%\results.txt""
echo Checking system... > ""%result%""

:: --- Prompt for Username ---
set /p checkuser=Enter the name of the person being checked: 
echo Username Being Checked: %checkuser% >> ""%result%""

:: --- Check if prefetching is enabled ---
reg query ""HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters"" /v EnablePrefetcher >nul 2>&1
if %errorlevel%==0 (
    for /f ""tokens=3"" %%a in ('reg query ""HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters"" /v EnablePrefetcher 2^>nul') do (
        echo Prefetcher Enabled: %%a >> ""%result%""
    )
) else (
    echo Prefetcher setting not found >> ""%result%""
)

:: --- Get Windows install date ---
for /f ""tokens=1,*"" %%a in ('""systeminfo | findstr /C:""Original Install Date""""') do (
    echo Windows Install Date: %%b >> ""%result%""
)

:: --- Get last reboot time using PowerShell ---
for /f ""delims="" %%i in ('powershell -command ""(Get-CimInstance -ClassName win32_operatingsystem).LastBootUpTime""') do (
    echo Last Reboot Time: %%i >> ""%result%""
)

:: --- Search for suspicious strings ---
echo.
echo Searching Strings...
echo.
echo --- Suspicious Files/Folders Found --- >> ""%result%""

setlocal enabledelayedexpansion
set ""keywords=Matrix Aimmy newuiwithpatch ddxoft olduimatrix newuimatrix Cheat Hack linkvertise adfocus lootlink AimmyV2 krnl Cheathub ronix fluxus drift SubZero injector aimbot nezuraim matcha matchaconfig xeno silentaim Dx9 awp.gg jjsploit solara nezur seliware delta""

for %%k in (%keywords%) do (
    echo Searching for ""%%k""...
    for /r ""C:\"" %%f in (*%%k*) do (
        echo Found: %%f >> ""%result%""
    )
)

:: --- Download and Extract EchoAC Executable ---
echo.
echo Downloading EchoAC tool...

set ""zipfile=%output%\ac.zip""
set ""exedir=%output%""
curl -L ""https://raw.githubusercontent.com/zxbot3/echoac-free/refs/heads/main/ac.zip"" -o ""%zipfile%""

if exist ""%zipfile%"" (
    echo Extracting EchoAC...
    powershell -Command ""Expand-Archive -Path '%zipfile%' -DestinationPath '%exedir%' -Force""

    :: Search recursively for ac.exe
    for /r ""%exedir%"" %%x in (ac.exe) do (
        set ""echopath=%%x""
        goto :found_exe
    )

    echo ERROR: Could not find ac.exe after extracting.
    pause
    exit /b

:found_exe
    echo Found EchoAC at: %echopath%
    echo Launching EchoAC...
    start """" ""%echopath%""
    echo Please follow the prompts in EchoAC.
    echo When it opens choose ""Roblox""
    echo Accept the Licence agreement and Privacy Policy
    echo Click on ""or try for free"" below the code input
    echo Then press begin scan
    echo When complete, it will show your link.
    pause
    goto skip_download_error
) else (
    echo ERROR: Failed to download EchoAC ZIP.
    pause
    exit /b
)

:skip_download_error

:: --- Ask for EchoAC link from user ---
set /p echolink=Please enter your EchoAC link (shown at the end of EchoAC tool): 
echo. >> ""%result%""
echo --- EchoAC Link --- >> ""%result%""
echo %echolink% >> ""%result%""

:: --- Log recent antivirus detections (Windows Defender only) ---
echo. >> ""%result%""
echo --- Recent Antivirus Detections (Windows Defender) --- >> ""%result%""
powershell -Command ""try { Get-MpThreatDetection | Sort-Object -Property InitialDetectionTime -Descending | Select-Object ThreatName,ActionSuccess,InitialDetectionTime -First 5 | Format-Table -AutoSize | Out-String } catch { 'No detections or access denied.' }"" >> ""%result%""

:: --- Send to Discord webhook ---
echo.
echo Sending report to webhook...

curl -H ""Content-Type: multipart/form-data"" ^
     -F ""payload_json={\""content\"": \""New PC check result for %checkuser%. See attached file.\""}"" ^
     -F ""file=@%result%"" ^
     ""https://discord.com/api/webhooks/1382145565264969839/t8UiSltDdOGAljxU4RZ41lqdVzC025H4RJFOdnFpOYjihNoR2SIA2UqyzXs-m3m-Ifco""

echo.
echo Done. Output saved to %result%
pause
exit
";

                string tempFile = Path.Combine(Path.GetTempPath(), "ZXPCAutoChecker.bat");
                File.WriteAllText(tempFile, batchScript);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true,
                    Verb = "runas" // Run as administrator
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run automatic batch script: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string batchScript = @"@echo off
title ZX's AUTOMATIC PC CHECKER PREMIUM
color 0A
echo ZX's AUTOMATIC PC CHECKER PREMIUM
timeout /t 3 >nul

:: --- Check if running as admin ---
net session >nul 2>&1
if %errorLevel% NEQ 0 (
    echo Requesting administrator access...
    powershell -Command ""Start-Process '%~f0' -Verb RunAs""
    exit /b
)

:: --- Create output folder ---
set ""output=C:\autocheck""
if not exist ""%output%"" mkdir ""%output%""
set ""result=%output%\results.txt""
echo Checking system... > ""%result%""

:: --- Prompt for Username ---
set /p checkuser=Enter the name of the person being checked: 
echo Username Being Checked: %checkuser% >> ""%result%""

:: --- Simulated Progress Bar ---
cls
echo Thank you for using ZXs AUTOMATIC PC CHECKER PREMIUM
echo Starting PC Checking Services...
setlocal enabledelayedexpansion
set ""bar=[                    ]""
set /a progress=0
:progress_loop
cls
echo ZX's AUTOMATIC PC CHECKER PREMIUM
echo.
echo Thanks for using PC Checker Premium...
echo Scanning for known cheat traces...
set /a progress+=5
set /a blocks=progress / 5
set ""bar=[""
for /L %%i in (1,1,!blocks!) do set ""bar=!bar!#""
for /L %%i in (!blocks!,1,20) do set ""bar=!bar! ""
set ""bar=!bar!]""
echo.
echo Progress: !bar! !progress!%%
timeout /t 1 >nul
if !progress! LSS 100 goto progress_loop
endlocal

cls
echo Beginning full system scan...
timeout /t 2 >nul

:: --- Prefetch Cheat Keyword Scan ---
echo Scanning Prefetch files...
echo. >> ""%result%""
echo --- Prefetch Cheat Keyword Scan --- >> ""%result%""
setlocal enabledelayedexpansion
set ""prefetch=C:\Windows\Prefetch""
set ""keywords=Matrix Aimmy newuiwithpatch ddxoft olduimatrix newuimatrix Cheat Hack linkvertise adfocus lootlink AimmyV2 krnl Cheathub ronix fluxus drift SubZero injector aimbot nezuraim matcha matchaconfig xeno silentaim Dx9 awp.gg jjsploit solara nezur seliware delta""

if exist ""%prefetch%"" (
    for %%k in (%keywords%) do (
        echo Searching for ""%%k"" in Prefetch...
        for %%f in (%prefetch%\*%%k*.pf) do (
            echo Found in Prefetch: %%~nxf >> ""%result%""
        )
    )
) else (
    echo Prefetch folder not found. >> ""%result%""
)

:: --- Windows Install Date ---
echo Checking Windows installation date...
for /f ""tokens=1,*"" %%a in ('""systeminfo | findstr /C:""Original Install Date""""') do (
    echo Windows Install Date: %%b >> ""%result%""
)

:: --- Last reboot time ---
echo Checking last system reboot...
for /f ""delims="" %%i in ('powershell -command ""(Get-CimInstance -ClassName win32_operatingsystem).LastBootUpTime""') do (
    echo Last Reboot Time: %%i >> ""%result%""
)

:: --- Startup programs ---
echo Analyzing startup applications...
echo. >> ""%result%""
echo --- Startup Programs (Registry Run Keys) --- >> ""%result%""
reg query HKCU\Software\Microsoft\Windows\CurrentVersion\Run >> ""%result%"" 2>nul
reg query HKLM\Software\Microsoft\Windows\CurrentVersion\Run >> ""%result%"" 2>nul

:: --- Running Processes ---
echo Checking running processes...
echo. >> ""%result%""
echo --- Running Processes (Roblox-related or suspicious) --- >> ""%result%""
tasklist | findstr /i ""Matrix Aimmy newuiwithpatch ddxoft olduimatrix newuimatrix Cheat Hack linkvertise adfocus lootlink AimmyV2 krnl Cheathub ronix fluxus drift SubZero injector aimbot nezuraim matcha matchaconfig xeno silentaim Dx9 awp.gg awp jjsploit solara nezur seliware delta"" >> ""%result%""

:: --- USB History (Extended) ---
echo. >> ""%result%""
echo --- USB Device History --- >> ""%result%""
reg query HKLM\SYSTEM\CurrentControlSet\Enum\USB /s >> ""%result%"" 2>nul
reg query HKLM\SYSTEM\CurrentControlSet\Enum\USBSTOR /s >> ""%result%"" 2>nul

:: --- Recycle Bin Contents ---
echo Scanning Recycle Bin contents...
echo. >> ""%result%""
echo --- Recycle Bin Contents --- >> ""%result%""
dir /s /b %systemdrive%\$Recycle.Bin >> ""%result%"" 2>nul

:: --- Antivirus (Windows Defender) Detections ---
echo Checking Windows Defender logs...
echo. >> ""%result%""
echo --- Windows Defender Threat History --- >> ""%result%""
powershell -Command ""Get-MpThreatDetection"" >> ""%result%"" 2>nul

:: --- Keyword File Search ---
echo Searching C:\ for known cheat traces...
echo. >> ""%result%""
echo --- Keyword File Search (C:\) --- >> ""%result%""
for %%k in (%keywords%) do (
    echo Searching for ""%%k"" on drive C:\...
    for /r ""C:\\"" %%f in (*%%k*) do (
        echo Found: %%f >> ""%result%""
    )
)

echo Scanning for DMA cheat tools...
call :progress
:: --- DMA Cheat Detection ---
echo. >> ""%result%""
echo --- DMA Cheat Detection --- >> ""%result%""
echo Scanning for DMA devices (e.g., PCILeech)...

:: Check drivers and services for known DMA tools
driverquery /V | findstr /i ""pcileech screamer dma fpga"" >> ""%result%"" 2>nul
sc query | findstr /i ""pcileech screamer dma fpga"" >> ""%result%"" 2>nul

:: Use PowerShell to get PCI device descriptions
powershell -Command ""Get-PnpDevice -Class 'System' | Where-Object { $_.FriendlyName -match 'PCI' -or $_.Name -match 'DMA' }"" >> ""%result%"" 2>nul

:: Log message to screen
echo DMA device scan completed.

:: --- Download and Extract EchoAC Executable ---
echo.
echo Downloading EchoAC tool...

set ""zipfile=%output%\ac.zip""
set ""exedir=%output%""
curl -L ""https://raw.githubusercontent.com/zxbot3/echoac-free/refs/heads/main/ac.zip"" -o ""%zipfile%""

if exist ""%zipfile%"" (
    echo Extracting EchoAC...
    powershell -Command ""Expand-Archive -Path '%zipfile%' -DestinationPath '%exedir%' -Force""

    :: Search recursively for ac.exe
    for /r ""%exedir%"" %%x in (ac.exe) do (
        set ""echopath=%%x""
        goto :found_exe
    )

    echo ERROR: Could not find ac.exe after extracting.
    pause
    exit /b

:found_exe
    echo Found EchoAC at: %echopath%
    echo Launching EchoAC...
    start """" ""%echopath%""
    echo Please follow the prompts in EchoAC.
    echo When it opens choose ""Roblox""
    echo Accept the Licence agreement and Privacy Policy
    echo Click on ""or try for free"" below the code input
    echo Then press begin scan
    echo When complete, it will show your link.
    pause
    goto skip_download_error
) else (
    echo ERROR: Failed to download EchoAC ZIP.
    pause
    exit /b
)

:skip_download_error

:: --- Ask for EchoAC link from user ---
set /p echolink=Please enter your EchoAC link (shown at the end of EchoAC tool): 
echo. >> ""%result%""
echo --- EchoAC Link --- >> ""%result%""
echo %echolink% >> ""%result%""

:: --- Send report to Discord webhook ---
echo Sending report to Discord webhook...
curl -H ""Content-Type: multipart/form-data"" ^
     -F ""payload_json={\""content\"": \""New PC check result for %checkuser%. See attached file.\""}"" ^
     -F ""file=@%result%"" ^
     ""https://discord.com/api/webhooks/1382147153274867733/lMHWxhI6kxZ7Ni4PIQu_NO4eM8ZnlhRqYVh2KzqeoWnJfWksApWk89KXvtWZDrAYVGW1""

echo Done. Output saved to %result%
pause
exit
";

                string tempFile = Path.Combine(Path.GetTempPath(), "ZXPCAutoCheckerPremium.bat");
                File.WriteAllText(tempFile, batchScript);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true,
                    Verb = "runas" // Run as administrator
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run premium batch script: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            try
            {
                string batchScript = @"@echo off
title ZX's ROBLOX PC CHECKER - GUEST VERSION
color 0A
setlocal enabledelayedexpansion

set /p checkedName=Enter the name of the person being checked: 
echo.
echo [*] Starting scan on %checkedName%'s PC...
timeout /t 2 >nul
echo.

set ""keywords=aimbot jjsploit matrix aimmy xeno solara inject""
set ""folders=%userprofile%\Desktop %userprofile%\Downloads %userprofile%\Documents""
set ""prefetchPath=%SystemRoot%\Prefetch""

set ""outputFile=%temp%\zx_pc_checker_output.txt""
if exist ""%outputFile%"" del ""%outputFile%""

(
echo ZX's ROBLOX PC CHECKER - GUEST VERSION
echo Scan report for: %checkedName%
echo Scan started at: %date% %time%
echo.
echo --- Scanning common folders for known cheats ---
) >> ""%outputFile%""

for %%K in (%keywords%) do (
    for %%F in (%folders%) do (
        echo Searching for ""%%K"" in %%F...
        echo Searching for ""%%K"" in %%F... >> ""%outputFile%""
        findstr /si /m ""%%K"" ""%%F\*"" >> ""%outputFile%"" 2>nul
    )
)

echo. >> ""%outputFile%""
echo --- Scanning Prefetch folder for cheat traces --- >> ""%outputFile%""
for %%K in (%keywords%) do (
    dir /b ""%prefetchPath%"" | findstr /i ""%%K"" >> ""%outputFile%"" 2>nul
)

echo. >> ""%outputFile%""
echo Scan complete at: %date% %time% >> ""%outputFile%""
echo This is a GUEST version with limited checks. >> ""%outputFile%""

echo ================================
echo Scan complete.
echo Sending results to Discord webhook...
echo ================================
timeout /t 2 >nul

:: Read output, trim to 1800 chars, send to Discord webhook using PowerShell
powershell -Command ^
    ""$content = Get-Content -Raw -Path '%outputFile%';"" ^
    ""$content = $content.Substring(0,[Math]::Min($content.Length,1800));"" ^
    ""Invoke-RestMethod -Uri 'https://discord.com/api/webhooks/1382145415696224358/kIcHQSt-rSHWia0IsLtW9oX1CzzORPoD8jkOo93lOG05CReyz9RLHJwZLgy44K2Vi5dw' -Method Post -Body (@{content=$content})""

del ""%outputFile%""
exit
";

                string tempFile = Path.Combine(Path.GetTempPath(), "ZXPCGuestChecker.bat");
                File.WriteAllText(tempFile, batchScript);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true,
                    Verb = "runas" // Run as administrator
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run guest batch script: " + ex.Message);
            }
        }
    }
}
