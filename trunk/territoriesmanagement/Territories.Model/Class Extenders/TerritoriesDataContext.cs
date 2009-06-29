using System;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// There are no comments for TerritoriesModel.departments_GetById in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectResult<Department> departments_AddWithPK(int? id,string name)
        {
            global::System.Data.Objects.ObjectParameter idParameter;
            ObjectParameter nameParamenter;
            if (id.HasValue)
            {
                idParameter = new global::System.Data.Objects.ObjectParameter("id", id);
            }
            else
            {
                idParameter = new global::System.Data.Objects.ObjectParameter("id", typeof(int));
            }

            if (!string.IsNullOrEmpty(name))
            {
                nameParamenter = new global::System.Data.Objects.ObjectParameter("name", name);
            }
            else
            {
                nameParamenter = new global::System.Data.Objects.ObjectParameter("name", typeof(string));
            }

            return base.ExecuteFunction<Department>("departments_AddWithPK", idParameter);
        }

    }
}
