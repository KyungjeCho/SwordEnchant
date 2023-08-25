using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using SwordEnchant.Core;
using SwordEnchant.Util;
using System;


namespace SwordEnchant.Data
{
    public class CharacterData : BaseData
    {
        #region Variables
        public CharacterClip[] characterClips = new CharacterClip[0];

        private string xmlFilePath = "";
        private string xmlFileName = "characterData.xml";
        private string dataPath = "Data/characterData";

        private const string CHARACTER = "character";
        private const string CLIP = "clip";

        #endregion Variables
        private CharacterData() { }

        #region Load Data
        public void LoadData()
        {
            Debug.Log($"xmlFilePath = {Application.dataPath} + {dataDirectory}");
            xmlFilePath = Application.dataPath + dataDirectory;
            TextAsset asset = (TextAsset)ResourceManager.Load(dataPath);
            if (asset == null || asset.text == null)
            {
                AddData("New Character");
                return;
            }

            using (XmlTextReader reader = new XmlTextReader(new StringReader(asset.text)))
            {
                int currentID = 0;
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "length":
                                int length = int.Parse(reader.ReadString());
                                names = new string[length];
                                characterClips = new CharacterClip[length];
                                break;
                            case "id":
                                currentID = int.Parse(reader.ReadString());
                                characterClips[currentID] = new CharacterClip();
                                characterClips[currentID].realID = currentID;
                                break;
                            case "name":
                                names[currentID] = reader.ReadString();
                                break;
                            case "characterName":
                                characterClips[currentID].characterName = reader.ReadString();
                                break;
                            case "characterPath":
                                characterClips[currentID].characterPath = reader.ReadString();
                                break;
                            case "maxHp":
                                characterClips[currentID].maxHp = float.Parse(reader.ReadString());
                                break;
                            case "defence":
                                characterClips[currentID].defence = float.Parse(reader.ReadString());
                                break;
                            case "damage":
                                characterClips[currentID].damage = float.Parse(reader.ReadString());
                                break;
                            case "size":
                                characterClips[currentID].size = float.Parse(reader.ReadString());
                                break;
                            case "speed":
                                characterClips[currentID].speed = float.Parse(reader.ReadString());
                                break;
                            case "cooldown":
                                characterClips[currentID].cooldown = float.Parse(reader.ReadString());
                                break;
                            case "count":
                                characterClips[currentID].count = float.Parse(reader.ReadString());
                                break;
                            case "luck":
                                characterClips[currentID].luck = float.Parse(reader.ReadString());
                                break;
                            case "criticalProb":
                                characterClips[currentID].criticalProb = float.Parse(reader.ReadString());
                                break;
                            case "criticalDamage":
                                characterClips[currentID].criticalDamage = float.Parse(reader.ReadString());
                                break;

                            case "defaultWeapon":
                                characterClips[currentID].defaultWeapon = (WeaponList)Enum.Parse(typeof(WeaponList), reader.ReadString());
                                break;
                        }
                    }
                }
            }
        }
        #endregion Load Data

        #region Save Data
        public void SaveData()
        {
            using (XmlTextWriter xml = new XmlTextWriter(xmlFilePath + xmlFileName, System.Text.Encoding.Unicode))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement(CHARACTER);
                xml.WriteElementString("length", GetDataCount().ToString());
                for (int i = 0; i < names.Length; i++)
                {
                    CharacterClip clip = characterClips[i];
                    xml.WriteStartElement(CLIP);
                    xml.WriteElementString("id", i.ToString());
                    xml.WriteElementString("name", names[i]);
                    xml.WriteElementString("characterName", clip.characterName.ToString());
                    xml.WriteElementString("characterPath", clip.characterPath.ToString());

                    
                    xml.WriteElementString("maxHp", clip.maxHp.ToString());
                    xml.WriteElementString("defence", clip.defence.ToString());
                    xml.WriteElementString("damage", clip.damage.ToString());
                    xml.WriteElementString("size", clip.size.ToString());
                    xml.WriteElementString("speed", clip.speed.ToString());
                    xml.WriteElementString("cooldown", clip.cooldown.ToString());
                    xml.WriteElementString("count", clip.count.ToString());
                    xml.WriteElementString("luck", clip.luck.ToString());
                    xml.WriteElementString("criticalProb", clip.criticalProb.ToString());
                    xml.WriteElementString("criticalDamage", clip.criticalDamage.ToString());
                    xml.WriteElementString("defaultWeapon", clip.defaultWeapon.ToString());
                }
                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
        }
        #endregion Save Data

        #region Add Data
        public override int AddData(string newName)
        {
            if (names == null)
            {
                names = new string[] { name };
                characterClips = new CharacterClip[] { new CharacterClip() };
            }
            else
            {
                names = ArrayHelper.Add(name, names);
                characterClips = ArrayHelper.Add(new CharacterClip(), characterClips);
            }

            return GetDataCount();
        }
        #endregion Add Data

        #region Remove Data
        public override void RemoveData(int index)
        {
            names = ArrayHelper.Remove(index, names);
            if (names.Length == 0)
            {
                names = null;
            }
            characterClips = ArrayHelper.Remove(index, characterClips);
        }
        #endregion Remove Data

        #region Clear Data
        public void ClearData()
        {
            foreach (CharacterClip clip in characterClips)
            {
                clip.ReleaseMonster();
            }

            characterClips = null;
            names = null;
        }
        #endregion Clear Data

        #region Get Copy
        public CharacterClip GetCopy(int index)
        {
            if (index < 0 || index >= characterClips.Length)
            {
                return null;
            }
            CharacterClip original = characterClips[index];
            CharacterClip clip = new CharacterClip();
            clip.characterFullPath = original.characterFullPath;
            clip.characterName = original.characterName;
            clip.characterPath = original.characterPath;

            clip.maxHp = original.maxHp;
            clip.defence = original.defence;
            clip.damage = original.damage;
            clip.size = original.size;
            clip.speed = original.speed;
            clip.cooldown = original.cooldown;
            clip.count = original.count;
            clip.luck = original.luck;
            clip.criticalProb = original.criticalProb;
            clip.criticalDamage = original.criticalDamage;

            clip.realID = characterClips.Length;
            return clip;
        }
        #endregion Get Copy

        #region Get Clip
        public CharacterClip GetClip(int index)
        {
            if (index < 0 || index >= characterClips.Length)
            {
                return null;
            }
            characterClips[index].PreLoad();
            return characterClips[index];
        }
        #endregion Get Clip

        #region Copy
        public override void Copy(int index)
        {
            names = ArrayHelper.Add(names[index], names);
            characterClips = ArrayHelper.Add(GetCopy(index), characterClips);
        }
        #endregion Copy
    }

}
