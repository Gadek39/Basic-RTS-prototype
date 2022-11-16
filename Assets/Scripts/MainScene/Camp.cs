using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventoryStatus();
        }
    }
    void showInventoryStatus()
    {
        Debug.Log("Current resources:\nMilk - " + GameManager.instance.milk + "\nFood - " + GameManager.instance.food + "\nSafety - " + GameManager.instance.shield);
    }
}
