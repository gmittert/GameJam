using UnityEngine;
using System.Collections;

public class GroundArrow : ParentLightObject {

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
            GetComponent<BoxCollider2D>().enabled = false;
            //GetComponentInChildren
            fadeObjectAway();
		}
	}
}
