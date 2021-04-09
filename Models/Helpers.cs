using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FagElGamous.Models
{
    public class Helpers
    {
		public static string GetRDSConnectionString()
		{
			//var appConfig = ConfigurationManager.AppSettings;

			//string dbname = appConfig["ebdb"];

			////if (string.IsNullOrEmpty(dbname)) return null;

			//string username = appConfig["group39"];
			//string password = appConfig["waterbuffalo"];
			//string hostname = appConfig["aahkjatd0ed4k6.cfnfj41p2t7z.us-east-1.rds.amazonaws.com"];
			//string port = appConfig["1433"];

			//return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
			return "Data Source=aahkjatd0ed4k6.cfnfj41p2t7z.us-east-1.rds.amazonaws.com;Initial Catalog=FagElGamous;User ID=group39;Password=waterbuffalo;";
		}
	}
}
