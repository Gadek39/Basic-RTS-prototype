using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookUnit : Unit
{
    
    // Start is called before the first frame update
    new void Start()
    {
        isWorking = true;
    }
    // Update is called once per frame
 
    public override void Working()
    {
        GameManager.instance.food++;
    }
}
