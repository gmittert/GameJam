using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 5f;
	public string PlayerString = "P1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalAxis = Input.GetAxis ("Horizontal"+PlayerString);
		float verticalAxis = Input.GetAxis ("Vertical"+PlayerString);

		Vector3 toMove = new Vector3(horizontalAxis,verticalAxis);
		toMove.Normalize ();
		try{ 
			GetComponent<CharacterController>().Move(toMove*speed*Time.deltaTime);
		} catch(MissingComponentException e){
		}
	}
}
