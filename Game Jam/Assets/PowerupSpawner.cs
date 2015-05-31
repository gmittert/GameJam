using UnityEngine;
using System.Collections;

public class PowerupSpawner : MonoBehaviour {

    float randomSpawnTime;
    float age = 0f;
    int pickupToSpawn;
    bool powerupOnLevel = false;
    public float earliestSpawn = 0f;
    public float latestSpawn = 25f;
    public bool spawnLightEmUp = true;

    public GameObject LightEmUp;

    // Use this for initialization
    void Start () {
        Setup();
    }

    void Setup()
    {
        randomSpawnTime = Random.Range(earliestSpawn, latestSpawn);
        pickupToSpawn = Random.Range(0, 0);
    }

    // Update is called once per frame
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
        GameObject powerUp;
        switch (pickupToSpawn)
        {
            case 0:
                powerUp = (GameObject)Instantiate(LightEmUp, transform.position, transform.rotation);
                break;
        }
    }

    void Reset()
    {
        powerupOnLevel = false;
        Setup();
    }

    void PickupSpawned()
    {
        powerupOnLevel = true;
        age = 0;
    }
}
