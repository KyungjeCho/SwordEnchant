using SwordEnchant.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����Ʈ �����հ� ��ο� Ÿ�Ե��� �Ӽ� �����͸� ������ �ְ� �Ǹ�
/// ������ �����ε� ����� ���� �ְ� - Ǯ���� ���� ����̱⵵ �մϴ�.
/// ����Ʈ �ν��Ͻ� ��ɵ� ���� ������ - Ǯ���� �����ؼ� ����ϱ⵵ �մϴ�.
/// </summary>
namespace SwordEnchant.Data
{
    public enum EffectType
    {
        None = -1,
        NORMAL,
    }

    public class EffectClip
    {
        //���� �Ӽ��� ������ �ٸ� ����Ʈ Ŭ���� ������ �־ �к���.
        public int realId = 0;

        public EffectType effectType = EffectType.NORMAL;
        public GameObject effectPrefab = null;
        public string effectName = string.Empty;
        public string effectPath = string.Empty;
        public string effectFullPath = string.Empty;
        public EffectClip() { }

        public void PreLoad()
        {
            this.effectFullPath = effectPath + effectName;
            if (this.effectFullPath != string.Empty && this.effectPrefab == null)
            { // ��ο� �ְ� ���� �ε� �Ǿ� ������
                this.effectPrefab = ResourceManager.Load(effectFullPath) as GameObject;
            }
        }
        public void ReleaseEffect()
        {
            if (this.effectPrefab != null)
            {
                this.effectFullPath = null;
            }
        }
        /// <summary>
        /// ���ϴ� ��ġ�� ���� ���ϴ� ����Ʈ�� �ν��Ͻ��մϴ�.
        /// </summary>
        public GameObject Instantiate(Vector3 Pos)
        {
            if (this.effectPrefab == null)
            {
                this.PreLoad();
            }

            if (this.effectPrefab != null)
            {
                GameObject effect = GameObject.Instantiate(effectPrefab, Pos, Quaternion.identity);
                return effect;
            }
            return null;
        }
    }
}

