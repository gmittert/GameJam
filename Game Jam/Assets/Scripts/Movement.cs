using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");

		Vector3 toMove = new Vector3(horizontalAxis,verticalAxis);
		toMove.Normalize ();
		GetComponent<CharacterController>().Move(toMove*speed*Time.deltaTime);
	}
}
