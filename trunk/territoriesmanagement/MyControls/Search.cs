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
        private string _column;      

        /// <summary>
        /// Holder for parameter
        /// </summary>
        private ObjectParameter _parameter;

        /// <summary>
        /// Holder for query
        /// </summary>
        private string _query;

        /// <summary>
        /// Holder for variable name
        /// </summary>
        private string _variableName;
	
	

        #endregion

        #region Properties

        /// <summary>
        /// Get/Set for control text
        /// </summary>
        public string Text
        {
            get { return lblCriteria.Text; }
            set { lblCriteria.Text = value; }
        }

        /// <summary>
        /// Get/Set for column
        /// </summary>
        public string Column
        {
            get { return _column; }
            set { _column = value; }
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
        public ObjectParameter Parameter
        {
            get { return _parameter; }
            set { _parameter = value; }
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
        public string VariableName
        {
            get { return _variableName; }
            set { _variableName = value; }
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
        public void SetProperties(string column, string text,string variableName)
        {
            this._column = column;
            this.lblCriteria.Text = text;
            this._variableName = variableName;
            _parameter = new ObjectParameter(variableName, typeof(string)); 
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
            if (_parameter != null)
            {
                switch (Criteria)
                {
                    case Enumerators.Criterias.EqualTo:
                        _parameter.Value = txtValue.Text.ToString();
                        _query = Column + "= @"+_variableName;
                        break;
                    case Enumerators.Criterias.NotEqualTo:
                        _parameter.Value = txtValue.Text.ToString();
                        _query = Column + " <> @" + _variableName;
                        break;
                    case Enumerators.Criterias.StartsWith:
                        _parameter.Value = txtValue.Text.ToString() + "%";
                        _query = Column + " LIKE @" + _variableName;
                        break;
                    case Enumerators.Criterias.EndsWith:
                        _parameter.Value = "%" + txtValue.Text.ToString();
                        _query = Column + " LIKE @" + _variableName;
                        break;
                    case Enumerators.Criterias.Contains:
                        _parameter.Value = "%" + txtValue.Text.ToString() + "%";
                        _query = Column + " LIKE @" + _variableName;
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
#endregion
    }
}
