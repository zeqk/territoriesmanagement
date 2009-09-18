﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Territories.GUI.ImporterConfig
{
    public class DirectionsTableConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (ReferenceEquals(sourceType, typeof(string)))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (ReferenceEquals(destinationType, typeof(DirectionsTable)))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (object.ReferenceEquals(destinationType, typeof(string)) && value is DirectionsTable)
            {
                DirectionsTable t;
                if (value == null)
                    t = new DirectionsTable();
                else
                    t = (DirectionsTable)value;

                string rv = t.Load.ToString();

                return rv;

            }

            return base.ConvertTo(context, culture, value, destinationType);

        }
    }
}