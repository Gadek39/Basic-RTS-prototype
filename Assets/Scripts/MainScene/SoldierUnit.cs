using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : Unit
{
    protected float basicDefense = 5;
    private float currentDefense;
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
    }
    private void OnGuard(float protectionRate)
    {
        if (!isGuarding)
        {
            currentDefense = protectionRate;
            GameManager.instance.shield += currentDefense;
            isGuarding = true;
        }
    }
}
