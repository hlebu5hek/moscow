using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryKeys : MonoBehaviour
{
    private Dictionary<string, int> keys = new Dictionary<string, int>();
    
    public static PlayerInventoryKeys PIK;

    private void Awake()
    {
        PIK = this;
    }

    public bool HasKey(string name, int num)
    {
        if (!keys.ContainsKey(name)) return false;
        if (keys[name] < num) return false;
        keys[name] -= num;
        return true;
    }
    
    public void AddKey(string name, int num)
    {
        if (keys.ContainsKey(name)) keys[name] += num;
        else keys.Add(name, num);
    }
}
