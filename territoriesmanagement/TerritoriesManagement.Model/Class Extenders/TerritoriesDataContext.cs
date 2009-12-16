using System;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.EntityClient;
using FirebirdSql.Data.FirebirdClient;

namespace TerritoriesManagement.Model
{
    public partial class TerritoriesDataContext
    {
        #region entities_AddWIthPK

        /// <summary>
        /// There are no comments for TerritoriesModel.departments_AddWithPK in the schema.
        /// </summary>
        public Collection<Int32> departments_AddWithPK(Department v)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using(EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}",this.DefaultContainerName,"departments_AddWithPK");
                    cmd.CommandType = CommandType.StoredProcedure;

                    EntityParameter idParam = new EntityParameter("id", DbType.Int32);
                    idParam.Value = v.IdDepartment;
                    cmd.Parameters.Add(idParam);

                    EntityParameter nameParam = new EntityParameter("name", DbType.String);
                    nameParam.Value = v.Name;                   
                    cmd.Parameters.Add(nameParam);

                    if (conn.State!= ConnectionState.Open)
	                {
                        conn.Open();
	                }


                    var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
	                {
                        rv.Add((Int32)reader[0]);            	         
	                }

                    return rv;
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        /// <summary>
        /// There are no comments for TerritoriesModel.cities_AddWithPK in the schema.
        /// </summary>
        public Collection<Int32> cities_AddWithPK(City v)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using (EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}", this.DefaultContainerName, "cities_AddWithPK");
                    cmd.CommandType = CommandType.StoredProcedure;

                    EntityParameter idParam = new EntityParameter("id", DbType.Int32);
                    idParam.Value = v.IdCity;
                    cmd.Parameters.Add(idParam);

                    EntityParameter nameParam = new EntityParameter("name", DbType.String);
                    nameParam.Value = v.Name;
                    cmd.Parameters.Add(nameParam);

                    EntityParameter depParam = new EntityParameter("idDepartment", DbType.Int32);
                    depParam.Value = ExtractDepartmentId(v);
                    cmd.Parameters.Add(depParam);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }


