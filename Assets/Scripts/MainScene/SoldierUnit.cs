using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : Unit
{
    protected float basicDefense = 5;
    public override void Working()
    {
        StartCoroutine(OnGuard(basicDefense + workEfficency));
    }
    IEnumerator OnGuard(float protectionRate)
    {
        GameManager.instance.shield += protectionRate;
        yield return null;
    }
}
