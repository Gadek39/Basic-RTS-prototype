using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : Unit
{
    
    // Start is called before the first frame update

    // Update is called once per frame
    
    public override void Working()
    {
        GameManager.instance.shield += 5;
    }
}
