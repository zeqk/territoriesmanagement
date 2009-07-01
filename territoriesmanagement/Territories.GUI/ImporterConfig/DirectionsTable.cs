using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    [Serializable]
    [TypeConverter(typeof(DirectionsTableConverter))]
    public class DirectionsTable
    {
        #region Fields
        private bool _load;

        private string _tableName;

        private Field _id;

        private Field _street;

        private Field _number;

        private Field _corner1;

        private Field _corner2;

        private Field _description;

        private Field _phone1;

        private Field _phone2;

        private Field _geoPosition;

        private Field _territory;

        private Field _city;

        #endregion

        public DirectionsTable()
        {
            _id = new Field("Id");
            _street = new Field("Street");
            _number = new Field("Number");
            _corner1 = new Field("Corner1");
            _corner2 = new Field("Corner2");
            _description = new Field("Description");
            _phone1 = new Field("Phone1");
            _phone2 = new Field("Phone2");
            _geoPosition = new Field("GeoPosition");
            _territory = new Field("Territory");
            _city = new Field("City");
        }
        #region Properties

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public bool Load
        {
            get { return _load; }
            set { _load = value; }
        }

        public Field Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Field Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public Field Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public Field Corner1
        {
            get { return _corner1; }
            set { _corner1 = value; }
        }

        public Field Corner2
        {
            get { return _corner2; }
            set { _corner2 = value; }
        }

        public Field Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Field Phone2
        {
            get { return _phone2; }
            set { _phone2 = value; }
        }

        public Field Phone1
        {
            get { return _phone1; }
            set { _phone1 = value; }
        }

        public Field GeoPosition
        {
            get { return _geoPosition; }
            set { _geoPosition = value; }
        }

        public Field Territory
        {
            get { return _territory; }
            set { _territory = value; }
        }

        public Field City
        {
            get { return _city; }
            set { _city = value; }
        }
        
        #endregion

    }
}
