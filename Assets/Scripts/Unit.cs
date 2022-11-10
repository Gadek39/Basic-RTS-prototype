using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed { get; private set; }
    public float energy;
    public bool isWorking;
    public bool isEating;
    public bool isMoving;
    public bool isResting;
    public float workEfficency;
    public float experience;
    private float food;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EnergyDepletion());
        if (isEating)
        {
            StartCoroutine(EatingInCamp());
        }
        if (isWorking)
        Working();
    }
    IEnumerator EnergyDepletion()
    {
        while (energy > 0 && isWorking)
        {
            energy--;
            yield return new WaitForSeconds(5);
        }
        while (energy > 0 && isMoving)
        {
            energy--;
            yield return new WaitForSeconds(10);
        }
    }
    IEnumerator EatingInCamp()
    {
        while (energy < 100 && food > 0)
        {
            energy += 5;
            food--;
            yield return new WaitForSeconds(2.5f);
        }
        if (energy < 100 && food == 0)
        {
            isEating = false;
            isResting = true;
        }
    }
    public virtual void Working()
    {
        workEfficency = experience * 1;
    }
}
