using UnityEngine;
using System.Collections;

public class IntBounds 
{
    public static int SetInt(int current, float change, int lower, int higher)
    {
        if (change > 0)
        {
            change = 1;
        }
        
        else if (change < 0)
        {
            change = -1;
        }
        
        current += (int)change;
        
        if (current < lower)
        {
            current = higher;
        }
        
        else if (current > higher)
        {
            current = lower;
        }
        
        return current;
    }
}
