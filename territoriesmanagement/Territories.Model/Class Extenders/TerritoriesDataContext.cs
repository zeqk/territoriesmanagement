﻿using System;
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

namespace Territories.Model
{
    public partial class TerritoriesDataContext
    {
        public void Update(EntityObject objectDetached)
        {
            if (objectDetached.EntityState == EntityState.Detached)
            {
                object currentEntityInDb = null;
                if (this.TryGetObjectByKey(objectDetached.EntityKey, out currentEntityInDb))
                {
                    this.ApplyPropertyChanges(objectDetached.EntityKey.EntitySetName, objectDetached);
                    //(CDLTLL)Apply property changes to all referenced entities in context
                    this.ApplyReferencePropertyChanges((IEntityWithRelationships)objectDetached,
                                                                                        (IEntityWithRelationships)currentEntityInDb); //Custom extensor method
                }
                else
                {
                    throw new ObjectNotFoundException();
                }
            }
        }

        public void ApplyReferencePropertyChanges(IEntityWithRelationships newEntity,
            IEntityWithRelationships oldEntity)
        {
            foreach (var relatedEnd in oldEntity.RelationshipManager.GetAllRelatedEnds())
            {
                var oldRef = relatedEnd as EntityReference;
                if (oldRef != null)
                {
                    
                    // this related end is a reference not a collection
                    var newRef = newEntity.RelationshipManager.GetRelatedEnd(oldRef.RelationshipName, oldRef.TargetRoleName) as EntityReference;

                    oldRef.EntityKey = newRef.EntityKey;
                }
            }
        }


        public void SetAllModified<T>(T entity) where T : IEntityWithKey
        {

            var stateEntry = this.ObjectStateManager.GetObjectStateEntry(entity.EntityKey);

            var propertyNameList = stateEntry.CurrentValues.DataRecordInfo.FieldMetadata.Select(pn => pn.FieldType.Name);

            foreach (var propName in propertyNameList)
            {

                stateEntry.SetModifiedProperty(propName);

            }

        }

        public void DetachByKey(EntityKey key)
        {
            Object entity;
            if (this.TryGetObjectByKey(key,out entity))
            {
                this.Detach(entity);
            }
            
        }


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
        /// There are no comments for TerritoriesModel.directions_AddWithPK in the schema.
        /// </summary>
        public Collection<Int32> directions_AddWithPK(Direction v)
        {
            Collection<Int32> rv = new Collection<int>();

            try
            {
                using (EntityConnection conn = new EntityConnection(this.Connection.ConnectionString))
                {
                    EntityCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("{0}.{1}", this.DefaultContainerName, "directions_AddWithPK");
                    cmd.CommandType = CommandType.StoredProcedure;

                    EntityParameter idParam = new EntityParameter("id", DbType.Int32);
                    idParam.Value = v.IdDirection;
                    cmd.Parameters.Add(idParam);

                    EntityParameter streetParam = new EntityParameter("street", DbType.String);
                    streetParam.Value = v.Street;
                    cmd.Parameters.Add(streetParam);

                    EntityParameter numParam = new EntityParameter("number", DbType.Int32);
                    numParam.Value = v.Number;
                    cmd.Parameters.Add(numParam);

                    EntityParameter corner1Param = new EntityParameter("corner1", DbType.String);
                    corner1Param.Value = v.Corner1;
                    cmd.Parameters.Add(corner1Param);

                    EntityParameter corner2Param = new EntityParameter("corner2", DbType.String);
                    corner2Param.Value = v.Corner2;
                    cmd.Parameters.Add(corner2Param);

                    EntityParameter descParam = new EntityParameter("description", DbType.String);
                    descParam.Value = v.Description;
                    cmd.Parameters.Add(descParam);

                    EntityParameter phone1Param = new EntityParameter("phone1", DbType.String);
                    phone1Param.Value = v.Phone1;
                    cmd.Parameters.Add(phone1Param);

                    EntityParameter phone2Param = new EntityParameter("phone2", DbType.String);
                    phone2Param.Value = v.Phone2;
                    cmd.Parameters.Add(phone2Param);

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

        private int? ExtractCityId(Direction v)
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

        private int? ExtractTerritoryId(Direction v)
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

    }
}