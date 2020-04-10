using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CookBook.Ch2
{
    public static class EX205
    {
        static void SerializeToFile<T> (T obj, string dataFile)
        {
            using(FileStream fs = File.Create(dataFile))
            {
                BinaryFormatter binSerializer = new BinaryFormatter();
                binSerializer.Serialize(fs, obj);
            }
        }

        static T DeserializeFromFile<T>(string dataFile)
        {
            T obj = default(T);

            using(FileStream fs = File.OpenRead(dataFile))
            {
                BinaryFormatter binSerializer = new BinaryFormatter();
                obj = (T)binSerializer.Deserialize(fs);
            }

            return obj;
        }

        static byte[] Serialize<T>(T obj)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binSerializer = new BinaryFormatter();
                binSerializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        static T Deserialize<T>(byte[] serializedObj)
        {
            T obj = default(T);

            using(MemoryStream ms = new MemoryStream(serializedObj))
            {
                BinaryFormatter binSerializer = new BinaryFormatter();
                obj = (T)binSerializer.Deserialize(ms);
            }

            return obj;
        }

        public static void Run()
        {
            ArrayList ht = new ArrayList() { "Zero", "One", "Two" };

            foreach (object obj in ht)
            {
                Console.WriteLine(obj.ToString());
            }

            //serialize
            SerializeToFile<ArrayList>(ht, "HT.data");

            //deserialize
            ArrayList htNew = new ArrayList();
            htNew = DeserializeFromFile<ArrayList>("HT.data");

            foreach (object obj in ht)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
