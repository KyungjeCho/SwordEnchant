using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    public class MonsterData : BaseData
    {
        public MonsterClip[] monsterClips = new MonsterClip[0];

        private string xmlFilePath = "";
        private string xmlFileNAme = "monsterData.xml";
        private string dataPath = "Data/monsterData";

        private const string MONSTER = "monster";
        private const string CLIP = "clip";

        private MonsterData() { }

        public void LoadData()
        {
            Debug.Log($"xmlFilePath = {Application.dataPath} + {dataDirectory}");
            xmlFilePath = Application.dataPath + dataDirectory;
            //TextAsset asset = (TextAsset)ResourceManager.Load(dataPath);
            
        }
    }
}

