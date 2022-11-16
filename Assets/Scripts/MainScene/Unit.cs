using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float speed { get; private set; }
    public float energy;

    protected float arbitraryRateNumber = 2;

    protected float expiernceDeductor = 2;
    protected float expierenceDivider = 4;
    protected float expierienceCorrector = 1.5f;
    protected float efficencyCorrector = 1;

    public bool isWorking;
    protected bool isEating;
    protected bool isResting;
    protected bool isSelected;
    protected float workEfficency;
    public float experience;


    // Start is called before the first frame update
    protected void Awake()
    {
        experience = 1;
        energy = 100;
        workEfficency = 1;
        
    }
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (energy < 1)
        {
            isWorking = false;
        } else if (isWorking)
        {
            Working();
            StartCoroutine(gainingExperience(3));
            StartCoroutine(EnergyDepletion(2+workEfficency));
        }
        if (!isWorking)
        {
            StopCoroutine(gainingExperience(3+workEfficency));
            StopCoroutine(EnergyDepletion(2));
        }
        if (isEating)
        {
            StartCoroutine(EatingInCamp());
        }
    }
    IEnumerator EnergyDepletion(float workEfficency)
    {
        while (isWorking && energy >0)
        {
            energy--;
            Debug.Log(energy);
            yield return new WaitForSeconds(workEfficency);
        }
        if (energy == 0)
        {
            isWorking = false;
            isResting = true;
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
        if (energy < 100 && GameManager.instance.food == 0 && isEating || energy == 100)
        {
            isResting = true;
        }
    }
    IEnumerator gainingExperience(float experienceGainRate)
    {
        while (isWorking && energy > 0)
        {
            yield return new WaitForSeconds(experienceGainRate);
            workEfficency = Mathf.Ceil((experience - expiernceDeductor) / expierenceDivider + expierienceCorrector);
            experience++;
            Debug.Log(workEfficency);
        }
    }
    public abstract void Working();
    
}
