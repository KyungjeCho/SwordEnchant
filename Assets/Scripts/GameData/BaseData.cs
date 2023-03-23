using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    /// <summary>
    /// Data의 기본 클래스입니다.
    /// </summary>
    public class BaseData : ScriptableObject
    {
        #region Variables
        public const string dataDirectory = "/Resources/Data/";
        public string[] names = null;
        #endregion Variables

        public BaseData() { }

        public int GetDataCount()
        {
            if (names == null)
                return 0;
            else
                return names.Length;
        }

        public string[] GetNameList(bool showID, string filterWord = "")
        {
            string[] retList = new string[0];

            if (names == null)
            {
                return retList;
            }

            retList = new string[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                if (filterWord != "")
                {
                    if (names[i].ToLower().Contains(filterWord.ToLower()))
                    {
                        continue;
                    }
                }
                if (showID)
                {
                    retList[i] = i.ToString() + " : " + this.names[i];
                }
                else
                {
                    retList[i] = this.names[i];
                }
            }
            return retList;
        }

        public virtual int AddData(string newName)
        {
            return GetDataCount();
        }

        public virtual void RemoveData(int index)
        {

        }

        public virtual void Copy(int index)
        {

        }
    }
}

