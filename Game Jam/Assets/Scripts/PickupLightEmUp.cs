using UnityEngine;
using System.Collections.Generic;

public class PickupLightEmUp : MonoBehaviour {

    public float lightUpLength = 2.0f;
    public GameObject lightPlayersUp;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PICKUP");
        if (other.gameObject.tag == "Player")
        {
            characterLight pickupCharacter = other.GetComponentInParent<characterLight>();

            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (player.GetComponentInParent<characterLight>() != pickupCharacter)
                {
                    GameObject light = (GameObject)Instantiate(lightPlayersUp, transform.position + new Vector3(0, 0, -1), transform.rotation);
                    light.GetComponent<LightPlayersUp>().playerToStalk = player.GetComponentInParent<characterLight>();
                    light.GetComponent<LightPlayersUp>().lifeSpan = lightUpLength;
                }
            }

            Destroy(gameObject);


        }
    }
}
