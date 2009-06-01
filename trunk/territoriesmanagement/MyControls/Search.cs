using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Objects;
using My;
using System.Windows.Forms;

namespace My.Controls
{
    public partial class Search : UserControl
    {
        #region Fields
        /// <summary>
        /// Holder for column
        /// </summary>
        private string[] _columns;      

        /// <summary>
        /// Holder for parameter
        /// </summary>
        private List<ObjectParameter> _parameters;

        /// <summary>
        /// Holder for query
        /// </summary>
        private string _query;

        /// <summary>
        /// Holder for variable name
        /// </summary>
        private string[] _variableNames;
	
	

        #endregion

        #region Properties

        /// <summary>
        /// Get/Set for column
        /// </summary>
        public string[] Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        /// <summary>
        /// Get/Set for search criteria
        /// </summary>
        public Enumerators.Criterias Criteria
        {
            get { return (Enumerators.Criterias)this.cmbCriteria.SelectedIndex; }
            set { this.cmbCriteria.SelectedIndex = (int)value; }
        }

        /// <summary>
        /// Get/Set for parameter
        /// </summary>
        public List<ObjectParameter> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        /// <summary>
        /// Get/Set for query string
        /// </summary>
        public string Query
        {
            get { return _query; }
            set { _query = value; }
        }

        /// <summary>
        /// Get/Set for variable name
        /// </summary>
        public string[] VariableNames
        {
            get { return _variableNames; }
            set { _variableNames = value; }
        }
        #endregion

        #region Constructors
        public Search()
        {
            InitializeComponent();
            ConfigureCmbCriteria();

            
        }
        #endregion

        #region Methods

        /// <summary>
        /// Set Search control properties
        /// </summary>
        /// <param name="column">string column name for the query</param>
        /// <param name="text">string control name</param>
        public void SetProperties(string[] columns,string[] variableNames)
        {
            this._columns = columns;
            this._variableNames = variableNames;
            _parameters = new List<ObjectParameter>();
            for (int i = 0; i < variableNames.Length; i++)
            {
                _parameters.Add(new ObjectParameter(variableNames[i], typeof(string)));
            }
            
            
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void ConfigureCmbCriteria()
        {
            string[] criterias = {"Equal to","Not equal to","Starts with","Ends with","Contains"};

            cmbCriteria.DataSource = criterias;
        }

        public void MakeQuery()
        {            
            if (_parameters.Count>0)
            {
                _query = "";
                switch (Criteria)
                {
                    case Enumerators.Criterias.EqualTo:
                        for (int i = 0; i < _variableNames.Length; i++)
                        {
                            if (i > 0)
                                _query += " OR ";
                            _parameters[i].Value = txtValue.Text.ToString();
                            _query += _columns[i]+ "= @" + _variableNames[i];
                        }                        
                        break;
                    case Enumerators.Criterias.NotEqualTo:
                        for (int i = 0; i < _variableNames.Length; i++)
                        {
                            if (i > 0)
                                _query += " OR ";
                            _parameters[i].Value = txtValue.Text.ToString();
                            _query += _columns[i] + " <> @" + _variableNames[i];
                        };
                        break;
                    case Enumerators.Criterias.StartsWith:
                        for (int i = 0; i < _variableNames.Length; i++)
                        {
                            if (i > 0)
                                _query += " OR ";
                            _parameters[i].Value = txtValue.Text.ToString() + "%";
                            _query += _columns[i] + " LIKE @" + _variableNames[i];
                        };
                        break;
                    case Enumerators.Criterias.EndsWith:
                        for (int i = 0; i < _variableNames.Length; i++)
                        {
                            if (i > 0)
                                _query += " OR ";
                            _parameters[i].Value = "%" +  txtValue.Text.ToString();
                            _query += _columns[i] + " LIKE @" + _variableNames[i];
                        };
                        break;
                    case Enumerators.Criterias.Contains:
                        for (int i = 0; i < _variableNames.Length; i++)
                        {
                            if (i > 0)
                                _query += " OR ";
                            _parameters[i].Value = "%" + txtValue.Text.ToString() + "%";
                            _query += _columns[i] + " LIKE @" + _variableNames[i];
                        };
                        break;
                    default:
                        break;
                }
            }
        }

        public void Clear()
        {
            txtValue.Text = "";
        }

        public bool IsClean()
        {
            bool rv = false;
            if (string.IsNullOrEmpty(txtValue.Text))
                rv = true;
            return rv;
        }
#endregion
    }
}
