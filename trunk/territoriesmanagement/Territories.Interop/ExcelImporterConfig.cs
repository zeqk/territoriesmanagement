using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Territories.Interop
{
    [Serializable]
    public class ExcelImporterConfig
    {
        #region Fields

        private string _excelPath;
        private string _sheetName;
        private FieldToTable _departments;
        private FieldToTable _cities;
        private FieldToTable _territories;
        private FieldToTable _directions;

        #endregion

        #region Constructors
        public ExcelImporterConfig()
        {

        }
        #endregion

        #region Properties

        
        public string ExcelPath
        {
            get { return _excelPath; }
            set { _excelPath = value; }
        }

        
        public string SheetName
        {
            get { return _sheetName; }
            set { _sheetName = value; }
        }

        
        public FieldToTable Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }

        
        public FieldToTable Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        
        public FieldToTable Territories
        {
            get { return _territories; }
            set { _territories = value; }
        }

        
        public FieldToTable Directions
        {
            get { return _directions; }
            set { _directions = value; }
        }

        #endregion

    }

    [Serializable]
    public class FieldToTable
    {
        private IDictionary<string, string> _columns;

        private bool _load;

        
        public IDictionary<string, string> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        
        public bool Load
        {
            get { return _load; }
            set { _load = value; }
        }

    }
}
