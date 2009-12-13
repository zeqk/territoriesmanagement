using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Resources;

namespace ZeqkTools.Internationalization
{
	
	
    public class Globalization
    {
        private CultureInfo _culture;


        public Globalization()
        {
            _culture = new CultureInfo("en-US");
        }

        public Globalization(string cultureStr)
        {
            _culture = new CultureInfo(cultureStr);
        }

        public CultureInfo Culture
        {
            get { return _culture; }
            set { _culture = value; }
        }
	


        public string GetString(Type type, string text)
        {
            string resourceStr = type.Namespace + ".Internacionalization." + type.Name;

            ResourceManager rm = new ResourceManager(resourceStr, type.Assembly);

            return rm.GetString(text, _culture);

        }

    }
}
