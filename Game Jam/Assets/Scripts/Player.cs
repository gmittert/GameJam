using UnityEngine;
using System.Collections;
using ControlWrapping;

public class Player : MonoBehaviour {

    
    public float movementSpeed = 5f;
    public float rotateSpeed = 10f;

    public float fireRate = 0.1f;
    public float arrowSpeed = 30f;
    public int numberOfArrows = 3;
    public int life = 1;


    public Sprite deathSprite;
    private GameObject arrowComponent;

    private PlayerAnimation animationComponent;
    private PlayerMovement movementComponent;
    private PlayerShooting shootingComponent;
    private PlayerLight lightComponent;

    int playerIndex;
    bool isShooting = false;
    float timeSinceLastShot = 0f;
    bool isPlayerAlive = true;

    GamePadWrapper gamePad;

	// Use this for initialization
	void Start () {
        playerIndex = GameManager.AddPlayer(this);
        gamePad = new GamePadWrapper();

        //Get Components
        animationComponent = GetComponent<PlayerAnimation>();
        movementComponent = GetComponent<PlayerMovement>();
        shootingComponent = GetComponent<PlayerShooting>();
        lightComponent = GetComponent<PlayerLight>();

        GameManager.Log(lightComponent, this);

        GameManager.Log("Player: " + playerIndex, this, LogLevel.High);
       
        arrowComponent = GetComponentInChildren<LightScript>().gameObject;
        arrowComponent.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        gamePad.CurrentState = GameManager.GetPlayerIndex(playerIndex);
        timeSinceLastShot += Time.deltaTime;

        lightComponent.SetTransperency();
        
        Aim();
        Shoot();
        Move();
    }

    void Move()
    {
        float horizontalAxis = gamePad.Stick.Left.X;
        float verticalAxis = gamePad.Stick.Left.Y;
        if (!isShooting)
        {
            Vector2 toMove = new Vector2(horizontalAxis, verticalAxis);
            //toMove.Normalize(); 
            GetComponent<Rigidbody2D>().velocity = toMove * movementSpeed * Time.deltaTime;

            animationComponent.MovementAnimation(verticalAxis, horizontalAxis);

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    
    void Aim()
    {
        float aimHorizontal = gamePad.Stick.Right.X;
        float aimVertical = gamePad.Stick.Right.Y;

        Vector3 toAim = new Vector3(aimHorizontal, aimVertical, 0);
        if(toAim == Vector3.zero) 
        {
            aimHorizontal = gamePad.Stick.Left.X;
            aimVertical = gamePad.Stick.Left.Y;
            toAim = new Vector3(aimHorizontal, aimVertical, 0);
        }
        toAim.Normalize();
        if (toAim != Vector3.zero)
        {
            float step = rotateSpeed * Time.deltaTime;
            Vector3 newAim = Vector3.RotateTowards(transform.forward, toAim, step, 0.0F);
            arrowComponent.transform.rotation = Quaternion.LookRotation(Vector3.forward, newAim) * Quaternion.Euler(0, 0, 90);
        }
        animationComponent.AimAnimation(aimHorizontal, aimVertical, Quaternion.identity);
    }

    void Shoot()
    {
        if ((gamePad.ButtonPress.RightTrigger == ButtonPressState.Pressed 
            || gamePad.ButtonPress.LeftTrigger == ButtonPressState.Pressed) 
            && timeSinceLastShot >= fireRate)
        {
            Debug.Log("Drawing!");
            isShooting = true;
            arrowComponent.SetActive(true);
            //animator.SetBool("shooting", true);
        }
        if ((gamePad.ButtonPress.RightTrigger == ButtonPressState.Released 
            || gamePad.ButtonPress.LeftTrigger == ButtonPressState.Released) 
            && isShooting)
        {
            Debug.Log("Shooting!");
            isShooting = false;
            timeSinceLastShot = 0;
            numberOfArrows--;
            arrowComponent.SetActive(false);
            //animator.SetBool("shooting", false);
        }
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

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit!");
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "GroundArrow")
        {
            numberOfArrows++;
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
        DestroyObject(GetComponent<PlayerLight>());
        GetComponent<CharacterController>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deathSprite;
    }
}
