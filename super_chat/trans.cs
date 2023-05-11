using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace super_chat
{
    class trans 
    {
        public string tran_insert(string path) //返回16进制数
        {
            string filePath = path;
            byte[] binaryData = File.ReadAllBytes(filePath);

            string hexString = BitConverter.ToString(binaryData).Replace("-", "");
            return hexString;//返回16进制数
        }
        public string restore(string hexString ,string type)//由转化成文件并返回文件路径
        {
            byte[] data = new byte[hexString.Length / 2];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            //随机生成一个命名
            Random ran = new Random();
            int n = ran.Next(1000000, 99999999);
            string pat1 = n.ToString();
            string type1 = "."+type;
            // 从二进制数据中恢复原始文件
            string restoredFilePath = @"D:\桌面\chat_os\fileorpicture\" + pat1 + type1;
            File.WriteAllBytes(restoredFilePath, data);

            return restoredFilePath;//返回接收到的文件路径
        }
    }
}
