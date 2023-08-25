using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Util
{
    public static class NameListHelper
    { 
        public static string[] DictionaryToNameList<T>(Dictionary<string, T> dict)
        {
            string[] retList = new string[0];

            if (dict.Count <= 0)
            {
                return retList;
            }

            retList = new string[dict.Count];
            int i = 0;
            foreach (KeyValuePair<string, T> entry in dict)
            {
                retList[i] = entry.Key;
                i++;
            }

            return retList;
        }
    }
}

