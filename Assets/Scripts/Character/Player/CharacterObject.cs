using SwordEnchant.Data;
using SwordEnchant.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Data/CharacterObject")]
public class CharacterObject : ScriptableObject
{
    #region Variables
    public CharacterList characterIndex;

    [SerializeField]
    private CharacterStats stats = null;
    private CharacterClip clip = null;

    public CharacterStats Stats => stats;
    public CharacterClip Clip => clip;
    #endregion Variables

    public void OnValidate()
    {
        if (characterIndex == CharacterList.None)
            return;

        clip = DataManager.CharacterData().characterClips[(int)characterIndex];
        stats = new CharacterStats(characterIndex);
        clip.PreLoad();
    }
}
