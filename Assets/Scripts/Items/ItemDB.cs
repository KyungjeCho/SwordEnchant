using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public HealthUpItem healthUpItem;
}

public abstract class PassiveItem : MonoBehaviour, IUsable
{
    public Item item;

    public abstract void EffectRate0();
    public abstract void EffectRate1();
    public abstract void EffectRate2();
    public abstract void EffectRate3();
    public abstract void EffectRate4();
    public abstract void EffectRate5();
    public abstract void EffectRate6();
    public abstract void EffectRate7();
    public abstract void EffectRate8();
    public abstract void EffectRate9();

    public void Use()
    {
        switch(item.rate)
        {
            case (0):
                EffectRate0();
                break;
            case (1):
                EffectRate1();
                break;
            case (2):
                EffectRate2();
                break;
            case (3):
                EffectRate3();
                break;
            case (4):
                EffectRate4();
                break;
            case (5):
                EffectRate5();
                break;
            case (6):
                EffectRate6();
                break;
            case (7):
                EffectRate7();
                break;
            case (8):
                EffectRate8();
                break;
            case (9):
                EffectRate9();
                break;
        }
    }
}



public class MoveSpeedUpItem : PassiveItem
{
    public override void EffectRate0() 
    {
        
    }
    public override void EffectRate1() {}
    public override void EffectRate2() {}
    public override void EffectRate3() {}
    public override void EffectRate4() {}
    public override void EffectRate5() {}
    public override void EffectRate6() {}
    public override void EffectRate7() {}
    public override void EffectRate8() {}
    public override void EffectRate9() {}
}

