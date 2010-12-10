using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerritoriesManagement.GUI.Interop;
namespace TerritoriesManagement.GUI.ImporterConfig
{
    public interface ITable
    {
        string ExternalTableName { get; set; }
        EntitiesEnum RelatedEntitySet { get; set; }
    }
}
