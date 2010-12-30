using System;
using System.Collections;
using System.ComponentModel;

namespace TerritoriesManagement.GUI.Interop.Import
{
	/// <summary>
	/// Type safe collection class for Employee objects. Extends the base class 
	/// CollectionBase to inherit base collection functionality.
	/// Implementation of ICustomTypeDescvriptor to provide customized type description.
	/// </summary>
	public class FieldCollection : CollectionBase, ICustomTypeDescriptor
	{
		#region collection impl		

		public void Add( Field field )
		{
            this.List.Add(field);
		}
        public void Remove(Field field)
		{
            this.List.Remove(field);
		}
		public Field this[ int index ] 
		{
			get
			{
                return (Field)this.List[index];
			}
		}

		#endregion

		// Implementation of interface ICustomTypeDescriptor 
		#region ICustomTypeDescriptor impl 

		public String GetClassName()
		{
			return TypeDescriptor.GetClassName(this,true);
		}

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this,true);
		}

		public String GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		public EventDescriptor GetDefaultEvent() 
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		public PropertyDescriptor GetDefaultProperty() 
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		public object GetEditor(Type editorBaseType) 
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes) 
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		public object GetPropertyOwner(PropertyDescriptor pd) 
		{
			return this;
		}


		/// <summary>
		/// Called to get the properties of this type. Returns properties with certain
		/// attributes. this restriction is not implemented here.
		/// </summary>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return GetProperties();
		}

		/// <summary>
		/// Called to get the properties of this type.
		/// </summary>
		/// <returns></returns>
		public PropertyDescriptorCollection GetProperties()
		{
			// Create a collection object to hold property descriptors
			PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);

			// Iterate the list of employees
			for( int i=0; i<this.List.Count; i++ )
			{
				// Create a property descriptor for the employee item and add to the property descriptor collection
                FiedCollectionPropertyDescriptor pd = new FiedCollectionPropertyDescriptor(this, i);
				pds.Add(pd);
			}
			// return the property descriptor collection
			return pds;
		}

		#endregion
	}
}