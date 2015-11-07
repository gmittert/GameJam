using UnityEngine;
using System.Collections;

public class BetterBow : PickupParentClass {
    
    public float factorToIncreaseBowStrength = 2f;

    public override void UsePickup(GameObject parent)
    {
        float speed = parent.GetComponentInChildren<Gunfire>().speed;
        parent.GetComponentInChildren<Gunfire>().speed = speed * factorToIncreaseBowStrength;
    }
}
