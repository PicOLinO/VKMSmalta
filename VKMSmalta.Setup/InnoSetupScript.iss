; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{4C45B9F4-AFA9-4C6B-88D1-1236FE078B8D}
AppName=Smalta Simulator
AppVersion=1.1
;AppVerName=Smalta Simulator 1.1
AppPublisher=Danila Chervonny
DefaultDirName={pf}\Smalta Simulator
DefaultGroupName=Smalta Simulator
AllowNoIcons=yes
OutputBaseFilename=SmaplaSimulatorInstaller
Compression=lzma
SolidCompression=yes
AppCopyright=Danila Chervonny
PrivilegesRequired=none
AppContact=webmaster.pico@gmail.com
AppSupportPhone=+79852444487

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\VKMSmalta.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\Appccelerate.CommandLineParser.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\Appccelerate.CommandLineParser.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\Appccelerate.Fundamentals.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\Appccelerate.Fundamentals.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Data.v17.2.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Data.v17.2.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Mvvm.v17.2.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Mvvm.v17.2.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Pdf.v17.2.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Pdf.v17.2.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Printing.v17.2.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Printing.v17.2.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Xpf.Controls.v17.2.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Xpf.Controls.v17.2.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Xpf.Core.v17.2.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Xpf.Core.v17.2.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\DevExpress.Xpf.Themes.Office2016White.v17.2.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\Newtonsoft.Json.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\VKMSmalta.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\XAMLEx.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\ru\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\ja\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\es\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\Source\VKMSmalta\VKMSmalta\bin\Release\de\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\Smalta Simulator"; Filename: "{app}\VKMSmalta.exe"
Name: "{commondesktop}\Smalta Simulator"; Filename: "{app}\VKMSmalta.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\VKMSmalta.exe"; Description: "{cm:LaunchProgram,Smalta Simulator}"; Flags: nowait postinstall skipifsilent