using System;
using System.Xml;
using System.Drawing;

namespace WallChange
{
	/// <summary>
	/// save the setting in xml file
	/// </summary>
	public class Settings
	{
		public string m_settingsPath;
		private Setting form;
		public Settings(string localpath, Setting form)
		{
			m_settingsPath = localpath;
			this.form = form;

		}
		
		#region save and load default values
		/// <summary>
		/// save the setting to xml file
		/// </summary>
		public void SaveSettings()
		{
			int tempPicIndex =  form.picIndex;
			int tempGlobalInterval = form.GlobalInterval;
            string tempUserName = form.UserName;
            bool tempIsRandom = form.isRandom;
            int tempIntervalIndex = form.IntervalIndex;
			
			XmlTextWriter writer = new XmlTextWriter(m_settingsPath + "\\settings.xml", null);
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 4;
			writer.WriteComment("Settings for WallPaper changer program");
			writer.WriteStartElement("settings");

			writer.WriteElementString("picIndex", tempPicIndex.ToString());
			writer.WriteElementString("Interval", tempGlobalInterval.ToString());
            writer.WriteElementString("UserName", tempUserName.ToString());
            writer.WriteElementString("IsRandom", tempIsRandom.ToString());
            writer.WriteElementString("IntervalIndex", tempIntervalIndex.ToString());
			
			writer.WriteEndElement();
			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// load the setting from xml file to the application
		/// </summary>
		public void LoadSettings()
		{
			XmlTextReader reader = null;
			string elementName = null;
			try
			{
				reader = new XmlTextReader(m_settingsPath + "\\settings.xml");
				reader.WhitespaceHandling = WhitespaceHandling.None;

				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element)
						elementName = reader.Name;
					if (reader.NodeType == XmlNodeType.Text)
					{
						switch (elementName)
						{
							case "picIndex": 
                                form.picIndex = Int32.Parse(reader.Value);  break;
							case "Interval": 
                                form.GlobalInterval = Int32.Parse(reader.Value);  
                                break;
                            case "UserName": 
                                form.UserName = reader.Value.ToString(); break;
                            case "IsRandom":
                                form.isRandom = bool.Parse(reader.Value);
                                break;
                            case "IntervalIndex":
                                form.IntervalIndex = Int32.Parse(reader.Value);
                                break;
							
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}

			if (reader != null)
				reader.Close();
		}
		#endregion


	
	}

}