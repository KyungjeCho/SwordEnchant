using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Item", order = int.MaxValue)]
public class Item : ScriptableObject 
{
    public int rate;
    public int index;
    public string itemName;
    public Sprite icon;
    public Sprite sprite;
}

