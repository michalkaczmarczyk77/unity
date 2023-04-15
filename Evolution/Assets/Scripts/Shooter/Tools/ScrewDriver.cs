using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriver : Tool
{
    private const string toolName = "Screwdriver";

    public override void Use()
    {
        Debug.Log("I am using the tool called: " + toolName);
    }
}
