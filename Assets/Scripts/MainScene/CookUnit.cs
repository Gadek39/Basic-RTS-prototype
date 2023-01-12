using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookUnit : Unit
{
    public override void Working()
    {
        if (!startedWorking)
        {
            StartCoroutine(CookingStuff(workEfficency, arbitraryRateNumber));
        }
    }
    IEnumerator CookingStuff(float productionRate, float productionSpeed)
    {
        startedWorking = true;
        GameManager.instance.food += productionRate;
        yield return new WaitForSeconds(productionSpeed);
        startedWorking = false;
    }
}
