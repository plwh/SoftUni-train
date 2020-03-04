﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.Utilities
{
    public class StringUtility
    {
        public static string Capitalize(string text)
        {
            StringBuilder result = new StringBuilder();

            if(!string.IsNullOrEmpty(text))
            {
                result.Append(char.ToUpper(text[0]));

                for (int i = 1; i < text.Length; i++)
                {
                    result.Append(char.ToLower(text[i]));
                }
            }

            return result.ToString();
        }
    }
}
