using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float speed { get; private set; }
    public int energy;

    protected float arbitraryRateNumber = 2;

    protected float expiernceDeductor = 2;
    protected float expierenceDivider = 4;
    protected float expierienceCorrector = 1.5f;
    protected float efficencyCorrector = 1;

    public bool isWorking;
    public bool isEating;
    public bool isResting;
    protected bool isSelected;
    protected bool startedLoosingEnergy;
    protected bool startedEating;
    protected bool startedLearning;
    protected bool startedWorking;
    protected float workEfficency;
    public int experience;


    // Start is called before the first frame update
    protected void Awake()
    {
        experience = 1;
        energy = 100;
        workEfficency = 1;
        
    }
    public void Start()
    {
        startedLoosingEnergy = false;
        startedWorking = false;
        startedEating = false;
        startedLearning = false;
        LoadFromGameManager();
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
            if (!startedLoosingEnergy)
            {
                StartCoroutine(EnergyDepletion(workEfficency));
            }
            if (!startedLearning)
            {
                StartCoroutine(gainingExperience(arbitraryRateNumber));
            }
        }
        if (isEating)
        {
            if (!startedEating)
            {
                StartCoroutine(EatingInCamp());
            }
        }
        if (isResting)
        {
            isEating = false;
            isWorking = false;
        } else if (isEating)
            {
            isWorking = false;
        }
    }
    IEnumerator EnergyDepletion(float workEfficency)
    {
            startedLoosingEnergy = true;
            energy--;
            yield return new WaitForSeconds(workEfficency);
            startedLoosingEnergy = false;
    }
    IEnumerator EatingInCamp()
    {
        startedEating = true;
        if (energy < 100 && GameManager.instance.food > 0 && isEating)
        {
            energy += 5;
            GameManager.instance.food--;
            yield return new WaitForSeconds(2.5f);
        }
        if (energy < 100 && GameManager.instance.food == 0 && isEating || energy == 100)
        {
            isEating = false;
            isResting = true;
        }
        startedEating = false;
    }
    IEnumerator gainingExperience(float experienceGainRate)
    {
        startedLearning = true;
        yield return new WaitForSeconds(experienceGainRate);
        workEfficency = Mathf.Ceil((experience - expiernceDeductor) / expierenceDivider + expierienceCorrector);
        experience++;
        startedLearning = false;
    }
    public abstract void Working();

    public void AddToGameManager()
    {
        SaveData.UnitData unitData = new SaveData.UnitData();
        unitData.name = gameObject.name;
        unitData.isActive = gameObject.activeInHierarchy;
        unitData.energy = energy;
        unitData.experience = experience;
        unitData.isWorking = isWorking;
        unitData.isEating = isEating;
        unitData.isResting = isResting;
        unitData.position = transform.position;
        unitData.rotation = transform.rotation;
        GameManager.instance.units.Add(unitData);
    }
    public void LoadFromGameManager()
    {
        foreach (SaveData.UnitData unitData in GameManager.instance.units)
        {
            if (unitData.name == gameObject.name)
            {
                gameObject.SetActive(unitData.isActive);
                energy = unitData.energy;
                experience = unitData.experience;
                isWorking = unitData.isWorking;
                isEating = unitData.isEating;
                isResting = unitData.isResting;
                transform.position = unitData.position;
                transform.rotation = unitData.rotation;
                break;
            }
        }
    }

}
