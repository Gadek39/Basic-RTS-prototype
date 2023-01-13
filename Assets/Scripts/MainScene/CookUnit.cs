using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookUnit : Unit
{
    new void Start()
    {
        workBulding = GameObject.Find("Kitchen");
        base.Start();
    }
    public override void Working()
    {
        if (!isInPlace)
        {
            MoveToPlace(workplace);
            return;
        }

        distanceIsMeassured = false;
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
