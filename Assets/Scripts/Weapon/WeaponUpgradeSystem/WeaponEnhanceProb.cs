using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnhanceProb : MonoBehaviour
{
    public List<Probability> probs = new List<Probability>();
}

[Serializable]
public class Probability
{
    [Range(0, 1)]
    public float successProb;
    [Range(0, 1)]
    public float failureProb;
    [Range(0, 1)]
    public float destroyProb;
}
