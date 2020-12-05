using System;
using System.IO;

namespace Common
{
    public static class FileHelpers
    {
        public static string[] ReadLines(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception)
            {
                return new string[] { };
            }
        }
    }
}
