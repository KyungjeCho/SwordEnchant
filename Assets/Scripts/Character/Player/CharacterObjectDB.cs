using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Database", menuName = "Data/CharacterObjectDatabase")]
public class CharacterObjectDB : ScriptableObject
{
    public CharacterObject[] characterObjects;
}
