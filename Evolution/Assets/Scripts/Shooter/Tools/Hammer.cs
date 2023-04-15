using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Tool
{
    private const string toolName = "Hammer";

    public override void Use()
    {
        Debug.Log("I am using the tool called: "+ toolName);
    }
}
