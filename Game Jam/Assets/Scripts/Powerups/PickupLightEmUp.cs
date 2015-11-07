using UnityEngine;
using System.Collections.Generic;

public class PickupLightEmUp : PickupParentClass {

    public float lightUpLength = 2.0f;
    public GameObject lightPlayersUp;

    public override void UsePickup(GameObject parent)
    {
        characterLight pickupCharacter = parent.GetComponent<characterLight>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player.GetComponentInParent<characterLight>() != pickupCharacter)
            {
                GameObject light = (GameObject)Instantiate(lightPlayersUp, transform.position + new Vector3(0, 0, -1), transform.rotation);
                light.GetComponent<LightPlayersUp>().playerToStalk = player.GetComponentInParent<characterLight>();
                light.GetComponent<LightPlayersUp>().lifeSpan = lightUpLength;
            }
        }
    }
}
