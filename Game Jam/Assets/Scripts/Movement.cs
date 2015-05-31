using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 5f;
	public string PlayerString = "P1";
	public GameObject Deadguy;
    private Animator animator;
    // Use this for initialization
    void Start () {
        animator = this.GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		float horizontalAxis = Input.GetAxis ("Horizontal"+PlayerString);
		float verticalAxis = Input.GetAxis ("Vertical"+PlayerString);

        if (verticalAxis > 0)
        {
            animator.SetInteger("direction", 2);
            animator.SetBool("idle", false);
        }
        else if (verticalAxis < 0)
        {
            animator.SetInteger("direction", 0);
            animator.SetBool("idle", false);
        }
        else if (horizontalAxis > 0)
        {
            animator.SetInteger("direction", 1);
            animator.SetBool("idle", false);
        }
        else if (horizontalAxis < 0)
        {
            animator.SetInteger("direction", 3);
            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("Idle", true);
        }

        Vector3 toMove = new Vector3(horizontalAxis,verticalAxis);
		toMove.Normalize ();
		 
		GetComponent<CharacterController>().Move(toMove*speed*Time.deltaTime);
		
	}

	void Die(int a){
		Debug.Log ("I'm Dead Twice!");
		GameObject DeadguyClone = (GameObject)Instantiate(Deadguy,transform.position,Quaternion.Euler(Vector3.up));
		Destroy (gameObject);
	}
}