                    var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        rv.Add((Int32)reader[0]);
                    }

                    return rv;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// There are no comments for TerritoriesModel.territories_AddWithPK in the schema.
        /// </summary>
        public Collection<Int32> territories_AddWithPK(Territory v)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using (EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}", this.DefaultContainerName, "territories_AddWithPK");
                    cmd.CommandType = CommandType.StoredProcedure;

                    EntityParameter idParam = new EntityParameter("id", DbType.Int32);
                    idParam.Value = v.IdTerritory;
                    cmd.Parameters.Add(idParam);

                    EntityParameter nameParam = new EntityParameter("name", DbType.String);
                    nameParam.Value = v.Name;
                    cmd.Parameters.Add(nameParam);

                    EntityParameter numParam = new EntityParameter("number",DbType.String);
                    numParam.Value = v.Number;
                    cmd.Parameters.Add(numParam);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }


                    var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        rv.Add((Int32)reader[0]);
                    }

                    return rv;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// There are no comments for TerritoriesModel.addresses_AddWithPK in the schema.
        /// </summary>
        public Collection<Int32> addresses_AddWithPK(Address v)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using (EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}", this.DefaultContainerName, "addresses_AddWithPK");
                    cmd.CommandType = CommandType.StoredProcedure;

                    EntityParameter aDataParam = new EntityParameter("addresData", DbType.String);
                    aDataParam.Value = v.AddressData;
                    cmd.Parameters.Add(aDataParam);

                    EntityParameter corner1Param = new EntityParameter("corner1", DbType.String);
                    corner1Param.Value = v.Corner1;
                    cmd.Parameters.Add(corner1Param);

                    EntityParameter corner2Param = new EntityParameter("corner2", DbType.String);
                    corner2Param.Value = v.Corner2;
                    cmd.Parameters.Add(corner2Param);

                    EntityParameter custom1DataParam = new EntityParameter("customField1", DbType.String);
                    custom1DataParam.Value = v.CustomField1;
                    cmd.Parameters.Add(custom1DataParam);

                    EntityParameter custom2DataParam = new EntityParameter("customField2", DbType.String);
                    custom2DataParam.Value = v.CustomField2;
                    cmd.Parameters.Add(custom2DataParam);

                    EntityParameter descParam = new EntityParameter("description", DbType.String);
                    descParam.Value = v.Description;
                    cmd.Parameters.Add(descParam);

                    EntityParameter idParam = new EntityParameter("id", DbType.Int32);
                    idParam.Value = v.IdAddress;
                    cmd.Parameters.Add(idParam);

                    EntityParameter map1Param = new EntityParameter("map1", DbType.String);
                    map1Param.Value = v.Map1;
                    cmd.Parameters.Add(map1Param);

                    EntityParameter map2Param = new EntityParameter("map2", DbType.String);
                    map2Param.Value = v.Map2;
                    cmd.Parameters.Add(map2Param);

                    EntityParameter numParam = new EntityParameter("number", DbType.Int32);
                    numParam.Value = v.Number;
                    cmd.Parameters.Add(numParam);

                    EntityParameter phone1Param = new EntityParameter("phone1", DbType.String);
                    phone1Param.Value = v.Phone1;
                    cmd.Parameters.Add(phone1Param);

                    EntityParameter phone2Param = new EntityParameter("phone2", DbType.String);
                    phone2Param.Value = v.Phone2;
                    cmd.Parameters.Add(phone2Param);

                    EntityParameter streetParam = new EntityParameter("street", DbType.String);
                    streetParam.Value = v.Street;
                    cmd.Parameters.Add(streetParam);

                    EntityParameter latParam = new EntityParameter("lat", DbType.Double);
                    latParam.Value = v.Lat;
                    cmd.Parameters.Add(latParam);

                    EntityParameter lngParam = new EntityParameter("lng", DbType.Double);
                    lngParam.Value = v.Lng;
                    cmd.Parameters.Add(lngParam);

                    EntityParameter cityParam = new EntityParameter("idCity", DbType.Int32);
                    cityParam.Value = ExtractCityId(v);
                    cmd.Parameters.Add(cityParam);

                    EntityParameter terrParam = new EntityParameter("idTerritory", DbType.Int32);
                    terrParam.Value = ExtractTerritoryId(v);
                    cmd.Parameters.Add(terrParam);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        rv.Add((Int32)reader[0]);
                    }

                    return rv;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private int? ExtractDepartmentId(City v)
        {
            int? id = null;

            try
            {
                if (v.Department != null)
                    id = v.Department.IdDepartment;
                else
                    if (v.DepartmentReference.EntityKey != null)
                        id = Convert.ToInt32(v.DepartmentReference.EntityKey.EntityKeyValues[0].Value);
            }
            catch(Exception ex)
            {
                
            }
            return id;
        }

        private int? ExtractCityId(Address v)
        {
            int? id = null;

            try 
	        {	        
        		if (v.City != null)
                id = v.City.IdCity;
                else
                    if(v.CityReference.EntityKey!=null)
                        id = Convert.ToInt32(v.CityReference.EntityKey.EntityKeyValues[0].Value);
	        }
	        catch (Exception ex)
	        {        		
	        }           

            return id;
        }

        private int? ExtractTerritoryId(Address v)
        {
            int? id = null;
            try 
	        {	        
        		if (v.Territory != null)
                id = v.Territory.IdTerritory;
                else
                    if(v.TerritoryReference.EntityKey!=null)
                        id = Convert.ToInt32(v.TerritoryReference.EntityKey.EntityKeyValues[0].Value);
	        }
	        catch (Exception ex)
	        {
	        }           

            return id;
        }
        #endregion

        #region entities_DeleteAll function imports
        /// <summary>
        /// There are no comments for TerritoriesModel.address_DeleteAll in the schema.
        /// </summary>
        public void addresses_DeleteAll()
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using (EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}", this.DefaultContainerName, "addresses_DeleteAll");
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    int count = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   

        /// <summary>
        /// There are no comments for TerritoriesModel.cities_DeleteAll in the schema.
        /// </summary>
        public void cities_DeleteAll()
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using (EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}", this.DefaultContainerName, "cities_DeleteAll");
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    int count = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// There are no comments for TerritoriesModel.departments_DeleteAll in the schema.
        /// </summary>
        public void departments_DeleteAll()
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using (EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}", this.DefaultContainerName, "departments_DeleteAll");
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    int count = (int) cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// There are no comments for TerritoriesModel.territories_DeleteAll in the schema.
        /// </summary>
        public void territories_DeleteAll()
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using (EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}", this.DefaultContainerName, "territories_DeleteAll");
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    int count = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region entities_ResetId function imports
        /// <summary>
        /// There are no comments for TerritoriesModel.address_ResetId in the schema.
        /// </summary>
        public void addresses_ResetId(int newId)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                string cmdText = "SET GENERATOR G_ADDRESSESIDADDRESSESGEN0 TO " + newId;

                FbConnection con = ((FbConnection)((EntityConnection)(this.Connection)).StoreConnection);

                FbCommand cmd = new FbCommand(cmdText, con);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// There are no comments for TerritoriesModel.cities_ResetId in the schema.
        /// </summary>
        public void cities_ResetId(int newId)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                string cmdText = "SET GENERATOR G_CITIESIDCITYGEN1 TO " + newId;

                FbConnection con = ((FbConnection)((EntityConnection)(this.Connection)).StoreConnection);

                FbCommand cmd = new FbCommand(cmdText, con);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// There are no comments for TerritoriesModel.departments_ResetId in the schema.
        /// </summary>
        public void departments_ResetId(int newId)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                string cmdText = "SET GENERATOR G_DEPARTMENTSIDDEPARTMENTGEN2 TO " + newId;
                
                FbConnection con = ((FbConnection)((EntityConnection)(this.Connection)).StoreConnection);

                FbCommand cmd = new FbCommand(cmdText, con);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// There are no comments for TerritoriesModel.territories_ResetId in the schema.
        /// </summary>
        public void territories_ResetId(int newId)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                string cmdText = "SET GENERATOR G_TERRITORIESIDTERRITORYGEN3 TO " + newId;

                FbConnection con = ((FbConnection)((EntityConnection)(this.Connection)).StoreConnection);

                FbCommand cmd = new FbCommand(cmdText, con);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
