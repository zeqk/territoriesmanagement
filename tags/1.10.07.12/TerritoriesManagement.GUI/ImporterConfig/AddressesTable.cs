﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TerritoriesManagement.GUI.ImporterConfig
{
    [Serializable]
    [TypeConverter(typeof(AddressesTableConverter))]
    public class AddressesTable
    {
        #region Fields
        private bool _import;

        private string _tableName;

        private Field _id;

        private Field _street;

        private Field _number;

        private Field _corner1;

        private Field _corner2;

        private Field _description;

        private Field _customField1;

        private Field _customField2;

        private Field _phone1;

        private Field _phone2;

        private Field _map1;

        private Field _map2;

        private Field _geoPosition;

        private Field _lat;

        private Field _lng;

        private Field _territoryName;

        private Field _territoryId;

        private Field _cityName;

        private Field _cityId;

        #endregion

        public AddressesTable()
        {
            _id = new Field("ID");
            _street = new Field("CALLE");
            _number = new Field("NUMERO");
            _corner1 = new Field("ESQUINA1");
            _corner2 = new Field("ESQUINA2");
            _description = new Field("DESCRIPCION");
            _customField1 = new Field("OTRO");
            _customField2 = new Field("OTRO2");
            _phone1 = new Field("TELEFONO1");
            _phone2 = new Field("TELEFONO2");
            _map1 = new Field("MAPA1");
            _map2 = new Field("MAPA2");
            _geoPosition = new Field("GEOPOSICION");
            _lat = new Field("LATITUD");
            _lng = new Field("LONGITUD");
            _territoryName = new Field("TERRITORIO");
            _territoryId = new Field("IDTERRITORIO");
            _cityName = new Field("CIUDAD");
            _cityId = new Field("IDCIUDAD");
        }
        #region Properties

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public bool Import
        {
            get { return _import; }
            set { _import = value; }
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

        public Field CustomField1
        {
            get { return _customField1; }
            set { _customField1 = value; }
        }

        public Field CustomField2
        {
            get { return _customField2; }
            set { _customField2 = value; }
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

        public Field Map1
        {
            get { return _map1; }
            set { _map1 = value; }
        }

        public Field Map2
        {
            get { return _map2; }
            set { _map2 = value; }
        }

        public Field GeoPosition
        {
            get { return _geoPosition; }
            set { _geoPosition = value; }
        }

        public Field Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }

        public Field Lng
        {
            get { return _lng; }
            set { _lng = value; }
        }

        public Field TerritoryId
        {
            get { return _territoryId; }
            set { _territoryId = value; }
        }

        public Field TerritoryName
        {
            get { return _territoryName; }
            set { _territoryName = value; }
        }

        public Field CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }

        public Field CityName
        {
            get { return _cityName; }
            set { _cityName = value; }
        }
        
        #endregion

    }
}