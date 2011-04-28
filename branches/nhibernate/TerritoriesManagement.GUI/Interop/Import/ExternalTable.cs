using System;
using TerritoriesManagement.GUI.Interop;
using System.Collections.Generic;
using System.ComponentModel;

namespace TerritoriesManagement.GUI.Interop.Import
{
    //http://www.codeproject.com/KB/tabs/customizingcollectiondata.aspx
    [Serializable]
    public class ExternalTable
    {
        private string _externalTableName;

        private List<Field> _fields;
        //private FieldCollection _fieldList;

        private EntitiesEnum _relatedEntitySet;

        public ExternalTable()
        {
            _fields = new List<Field>();
        }

        public string ExternalTableName
        {
            get { return _externalTableName; }
            set { _externalTableName = value; }
        }

        [Browsable(false)]
        public List<Field> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }


        [System.Xml.Serialization.XmlIgnore]
        [TypeConverter(typeof(FieldCollectionConverter))]        
        public FieldCollection FieldList
        {
            get 
            {
                FieldCollection fieldList = new FieldCollection();
                foreach (Field item in _fields)
                {
                    fieldList.Add(item);
                }

                return fieldList; 
            }
        }

        [ReadOnly(true), Browsable(false)]
        public EntitiesEnum RelatedEntitySet
        {
            get { return _relatedEntitySet; }
            set { _relatedEntitySet = value; }
        }
    }
}
