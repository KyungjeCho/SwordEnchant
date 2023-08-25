using SwordEnchant.Core;
using SwordEnchant.Util;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace SwordEnchant.Data
{
    public class MonsterData : BaseData
    {
        public MonsterClip[] monsterClips = new MonsterClip[0];

        private string xmlFilePath = "";
        private string xmlFileName = "monsterData.xml";
        private string dataPath = "Data/monsterData";

        private const string MONSTER = "monster";
        private const string CLIP = "clip";

        private MonsterData() { }

        public void LoadData()
        {
            Debug.Log($"xmlFilePath = {Application.dataPath} + {dataDirectory}");
            xmlFilePath = Application.dataPath + dataDirectory;
            TextAsset asset = (TextAsset)ResourceManager.Load(dataPath);
            if (asset == null || asset.text == null)
            {
                AddData("New Monster");
                return;
            }

            using (XmlTextReader reader = new XmlTextReader(new StringReader(asset.text)))
            {
                int currentID = 0;
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch(reader.Name)
                        {
                            case "length":
                                int length = int.Parse(reader.ReadString());
                                names = new string[length];
                                monsterClips = new MonsterClip[length];
                                break;
                            case "id":
                                currentID = int.Parse(reader.ReadString());
                                monsterClips[currentID] = new MonsterClip();
                                monsterClips[currentID].realID = currentID;
                                break;
                            case "name":
                                names[currentID] = reader.ReadString();
                                break;
                            case "monsterName":
                                monsterClips[currentID].monsterName = reader.ReadString();
                                break;
                            case "monsterPath":
                                monsterClips[currentID].monsterPath = reader.ReadString();
                                break;

                            case "health":
                                monsterClips[currentID].health = float.Parse(reader.ReadString());
                                break;
                            case "speed":
                                monsterClips[currentID].speed = float.Parse(reader.ReadString());
                                break;
                            case "damage":
                                monsterClips[currentID].damage = float.Parse(reader.ReadString());
                                break;
                            case "defence":
                                monsterClips[currentID].defence = float.Parse(reader.ReadString());
                                break;
                            case "size":
                                monsterClips[currentID].size = float.Parse(reader.ReadString());
                                break;
                        }
                    }
                }
            }
        }

        public void SaveData()
        {
            using (XmlTextWriter xml = new XmlTextWriter(xmlFilePath + xmlFileName, System.Text.Encoding.Unicode))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement(MONSTER);
                xml.WriteElementString("length", GetDataCount().ToString());
                for (int i = 0; i < names.Length; i++)
                {
                    MonsterClip clip = monsterClips[i];
                    xml.WriteStartElement(CLIP);
                    xml.WriteElementString("id", i.ToString());
                    xml.WriteElementString("name", names[i]);
                    xml.WriteElementString("monsterName", clip.monsterName.ToString());
                    xml.WriteElementString("monsterPath", clip.monsterPath.ToString());
                    xml.WriteElementString("health", clip.health.ToString());
                    xml.WriteElementString("speed", clip.speed.ToString());
                    xml.WriteElementString("damage", clip.damage.ToString());
                    xml.WriteElementString("defence", clip.defence.ToString());
                    xml.WriteElementString("size", clip.size.ToString());
                }
                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
        }

        public override int AddData(string newName)
        {
            if (names == null)
            {
                names = new string[] { name };
                monsterClips = new MonsterClip[] { new MonsterClip() };
            }
            else
            {
                names = ArrayHelper.Add(name, names);
                monsterClips = ArrayHelper.Add(new MonsterClip(), monsterClips);
            }

            return GetDataCount();
        }

        public override void RemoveData(int index)
        {
            names = ArrayHelper.Remove(index, names);
            if (names.Length == 0)
            {
                names = null;
            }
            monsterClips = ArrayHelper.Remove(index, monsterClips);
        }

        public void ClearData()
        {
            foreach(MonsterClip clip in monsterClips)
            {
                clip.ReleaseMonster();
            }

            monsterClips = null;
            names = null;
        }

        public MonsterClip GetCopy(int index)
        {
            if (index < 0 || index >= monsterClips.Length)
            {
                return null;
            }
            MonsterClip original = monsterClips[index];
            MonsterClip clip = new MonsterClip();
            clip.monsterFullPath = original.monsterFullPath;
            clip.monsterName = original.monsterName;
            clip.monsterPath = original.monsterPath;
            clip.health = original.health;
            clip.speed = original.speed;
            clip.damage = original.damage;
            clip.defence = original.defence;
            clip.size = original.size;
            clip.realID = monsterClips.Length;
            return clip;
        }

        public MonsterClip GetClip(int index)
        {
            if (index < 0 || index >= monsterClips.Length)
            {
                return null;
            }
            monsterClips[index].PreLoad();
            return monsterClips[index];
        }

        public override void Copy(int index)
        {
            names = ArrayHelper.Add(names[index], names);
            monsterClips = ArrayHelper.Add(GetCopy(index), monsterClips);
        }
    }
}

