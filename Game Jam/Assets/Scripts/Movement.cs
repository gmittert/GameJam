﻿using UnityEngine;
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
		if (!Input.GetButton ("Fire" + PlayerString)) {
			if (Mathf.Abs (verticalAxis) > Mathf.Abs (horizontalAxis)) {
				if (verticalAxis > 0) {
					animator.SetInteger ("direction", 2);
					animator.SetBool ("idle", false);
				} else if (verticalAxis < 0) {
					animator.SetInteger ("direction", 0);
					animator.SetBool ("idle", false);
				}
			} else {
				if (horizontalAxis > 0) {
					animator.SetInteger ("direction", 1);
					animator.SetBool ("idle", false);
				} else if (horizontalAxis < 0) {
					animator.SetInteger ("direction", 3);
					animator.SetBool ("idle", false);
				} else {
					animator.SetBool ("idle", true);
				}
			}
        
        

			Vector3 toMove = new Vector3 (horizontalAxis, verticalAxis);
			toMove.Normalize ();
		 
			GetComponent<CharacterController> ().Move (toMove * speed * Time.deltaTime);
		} else {
			animator.SetBool ("idle", true);
		}
	}

	void Die(int a){
		GameObject DeadguyClone = (GameObject)Instantiate(Deadguy,transform.position,Quaternion.Euler(Vector3.up));
		Camera.main.SendMessage ("deathNotice", int.Parse(PlayerString.Substring(1)));
		Destroy (gameObject);
	}
}
