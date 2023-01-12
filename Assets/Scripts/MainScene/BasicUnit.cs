using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : Unit
{
   
    new void Start()
    {
        workBulding = GameObject.Find("Barn");
        base.Start();
    }
    public override void Working()
    {
        if (!startedWorking)
        {
            if (isInPlace)
            {
                distanceIsMeassured = false;   
                StartCoroutine(MilkGathering(workEfficency, arbitraryRateNumber));
            }
            else
            {
                MoveToPlace(workplace);
            }
        }
    }
    IEnumerator MilkGathering(float productionRate, float productionSpeed)
    {
        startedWorking = true;
        GameManager.instance.milk += productionRate;
        yield return new WaitForSeconds(productionSpeed); 
        startedWorking = false;
        
    }
}
