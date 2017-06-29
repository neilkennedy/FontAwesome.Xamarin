using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontAwesome.CheatsheetParser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Parser().DoMagic();
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (Debugger.IsAttached)
                    Console.ReadLine();
            }
        }
    }
}
