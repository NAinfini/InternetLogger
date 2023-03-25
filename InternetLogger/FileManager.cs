using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetLogger
{
    internal class FileManager
    {
        public void addToFIle(string fileName, string line)
        {
            try
            {
                string docPath = Directory.GetCurrentDirectory();
                docPath = Path.Combine(docPath, fileName);   
                if (!File.Exists(docPath))
                {
                    FileStream fs = File.Create(docPath);
                }   
                using (StreamWriter st = File.AppendText(docPath))
                {
                    st.WriteLine(line);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }
    }
}
