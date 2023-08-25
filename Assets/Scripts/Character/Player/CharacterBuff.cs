using SwordEnchant.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterBuff : IModifier<float>
{
    public float value;

    public CharacterBuff(float v) { value = v; }

    public void AddValue(ref float v)
    {
        v += value;
    }
}
