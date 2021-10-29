# Time tracker agent
The TimeTrackerAgent keeps track of the time you spend on any desktop applications.

[![Generic badge](https://img.shields.io/badge/language-c%23-green.svg)](https://shields.io/)
[![Generic badge](https://img.shields.io/badge/framework-.NET&nbsp;Core&nbsp;3.1-green.svg)](https://shields.io/)

# About The Project

The application runs as a Windows service and has an api endpoint. 
<code>http://*:5050</code>
Based on .net core 3.1.

Time tracking runs in the background and saves all data in an xml document along the path <code>%ProgramData%/TimeTrackerAgent/Data</code> for Windows.
The application captures the active current window, detects the current program, and tracks the running time of the application. In addition, idle time is recorded when the user does nothing.

The application can be extended to work with other platforms (linux).

TimeTracker has a project to install from wix.

Example of xml data:
<pre>
<code>
&lt;?xml version="1.0" encoding="utf-8"?&gt;
&lt;Day xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"&gt;
  &lt;Applications&gt;
    &lt;Application&gt;
      &lt;Name&gt;TimeTrackerAgent.exe&lt;/Name&gt;
      &lt;Path&gt;F:\time-tracker-agent\time-tracker-agent\src\TimeTrackerAgent\bin\Release\netcoreapp3.1\TimeTrackerAgent.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;F:\time-tracker-agent\time-tracker-agent\src\TimeTrackerAgent\bin\Release\netcoreapp3.1\TimeTrackerAgent.exe&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:00:03&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;Explorer.EXE&lt;/Name&gt;
      &lt;Path&gt;C:\Windows\Explorer.EXE&lt;/Path&gt;
      &lt;WindowTitle /&gt;
      &lt;SummaryTime&gt;00:00:33&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;notepad++.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Program Files\Notepad++\notepad++.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;C:\ProgramData\TimeTrackerAgent\Data\29.10.2021.xml - Notepad++ [Administrator]&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:00:28&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;chrome.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Program Files\Google\Chrome\Application\chrome.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;Zimbra: Финансы - Google Chrome&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:50:49&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;SearchApp.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Windows\SystemApps\Microsoft.Windows.Search_cw5n1h2txyewy\SearchApp.exe&lt;/Path&gt;
      &lt;WindowTitle /&gt;
      &lt;SummaryTime&gt;00:00:02&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;StartMenuExperienceHost.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Windows\SystemApps\Microsoft.Windows.StartMenuExperienceHost_cw5n1h2txyewy\StartMenuExperienceHost.exe&lt;/Path&gt;
      &lt;WindowTitle /&gt;
      &lt;SummaryTime&gt;00:00:07&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;devenv.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\devenv.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;Microsoft Visual Studio (Administrator)&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:02:24&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;taskmgr.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Windows\system32\taskmgr.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;Task Manager&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:00:10&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;vmware.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Program Files (x86)\VMware\VMware Workstation\vmware.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;Windows 10 x64 - VMware Workstation&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:02:21&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;InetMgr.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Windows\system32\inetsrv\InetMgr.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;Internet Information Services (IIS) Manager&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:00:04&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;Skype.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Program Files (x86)\Microsoft\Skype for Desktop\Skype.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;Skype&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:00:06&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;Telegram.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Users\Stigmat\AppData\Roaming\Telegram Desktop\Telegram.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;Telegram (3740)&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:02:54&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;LockApp.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Windows\SystemApps\Microsoft.LockApp_cw5n1h2txyewy\LockApp.exe&lt;/Path&gt;
      &lt;WindowTitle /&gt;
      &lt;SummaryTime&gt;00:00:09&lt;/SummaryTime&gt;
    &lt;/Application&gt;
    &lt;Application&gt;
      &lt;Name&gt;Fork.exe&lt;/Name&gt;
      &lt;Path&gt;C:\Users\Stigmat\AppData\Local\Fork\app-1.67.1\Fork.exe&lt;/Path&gt;
      &lt;WindowTitle&gt;Fork&lt;/WindowTitle&gt;
      &lt;SummaryTime&gt;00:02:29&lt;/SummaryTime&gt;
    &lt;/Application&gt;
  &lt;/Applications&gt;
  &lt;Date&gt;10/29/2021&lt;/Date&gt;
  &lt;ActiveTime&gt;01:02:53&lt;/ActiveTime&gt;
  &lt;IdleTime&gt;01:08:29&lt;/IdleTime&gt;
&lt;/Day&gt;
</code>
</pre>
