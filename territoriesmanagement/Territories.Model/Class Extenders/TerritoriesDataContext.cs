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
        public void UpdateTo(string entitySetName, EntityObject o)
        {
            EntityKey key = this.CreateEntityKey(entitySetName, o);
            Object originalItem;

            if (this.TryGetObjectByKey(key, out originalItem))
            {
                this.ApplyPropertyChanges(key.EntitySetName, o);

                foreach (var entityrelationship in ((IEntityWithRelationships)originalItem).RelationshipManager.GetAllRelatedEnds())
                {
                    var oldRef = entityrelationship as EntityReference;

                    if (oldRef != null)
                    {
                        var newRef = ((IEntityWithRelationships)o).RelationshipManager.GetRelatedEnd(oldRef.RelationshipName, oldRef.TargetRoleName) as EntityReference;
                        oldRef = newRef;
                    }
                }
            }
        }  
    }
}
