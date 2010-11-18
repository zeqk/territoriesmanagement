[ISPP]
; Por favor, no edite esta secci�n manualmente si no sabe lo que est� haciendo.
; Please, don't edit this section manually if you don't know what are you doing.
#define path "C:\Documents and Settings\interaccionliuh\Mis documentos\Visual Studio 2008\Projects\territoriesmanagement\"

[Setup]
OutputBaseFilename=tmsetup1.10.11.18
OutputDir={#path}\bin
AlwaysUsePersonalGroup=True
AppName=Territories Management
AppVerName=Territories Management 1.10.11.18
AppPublisher=Zeqk
AppPublisherURL=http://sites.google.com/site/territoriesmanagement/
AppSupportURL=http://sites.google.com/site/territoriesmanagement/
AppUpdatesURL=http://sites.google.com/site/territoriesmanagement/
DefaultDirName={pf}\TerritoriesManagement
DefaultGroupName=TerritoriesManagement
EnableDirDoesntExistWarning=True
AppCopyright=GNU GPL 2010 Zeqk
RestartIfNeededByRun=False
SignedUninstallerDir={#path}\bin
VersionInfoVersion=1.10.11.18
VersionInfoCompany=Zeqk
VersionInfoCopyright=GNU GPL 2010 Zeqk
VersionInfoProductVersion=1.10.11.01
VersionInfoProductName=TerritoriesManagement
Compression=lzma/max
SolidCompression=yes
UninstallFilesDir={app}

[Languages]
Name: chs; MessagesFile: compiler:Languages\ChineseSimp.isl; LicenseFile: {#path}\license\License CHS.txt
Name: en; MessagesFile: compiler:Default.isl; LicenseFile: {#path}\license\License EN.txt
Name: es; MessagesFile: compiler:Languages\Spanish.isl; LicenseFile: {#path}\license\License ES.txt
Name: it; MessagesFile: compiler:Languages\Italian.isl; LicenseFile: {#path}\license\License IT.txt

[Files]
Source: {#path}\bin\last release\TerritoriesManagement.GUI.exe; DestDir: {app}; Flags: ignoreversion
Source: {#path}\bin\last release\*; DestDir: {app}; Excludes: TERRITORIESDB.FDB; Permissions: users-full; Flags: ignoreversion recursesubdirs createallsubdirs
Source: {#path}\bin\last release\TERRITORIESDB.FDB; DestDir: {app}; Permissions: users-full; Flags: confirmoverwrite



[Run]
Filename: "{app}\TerritoriesManagement.GUI.exe"; Description: "{cm:LaunchProgram,Territories Management}"; Flags: nowait postinstall skipifsilent


[Icons]
Name: {group}\Territories Management; Filename: {app}\TerritoriesManagement.GUI.exe
Name: {group}\Uninstall Territories Management; Filename: {uninstallexe}




