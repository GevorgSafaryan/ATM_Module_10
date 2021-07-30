using Design_Patterns.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Utils
{
    public static class JsonConvertor
    {
        public static TestData GetTestData()
        {
            if (File.Exists(@"D:\ATM_Module_10\Design_Patterns\Utils\TestData.json"))
            {
                string data = File.ReadAllText(@"D:\ATM_Module_10\Design_Patterns\Utils\TestData.json");
                return JsonConvert.DeserializeObject<TestData>(data);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static List<Users> GetUser()
        {
            if (File.Exists(@"D:\ATM_Module_10\Design_Patterns\Utils\Users.json"))
            {
                string data = File.ReadAllText(@"D:\ATM_Module_10\Design_Patterns\Utils\Users.json");
                return JsonConvert.DeserializeObject<List<Users>>(data);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static IEnumerable<Users> ReturnUsers()
        {
            if (File.Exists(@"D:\ATM_Module_10\Design_Patterns\Utils\Users.json"))
            {
                string data = File.ReadAllText(@"D:\ATM_Module_10\Design_Patterns\Utils\Users.json");
                List<Users> users = JsonConvert.DeserializeObject<List<Users>>(data);
                for (int i = 3; i < users.Count; i++)
                {
                    yield return users[i];
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
