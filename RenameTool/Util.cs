﻿using System.IO;
using System.Text;

namespace RenameTool
{
    public class Util
    {
        public static Encoding GetEncoding(string fileName)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(fileName, FileMode.Open))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            if (bom[0] == 117 && bom[1] == 115 && bom[2] == 105 && bom[3] == 110) return System.Text.Encoding.GetEncoding("gb2312");//增加gb2312编码处理
            return Encoding.ASCII;
        }
    }
}
