using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 5f;
	public string PlayerString = "P1";
	public GameObject Deadguy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalAxis = Input.GetAxis ("Horizontal"+PlayerString);
		float verticalAxis = Input.GetAxis ("Vertical"+PlayerString);

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
