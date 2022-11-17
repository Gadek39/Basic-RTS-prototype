using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : Unit
{
    protected float basicDefense = 5;
    
    new void Update()
    {
        base.Update();
        if (!isWorking)
        {
            startedWorking = false;
            GameManager.instance.shield -= basicDefense+workEfficency;
        }
    }
    public override void Working()
    {
        if (!startedWorking)
        {
            StartCoroutine(OnGuard(basicDefense + workEfficency));
        }
    }
    IEnumerator OnGuard(float protectionRate)
    {
        startedWorking = true;
        GameManager.instance.shield += protectionRate;
        yield return null;
    }
}
