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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddToInventory(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddToInventory(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddToInventory(3);
        }
    }
    void showInventoryStatus()
    {
        Debug.Log("Current resources:\nMilk - " + GameManager.instance.milk + "\nFood - " + GameManager.instance.food + "\nSafety - " + GameManager.instance.shield);
    }
    void AddToInventory(int type)
    {
        if (type == 1)
        {
            GameManager.instance.milk++;
        }
        else if (type == 2)
        {
            GameManager.instance.food++;
        }
        else if (type == 3)
        {
            GameManager.instance.shield++;
        }
    }
}
