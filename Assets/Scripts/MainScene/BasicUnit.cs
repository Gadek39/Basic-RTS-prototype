using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : Unit
{
    // Start is called before the first frame update


    // Update is called once per frame

    public override void Working()
    {
        StartCoroutine(MilkGathering(1, 2));
    }
    IEnumerator MilkGathering(float productionRate, float productionSpeed)
    {
        yield return new WaitForSeconds(productionSpeed); 
        Debug.Log(GameManager.instance.milk += productionRate);
        
    }
}
