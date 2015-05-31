using UnityEngine;
using System.Collections.Generic;

public class PickupLightEmUp : MonoBehaviour {

    public float lightUpLength = 2.0f;
    public float fadeTime = .25f;
    public GameObject lightPlayersUp;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
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

            Destroy(gameObject, fadeTime);
            GetComponentInChildren<LightScript>().FadeAway(fadeTime);
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);


        }
    }

    void OnDestroy()
    {
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawner.SendMessage("Reset");
        }

    }
}
