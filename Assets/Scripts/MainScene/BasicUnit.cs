using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : Unit
{
    // Start is called before the first frame update
    

    // Update is called once per frame
   
    public override void Working()
    {
        GameManager.instance.milk++;
    }
}
