using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    public class FieldConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (ReferenceEquals(sourceType, typeof(string)))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (ReferenceEquals(destinationType, typeof(Field)))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (object.ReferenceEquals(destinationType, typeof(string)) && value is Field)
            {
                Field t;
                if (value == null)
                    t = new Field();
                else
                    t = (Field)value;

                string rv = t.Import.ToString();

                return rv;

            }

            return base.ConvertTo(context, culture, value, destinationType);

        }
    }
}
