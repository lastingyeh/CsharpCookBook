using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CookBook.Ch1._1_7
{
    [Serializable]
    public class DeepClone : IDeepCopy<DeepClone>
    {
        public int data = 1;
        public List<string> ListData = new List<string>();
        public object objData = new object();
        public DeepClone DeepCopy()
        {
            BinaryFormatter BF = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            BF.Serialize(memStream, this);
            memStream.Flush();
            memStream.Position = 0;

            return (DeepClone)BF.Deserialize(memStream);
        }
    }
}
