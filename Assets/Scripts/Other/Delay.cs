using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public static class Delay
{
    public static async void CallDelayedFunction(float sec, Action functionToCall)
    {
        await Task.Delay((int)(sec*1000));
        functionToCall.Invoke();
    }
}
