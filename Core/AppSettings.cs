using System.Configuration;

namespace Core
{

	public class AppSettings
	{

		#region Private Methods

		private static string GetValue(string Key)
		{
			string Value = ConfigurationManager.AppSettings[Key];
			if (!string.IsNullOrEmpty(Value)) {
				return Value;
			}
			return string.Empty;
		}

		private static string GetString(string Key, string DefaultValue = "")
		{
			string Setting = GetValue(Key);
			if (!string.IsNullOrEmpty(Setting)) {
				return Setting;
			}
			return DefaultValue;
		}

		private static bool GetBool(string Key, bool DefaultValue)
		{
			string Setting = GetValue(Key);
			if (!string.IsNullOrEmpty(Setting)) {
				switch (Setting.ToLower()) {
					case "false":
					case "0":
					case "n":
						return false;
					case "true":
					case "1":
					case "y":
						return true;
				}
			}
			return DefaultValue;
		}

		private static int GetInt(string Key, int DefaultValue)
		{
			string Setting = GetValue(Key);
			if (!string.IsNullOrEmpty(Setting)) {
                int i;
				if (int.TryParse(Setting, out i)) {
					return i;
				}
			}
			return DefaultValue;
		}

		private static double GetDouble(string Key, double DefaultValue)
		{
			string Setting = GetValue(Key);
			if (!string.IsNullOrEmpty(Setting)) {
                double d;
                if (double.TryParse(Setting, out d)) {
					return d;
				}
			}
			return DefaultValue;
		}

        private static byte GetByte(string Key, byte DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                byte b;
                if (byte.TryParse(Setting, out b))
                {
                    return b;
                }
            }
            
            return DefaultValue;
        }

		#endregion

		#region Public Properties

       

		#endregion

	}

}