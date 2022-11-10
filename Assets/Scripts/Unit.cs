using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float speed { get; private set; }
    protected float energy;
    protected bool isWorking;
    protected bool isEating;
    protected bool isMoving;
    protected bool isResting;
    protected bool isSelected;
    protected float workEfficency;
    protected float experience;
    protected Camp camp;


    // Start is called before the first frame update
    protected void Awake()
    {
        camp = FindObjectOfType<Camp>();
        experience = 0;
        energy = 100;
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
            Debug.Log(energy);
        }
        while (energy > 0 && isMoving)
        {
            energy--;
            yield return new WaitForSeconds(10);
        }
    }
    IEnumerator EatingInCamp()
    {
        while (energy < 100 && camp.food > 0)
        {
            energy += 5;
            camp.food--;
            yield return new WaitForSeconds(2.5f);
        }
        if (energy < 100 && camp.food == 0)
        {
            isEating = false;
            isResting = true;
        }
    }
    public abstract void Working();
    
}
