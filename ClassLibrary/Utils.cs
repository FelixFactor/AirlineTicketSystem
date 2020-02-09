using System;

namespace ClassLibrary
{
    public static class Utils
    {
        /// <summary>
        /// version 2.0 
        /// </summary>
        /// <param name="local"></param>
        /// <returns>upper casing the 1st letter of each string if user doesn't inputed right</returns>
        public static string UpperCase(string local)
        {
            string[] splited = local.Trim().Split(' ');
            string city = "";
            for (int i = 0; i < splited.Length; i++)
            {
                splited[i] = TurnUpperCase(splited[i]);
                city += $" {splited[i]}";
            }
            return city.Trim();
            //try
            //{
            //    string loca = TurnUpperCase(splited[0]);
            //    string tion = TurnUpperCase(splited[1]);
            //    return loca + " " + tion;
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    return TurnUpperCase(local);
            //}
        }
        static private string TurnUpperCase(string local)
        {
            char[] splat = local.ToCharArray();
            try
            {
                splat[0] = char.ToUpper(splat[0]);
            }
            catch (IndexOutOfRangeException)
            {
                string unknown = "Unknown";
                TurnUpperCase(unknown);
            }
            return new string(splat);
        }
    }
}
