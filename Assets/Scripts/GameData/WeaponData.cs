using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using SwordEnchant.Core;
using SwordEnchant.Util;

namespace SwordEnchant.Data
{
    public class WeaponData : BaseData
    {
        public WeaponClip[] weaponClips = new WeaponClip[0];

        private string xmlFilePath = "";
        private string xmlFileName = "weaponData.xml";
        private string dataPath = "Data/weaponData";

        private const string WEAPON = "weapon";
        private const string CLIP = "clip";

        private WeaponData() { }

        public void LoadData()
        {
            Debug.Log($"xmlFilePath = {Application.dataPath} + {dataDirectory}");
            xmlFilePath = Application.dataPath + dataDirectory;
            TextAsset asset = (TextAsset)ResourceManager.Load(dataPath);
            if (asset == null || asset.text == null)
            {
                AddData("New Weapon");
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
                                weaponClips = new WeaponClip[length];
                                break;
                            case "id":
                                currentID = int.Parse(reader.ReadString());
                                weaponClips[currentID] = new WeaponClip();
                                weaponClips[currentID].realID = currentID;
                                break;
                            case "name":
                                names[currentID] = reader.ReadString();
                                break;
                            case "weaponName":
                                weaponClips[currentID].weaponName = reader.ReadString();
                                break;
                            case "weaponPath":
                                weaponClips[currentID].weaponPath = reader.ReadString();
                                break;

                            case "damage":
                                weaponClips[currentID].damage = float.Parse(reader.ReadString());
                                break;
                            case "size":
                                weaponClips[currentID].size = float.Parse(reader.ReadString());
                                break;
                            case "speed":
                                weaponClips[currentID].speed = float.Parse(reader.ReadString());
                                break;
                            case "cooldown":
                                weaponClips[currentID].cooldown = float.Parse(reader.ReadString());
                                break;
                            case "count":
                                weaponClips[currentID].count = float.Parse(reader.ReadString());
                                break;
                            case "criticalProb":
                                weaponClips[currentID].criticalProb = float.Parse(reader.ReadString());
                                break;
                            case "criticalDamage":
                                weaponClips[currentID].criticalDamage = float.Parse(reader.ReadString());
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
                xml.WriteStartElement(WEAPON);
                xml.WriteElementString("length", GetDataCount().ToString());
                for (int i = 0; i < names.Length; i++)
                {
                    WeaponClip clip = weaponClips[i];
                    xml.WriteStartElement(CLIP);
                    xml.WriteElementString("id", i.ToString());
                    xml.WriteElementString("name", names[i]);
                    xml.WriteElementString("weaponName", clip.weaponName.ToString());
                    xml.WriteElementString("weaponPath", clip.weaponPath.ToString());

                    xml.WriteElementString("damage", clip.damage.ToString());
                    xml.WriteElementString("size", clip.size.ToString());
                    xml.WriteElementString("speed", clip.speed.ToString());
                    xml.WriteElementString("cooldown", clip.cooldown.ToString());
                    xml.WriteElementString("count", clip.count.ToString());
                    xml.WriteElementString("criticalProb", clip.criticalProb.ToString());
                    xml.WriteElementString("criticalDamage", clip.criticalDamage.ToString());
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
                weaponClips = new WeaponClip[] { new WeaponClip() };
            }
            else
            {
                names = ArrayHelper.Add(name, names);
                weaponClips = ArrayHelper.Add(new WeaponClip(), weaponClips);
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
            weaponClips = ArrayHelper.Remove(index, weaponClips);
        }

        public void ClearData()
        {
            foreach (WeaponClip clip in weaponClips)
            {
                clip.ReleaseMonster();
            }

            weaponClips = null;
            names = null;
        }

        public WeaponClip GetCopy(int index)
        {
            if (index < 0 || index >= weaponClips.Length)
            {
                return null;
            }
            WeaponClip original = weaponClips[index];
            WeaponClip clip = new WeaponClip();
            clip.weaponFullPath = original.weaponFullPath;
            clip.weaponName = original.weaponName;
            clip.weaponPath = original.weaponPath;
            clip.damage = original.damage;
            clip.size = original.size;
            clip.speed = original.speed;
            clip.cooldown = original.cooldown;
            clip.count = original.count;
            clip.criticalProb = original.criticalProb;
            clip.criticalDamage = original.criticalDamage;
            clip.realID = weaponClips.Length;
            return clip;
        }

        public WeaponClip GetClip(int index)
        {
            if (index < 0 || index >= weaponClips.Length)
            {
                return null;
            }
            weaponClips[index].PreLoad();
            return weaponClips[index];
        }

        public override void Copy(int index)
        {
            names = ArrayHelper.Add(names[index], names);
            weaponClips = ArrayHelper.Add(GetCopy(index), weaponClips);
        }
    }
}

