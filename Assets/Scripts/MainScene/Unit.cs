using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float speed { get; private set; }
    public int energy;

    private GameObject camp;
    protected GameObject workBulding;

    protected float arbitraryRateNumber = 4;

    protected float expiernceDeductor = 3;
    protected float expierenceDivider = 4;
    protected float expierienceCorrector = 1.5f;
    protected float efficencyCorrector = 1;
    protected float startingTime;
    protected float distanceCovered;
    protected float fractionOfDistance;
    protected float distanceToPlace;

    public bool isWorking;
    public bool isEating;
    public bool isResting;
    protected bool isSelected;
    protected bool startedLoosingEnergy;
    protected bool startedEating;
    protected bool startedLearning;
    protected bool startedWorking;
    protected float workEfficency;
    protected bool isInPlace;
    private bool isInCamp;
    protected bool distanceIsMeassured;
    public int experience;

    protected Vector3 workplace;
    private Vector3 campsite;


    // Start is called before the first frame update
    protected void Awake()
    {
        experience = 1;
        energy = 100;
        workEfficency = 1;
        speed = 1;

    }
    public void Start()
    {
        startedLoosingEnergy = false;
        startedWorking = false;
        startedEating = false;
        startedLearning = false;
        LoadFromGameManager();
        camp = GameObject.Find("Camp");
        campsite = new Vector3(camp.transform.position.x, transform.position.y, camp.transform.position.z);
        workplace = new Vector3(workBulding.transform.position.x, transform.position.y, workBulding.transform.position.z);
    }

    // Update is called once per frame
    public void Update()
    {
        if (transform.position == workplace)
        {
            isInPlace = true;
        }
        if (transform.position == campsite)
        {
            isInCamp = true;
        }
        else
        {
            isInPlace = false;
            isInCamp = false;
        }
        
        if (energy < 1)
        {
            isWorking = false;
        } 
        else if (isWorking)
        {
            Working();
            if (!startedLoosingEnergy)
            {
                StartCoroutine(EnergyDepletion(workEfficency));
            }
            if (!startedLearning && isInPlace)
            {
                StartCoroutine(gainingExperience(arbitraryRateNumber));
            }
        }
        if (isEating)
        {
            if (isInCamp)
            {
                distanceIsMeassured = false;
                if (!startedEating)
                {
                    StartCoroutine(EatingInCamp());
                }
            }
            else if (!isInCamp && GameManager.instance.food > 0)
            {
                MoveToPlace(campsite);
            }
            
        }
        if (isResting)
        {
            isEating = false;
            isWorking = false;
            distanceIsMeassured = false;
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
    protected void MoveToPlace(Vector3 location)
    {
        if (!distanceIsMeassured)
        {
            distanceToPlace = Vector3.Distance(transform.position, location);
            startingTime = Time.time;
            distanceIsMeassured = true;
            Debug.Log(workplace);
            Debug.Log(campsite);
        }
        else if (distanceIsMeassured)
        {
            distanceCovered = (Time.time - startingTime) * speed;
            fractionOfDistance = distanceCovered / distanceToPlace;
            transform.position = Vector3.Lerp(transform.position, location, fractionOfDistance);
        }
    }
}
