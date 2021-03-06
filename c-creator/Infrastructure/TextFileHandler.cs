﻿using System;
using System.Collections.Generic;
using System.IO;

namespace c_creator.Infrastructure
{
    public static class TextFileHandler
    {
        public static List<string> ReadTextFile(string fileName)
        {
            List<string> resList = new List<string>();

            using (var streamReader = File.OpenText(fileName))
            {
                var lines = streamReader.ReadToEnd().Split(',');
                foreach (var line in lines)
                {
                    resList.Add(line.Trim());
                }
            }
            return resList;
        }


        public static bool CreateTextFile(string path)
        {
            bool result = false;
            try
            {



                string fullPath; // = path + Settings.CtrlFileName;


                string[] args = Environment.GetCommandLineArgs();
                if (args.Length > 1 && args[1] != null)
                {
                    fullPath = Path.GetDirectoryName(path) + "\\" + Settings.CtrlFileName;
                }
                else
                {
                    fullPath = path + Settings.CtrlFileName;
                }

                

                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath).Close();
                }
                using (var tw = new StreamWriter(fullPath, false))
                {
                    string str = CtrlStringBuilder.BuildString();
                    tw.Write(str);
                    result = true;
                    Mediator.FullPath = fullPath;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
