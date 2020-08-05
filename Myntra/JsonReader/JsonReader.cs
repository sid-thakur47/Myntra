//-----------------------------------------------------------------------
// <copyright file="JsonReader.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System.IO;

namespace Myntra.Reader
{
    /// <summary>
    /// Json file reader
    /// </summary>
    public class JsonReader
    {
        public string email;
        public string password;
        public string json;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReader"/> class
        /// </summary>
        public JsonReader()
        {
            using (StreamReader reader = new StreamReader("C:\\Users\\Shivani\\Desktop\\Backup\\credentials.json"))
            {
                json = reader.ReadToEnd();
            }
            dynamic array = JsonConvert.DeserializeObject(json);
            email = array["email"];
            password = array["password"];
        }
    }
}