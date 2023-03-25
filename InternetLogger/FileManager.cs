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
                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(docPath))
                {
                    outputFile.WriteLine(line);
                }
                // Check if file already exists. If yes, delete it.     
                if (!File.Exists(docPath))
                {
                    FileStream fs = File.Create(docPath);
                }
                // Open the stream and read it back.    
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
