using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{
    public float defense;
    public float food;
    public float milk;

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
        Debug.Log("Current resources:\nMilk - " + milk + "\nFood - " + food + "\nSafety - " + defense);
    }
}
