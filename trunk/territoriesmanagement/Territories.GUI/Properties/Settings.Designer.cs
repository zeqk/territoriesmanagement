﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Territories.GUI.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute(@"metadata=res://*/TerritoriesModel.csdl|res://*/TerritoriesModel.ssdl|res://*/TerritoriesModel.msl;provider=System.Data.SqlClient;provider connection string='Data Source=.\SQLEXPRESS;AttachDbFilename=&quot;C:\Documents and Settings\interaccionliuh\Mis documentos\Visual Studio 2008\Projects\TerritoriesManagement\Territories.DB\Territories.mdf&quot;;Integrated Security=True;Connect Timeout=30;User Instance=True'")]
        public string TerritoriesDataContext {
            get {
                return ((string)(this["TerritoriesDataContext"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Documents and Settings\\interaccionl" +
            "iuh\\Mis documentos\\Visual Studio 2008\\Projects\\territoriesmanagement\\Territories" +
            ".DB\\Territories.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=T" +
            "rue")]
        public string NoAttachedTerritoriesDataContext {
            get {
                return ((string)(this["NoAttachedTerritoriesDataContext"]));
            }
        }
    }
}
