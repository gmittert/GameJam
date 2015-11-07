using UnityEngine;
using System.Collections;

public class MoreArrows : PickupParentClass {
    
    public int arrowsToAdd = 2;

    public override void UsePickup( GameObject parent)
    {
        int arrows = parent.GetComponentInChildren<Gunfire>().numArrows;
        parent.GetComponentInChildren<Gunfire>().numArrows = arrows + arrowsToAdd;
        parent.GetComponentInChildren<Gunfire>().ArrowRect.sizeDelta = new Vector2(parent.GetComponentInChildren<Gunfire>().ArrowRect.sizeDelta.x + arrowsToAdd, 1);
    }
}
