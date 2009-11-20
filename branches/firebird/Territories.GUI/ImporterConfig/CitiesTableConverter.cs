using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    public class CitiesTableConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (ReferenceEquals(sourceType, typeof(string)))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (ReferenceEquals(destinationType, typeof(CitiesTable)))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (object.ReferenceEquals(destinationType, typeof(string)) && value is CitiesTable)
            {
                CitiesTable t;
                if (value == null)
                    t = new CitiesTable();
                else
                    t = (CitiesTable)value;

                string rv = t.Import.ToString();

                return rv;

            }

            return base.ConvertTo(context, culture, value, destinationType);

        }
    }
}
