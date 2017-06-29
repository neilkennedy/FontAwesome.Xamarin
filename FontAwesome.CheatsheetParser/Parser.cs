using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace FontAwesome.CheatsheetParser
{
    internal class Parser
    {
        private static Regex Regex = new Regex(@".fa-(?<name>[\w-]+):before\s\{\s*content:\s*\""\\f(?<value>[0-9a-z]{3,})\"";\s*\}", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        internal void DoMagic()
        {
            var url = "http://fontawesome.io/cheatsheet/";

            var http = WebRequest.CreateHttp(url);
            http.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.1";
            http.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var response = http.GetResponse();
            string html = null;
            using (var stream = response.GetResponseStream())
                html = new StreamReader(stream).ReadToEnd();

            // parse...
            var path = Path.GetTempFileName() + ".txt";
            using (var writer = new StreamWriter(path))
            {
                var matches = Regex.Matches(html);
                foreach (Match match in matches)
                {
                    var name = match.Groups["name"].Value;
                    var value = match.Groups["value"].Value;

                    Console.WriteLine(name);

                    writer.Write("public static string ");
                    writer.Write(this.FixupName(name));
                    writer.Write(" = \"\\uf");
                    writer.Write(value);
                    writer.WriteLine("\";");
                }
            }

            Process.Start(path);
        }

        private string FixupName(string name)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("FA");

            var upper = true;
            foreach (var c in name)
            {
                if (upper)
                {
                    builder.Append(char.ToUpper(c));
                    upper = false;
                }
                else if (c == '-')
                    upper = true;
                else
                    builder.Append(c);
            }

            return builder.ToString();
        }
    }
}