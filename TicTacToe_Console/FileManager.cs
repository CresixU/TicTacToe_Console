using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TicTacToe_Console
{
    public static class FileManager
    {
        private static string _path = @"data.json";

        public static void SaveData(List<Player> list)
        {
            CreateFileIfNotExist(_path);
            
            if(!_path.EndsWith(".json"))
            {
                Console.WriteLine("File should be json type");
                return;
            }

            string serialize = JsonConvert.SerializeObject(list);

            File.WriteAllText(_path, serialize);
        }

        public static List<Player> LoadData()
        {
            List<Player> list = new List<Player>();
            if (!File.Exists(_path)) return list;
            if (IsFileEmpty(_path)) return list;
            if (!_path.EndsWith(".json")) return list;

            list = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText(_path));
            Console.WriteLine("Data loaded");

            return list;
        }

        private static void CreateFileIfNotExist(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (File.Create(path)) { };
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }  
        }

        private static bool IsFileEmpty(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Length > 2)
                return false;

            return true;
        }
    }
}
