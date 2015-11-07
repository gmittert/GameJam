using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float fireRate = 0.1f;
    public float movementRate = 5f;
    public int numberOfArrows = 3;
    public int life = 1;

    public Sprite deathSprite;

    float timeSinceLastShot = 0f;
    bool isPlayerAlive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastShot += Time.deltaTime;
	}

    void Shoot()
    {
        timeSinceLastShot = 0;
        numberOfArrows--;
    }

    //onShootEvent;

    void OnShot()
    {
        life--;
        if (life <= 0)
        {
            Die();
        }
        //play sound
    }

    void Die()
    {
        isPlayerAlive = false;
        DestroyObject(GetComponent<characterLight>());
        GetComponent<CharacterController>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deathSprite;
    }
}
