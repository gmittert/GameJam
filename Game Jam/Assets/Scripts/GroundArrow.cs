using UnityEngine;
using System.Collections;

public class GroundArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
            GetComponent<LightScript>().FadeAway(.25f);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
			Destroy(gameObject, .25f);
		}
	}
}
