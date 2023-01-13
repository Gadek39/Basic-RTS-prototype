using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : Unit
{
    protected float basicDefense = 5;
    private float currentDefense;
    private float startingDefense;
    private float defenceChange;
    private bool isGuarding;

    new void Start()
    {
        workBulding = GameObject.Find("Tower");
        base.Start();
    }
    new void Update()
    {
        base.Update();
        if (isWorking)
        {
            return;
        }
        if (isGuarding)
        {
            isGuarding = false;
            GameManager.instance.shield -= currentDefense;
        }
    }
    public override void Working()
    {
        if (startedWorking)
        {
            return;
        }

        if (!isInPlace)
        {
            MoveToPlace(workplace);
            return;
        }

        distanceIsMeassured = false;
        OnGuard(basicDefense + workEfficency);
        DefenceRateCalculation();
    }
    private void OnGuard(float protectionRate)
    {
        if (!isGuarding)
        {
            startingDefense = protectionRate;
            GameManager.instance.shield += startingDefense;
            isGuarding = true;
        }
    }
    private void UpdateProtectionRate(float changeFactor)
    {
        startingDefense = changeFactor;
        GameManager.instance.shield += changeFactor;
        defenceChange = 0;
    }

    private void DefenceRateCalculation()
    {
        currentDefense = basicDefense + workEfficency;
        defenceChange = currentDefense - startingDefense;

        if (defenceChange > 0)
        {
            GameManager.instance.shield -= startingDefense;
            UpdateProtectionRate(basicDefense + workEfficency);
        }
    }
}
