using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupSpawner : MonoBehaviour {

    float randomSpawnTime;
    float age = 0f;
    GameObject pickupToSpawn;
    bool powerupOnLevel = false;
    public float earliestSpawn = 0f;
    public float latestSpawn = 25f;

    public GameObject LightEmUp;
    public GameObject MoreArrows;
    public GameObject BetterBow;

    public List<GameObject> powerups;

	public AudioClip sound;
	public AudioClip got;
    
    void Start () {
        init();
        Setup();
    }

    void init()
    {
        powerups.Add(LightEmUp);
        powerups.Add(MoreArrows);
        powerups.Add(BetterBow);
    }

    void Setup()
    {
        if (powerups.Count == 0)
        {
            Debug.Log("No Powerups!");
            Destroy(gameObject);
            return;
        }
        randomSpawnTime = Random.Range(earliestSpawn, latestSpawn);
        pickupToSpawn = powerups[Random.Range(0, powerups.Count - 1)];
        Debug.Log(pickupToSpawn);
    }

    void Update () {
        if (!powerupOnLevel)
        {
            age += Time.deltaTime;
        }
        
        if (age >= randomSpawnTime)
        {
            foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
            {
                spawner.SendMessage("PickupSpawned");
            }
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(pickupToSpawn, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(sound,transform.position, 0.25f);
    }

    void Reset()
    {
        powerupOnLevel = false;
		AudioSource.PlayClipAtPoint(got,transform.position, 0.25f);
        Setup();
    }

    void PickupSpawned()
    {
        powerupOnLevel = true;
        age = 0;
    }
}
