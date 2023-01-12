using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : Unit
{
    protected float basicDefense = 5;
    private float currentDefense;
    private float startingDefense;
    private float defenceChange;
    private float defEqualizer;
    private bool isGuarding;
    
    new void Update()
    {
        base.Update();
        if (!isWorking)
        {
            if (isGuarding)
            {
                isGuarding = false;
                GameManager.instance.shield -= currentDefense;
            }
        }
    }
    public override void Working()
    {
        if (!startedWorking)
        {
            OnGuard(basicDefense + workEfficency);
        }
        currentDefense = basicDefense + workEfficency;
        defenceChange = currentDefense - startingDefense;
        if (defenceChange > 0)
        {
            GameManager.instance.shield -= startingDefense;
            UpdateProtectionRate(basicDefense + workEfficency);
        }
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
}
