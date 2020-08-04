using Newtonsoft.Json;
using System.IO;

namespace Myntra.Reader
{
    public class JsonReader
    {
        public string email = "";
        public string password = "";
        public string json = "";

        public JsonReader()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\Shivani\\Desktop\\Backup\\credentials.json"))
            {
                json = r.ReadToEnd();
            }
            dynamic array = JsonConvert.DeserializeObject(json);
            email = array["email"];
            password = array["password"];
        }
    }
}
