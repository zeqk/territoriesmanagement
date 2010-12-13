using System;
using System.ComponentModel;

namespace TerritoriesManagement.GUI.ImporterConfig
{
	internal class FieldConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType )
		{
			if( destType == typeof(string) && value is Field )
			{
                // Cast the value to an Field type
                Field field = (Field)value;

				// Return department and department role separated by comma.
				return field.RelatedProperty;
			}
			return base.ConvertTo(context,culture,value,destType);
		}
	}

    // This is a special type converter which will be associated with the FieldCollection class.
    // It converts an FieldCollectionConverter object to a string representation for use in a property grid.
	internal class FieldCollectionConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType )
		{
			if( destType == typeof(string) && value is FieldCollection )
			{
				// Return department and department role separated by comma.
				return "Fields";
			}
			return base.ConvertTo(context,culture,value,destType);
		}
	}

}
