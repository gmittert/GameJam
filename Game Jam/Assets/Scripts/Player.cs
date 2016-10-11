using UnityEngine;
using System.Collections;
using ControlWrapping;

public class Player : MonoBehaviour {

    public int life = 1;

    public Sprite deathSprite;

    private PlayerAnimation animationComponent;
    private PlayerMovement movementComponent;
    private PlayerShooting shootingComponent;
    private PlayerLight lightComponent;
    private PlayerController controller;

    int playerIndex;
    bool isShooting = false;
    bool isPlayerAlive = true;

	// Use this for initialization
	void Start () {
        playerIndex = GameManager.AddPlayer(this);

        //Get Components
        animationComponent = GetComponent<PlayerAnimation>();
        movementComponent = GetComponent<PlayerMovement>();
        shootingComponent = GetComponent<PlayerShooting>();
        lightComponent = GetComponent<PlayerLight>();
        controller = GetComponent<PlayerController>();

        GameManager.Log(lightComponent, this);

        GameManager.Log("Player: " + playerIndex, this, LogLevel.High);
    }
	
	// Update is called once per frame
	void Update () {
        controller.UpdateGamePadState(playerIndex);
        lightComponent.SetTransperency();
        shootingComponent.Aim(controller.AimValues().X, controller.AimValues().Y);
        shootingComponent.Shoot(controller.ShootEvent());
        movementComponent.Move(controller.MovementValues().X, controller.MovementValues().Y);
        
    }
    

    void OnShot()
    {
        life--;
        if (life <= 0)
        {
            Die();
        }
        //play sound
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "GroundArrow")
        {
            shootingComponent.AddArrows(1);
            //ArrowRect.sizeDelta = new Vector2(ArrowRect.sizeDelta.x + 1, 1);

            //TODO: this should be done on the arrow
            otherObject.GetComponentInChildren<LightScript>().FadeAway(.25f);
            otherObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
            otherObject.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            Destroy(otherObject.gameObject, .25f);
        }
    }

    void Die()
    {
        isPlayerAlive = false;
        lightComponent.enabled = false;
        movementComponent.enabled = false;
        shootingComponent.enabled = false;
        GetComponent<SpriteRenderer>().sprite = deathSprite;
    }
}
