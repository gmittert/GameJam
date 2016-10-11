using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 200f;
    public bool isShooting;
    void Start () {
	
	}

    public void Move(float horizontalAxis, float verticalAxis)
    {
        if (!isShooting)
        {
            Vector2 toMove = new Vector2(horizontalAxis, verticalAxis);
            //toMove.Normalize(); 
            GetComponent<Rigidbody2D>().velocity = toMove * movementSpeed * Time.deltaTime;

            //animationComponent.MovementAnimation(verticalAxis, horizontalAxis);

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
