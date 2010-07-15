[ISPP]
; Please, don't edit this section manually if you don't know what are you doing.
[Setup]
OutputBaseFilename=tmsetup
OutputDir=D:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\bin
AlwaysUsePersonalGroup=True
AppName=Territories Management
AppVerName=Territories Management 1.10.04.02
AppPublisher=Zeqk
AppPublisherURL=http://sites.google.com/site/territoriesmanagement/
AppSupportURL=http://sites.google.com/site/territoriesmanagement/
AppUpdatesURL=http://sites.google.com/site/territoriesmanagement/
DefaultDirName={pf}\TerritoriesManagement
DefaultGroupName=TerritoriesManagement
EnableDirDoesntExistWarning=True
AppCopyright=GNU GPL 2010 Zeqk
RestartIfNeededByRun=False
SignedUninstallerDir=D:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\bin
VersionInfoVersion=1.10.04.02
VersionInfoCompany=Zeqk
VersionInfoCopyright=GNU GPL 2010 Zeqk
VersionInfoProductVersion=1.10.04.02
VersionInfoProductName=TerritoriesManagement
Compression=lzma
SolidCompression=yes
UninstallFilesDir={app}

[Languages]
Name: chs; MessagesFile: compiler:Languages\ChineseSimp.isl; LicenseFile: D:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\license\License CHS.txt
Name: en; MessagesFile: compiler:Default.isl; LicenseFile: D:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\license\License EN.txt
Name: es; MessagesFile: compiler:Languages\Spanish.isl; LicenseFile: D:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\license\License ES.txt

[Files]
Source: D:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\bin\last release\TerritoriesManagement.GUI.exe; DestDir: {app}; Flags: ignoreversion
Source: D:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\bin\last release\*; DestDir: {app}; Permissions: users-full; Flags: ignoreversion recursesubdirs createallsubdirs


[Run]
Filename: "{app}\TerritoriesManagement.GUI.exe"; Description: "{cm:LaunchProgram,Territories Management}"; Flags: nowait postinstall skipifsilent


[Icons]
Name: {group}\Territories Management; Filename: {app}\TerritoriesManagement.GUI.exe


