using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float speed { get; private set; }
    public float energy;
    public bool isWorking;
    protected bool isEating;
    protected bool isResting;
    protected bool isSelected;
    protected float workEfficency;
    public float experience;


    // Start is called before the first frame update
    protected void Awake()
    {
        experience = 0;
        energy = 100;
    }
    public void Start()
    {
        StartCoroutine(EnergyDepletion());
        StartCoroutine(EatingInCamp());
    }

    // Update is called once per frame
    public void Update()
    {
        if (isWorking)
        {
            Working();
        }
        if (energy == 0)
        {
            isWorking = false;
        }
    }
    IEnumerator EnergyDepletion()
    {
        while (energy > 0 && isWorking)
        {
            energy--;
            yield return new WaitForSeconds(1);
            Debug.Log(energy);
        }
        
    }
    IEnumerator EatingInCamp()
    {
        while (energy < 100 && GameManager.instance.food > 0 && isEating)
        {
            energy += 5;
            GameManager.instance.food--;
            yield return new WaitForSeconds(2.5f);
        }
        if (energy < 100 && GameManager.instance.food == 0 && isEating)
        {
            isEating = false;
            isResting = true;
        }
    }
    public abstract void Working();
    
}
