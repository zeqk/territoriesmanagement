using System;
using System.Text;
using System.ComponentModel;

namespace TerritoriesManagement.GUI.Interop.Import
{
	/// <summary>
	/// Summary description for CollectionPropertyDescriptor.
	/// </summary>
	public class FiedCollectionPropertyDescriptor : PropertyDescriptor
	{
		private FieldCollection collection = null;
		private int index = -1;

        public FiedCollectionPropertyDescriptor(FieldCollection coll, int idx) : 
			base( "#"+idx.ToString(), null )
		{
			this.collection = coll;
			this.index = idx;
		} 

		public override AttributeCollection Attributes
		{
			get 
			{ 
				return new AttributeCollection(null);
			}
		}

		public override bool CanResetValue(object component)
		{
			return true;
		}

		public override Type ComponentType
		{
			get 
			{ 
				return this.collection.GetType();
			}
		}

		public override string DisplayName
		{
			get 
			{
				Field field = this.collection[index];
                string import = "";
                if (field.Import)
                    import = "Import";
                else
                    import = "Not import";
                return field.RelatedProperty + " | " + import;
			}
		}

		public override string Description
		{
			get
			{
				Field field = this.collection[index]; 
				StringBuilder sb = new StringBuilder();
                sb.Append("Description: " +field.RelatedProperty);
			
				return sb.ToString();
			}
		}

		public override object GetValue(object component)
		{
			return this.collection[index];
		}

		public override bool IsReadOnly
		{
			get { return false;  }
		}

		public override string Name
		{
			get { return "#"+index.ToString(); }
		}

		public override Type PropertyType
		{
			get { return this.collection[index].GetType(); }
		}

		public override void ResetValue(object component)
		{
		}

		public override bool ShouldSerializeValue(object component)
		{
			return true;
		}

		public override void SetValue(object component, object value)
		{
			// this.collection[index] = value;
		}
	}
}
