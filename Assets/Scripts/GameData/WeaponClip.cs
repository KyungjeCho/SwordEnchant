using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Data
{
    public class WeaponClip
    {
        public int realID = 0;

        public string weaponName        = string.Empty;
        public string weaponPath        = string.Empty;
        public string weaponFullPath    = string.Empty;

        public float damage;
        public float size;
        public float speed;
        public float cooldown;
        public float count;         // ����ü ���ⷮ
        public float criticalProb; // ũ�� Ȯ��
        public float criticalDamage;

        public WeaponClip() { }

        public void PreLoad()
        {
            // ���߿� ������
        }

        public void ReleaseMonster()
        {
            // 
        }
    }

}
