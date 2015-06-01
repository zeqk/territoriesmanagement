static void ImportXML(Stream stream)
{
	try
	{
		using(var reader = XmlReader.Create(stream))
		{
			var doc = XDocument.Load(reader);
			var territories = doc.Element("Territories").Elements();
			foreach (var t in territories)
			{
				var label = t.Element("Label").Value;
				var nuimber = t.Element("Number").Value;
				var area = t.Element("Geoarea").Value;
				var houses = t.Element("Houses").Elements();
				//do something

				foreach (var h in houses)
				{
					var address = h.Element("Address").Value;
					var street = h.Element("Street").Value;
					var note = h.Element("Note").Value;
					var lat = h.Element("Geoposition").Element("Lat").Value;
					var lng = h.Element("Geoposition").Element("Lng").Value;
					var hlabel = h.Element("Label").Value;
					//do something
				}
			}
		}    

	}
	catch (Exception ex)
	{                
		throw ex;
	}
}