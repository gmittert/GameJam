using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float lifetime = 3.0f;
	private int damage = -1;
	private float speed = 20;
	public GameObject LandedArrow;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.lifetime -= 1*Time.deltaTime;
		if (lifetime < 0) {
			GameObject LandedArrowClone = (GameObject)Instantiate(LandedArrow, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		transform.Translate(Vector3.right*(speed*Mathf.Sqrt(this.lifetime))*Time.deltaTime);
	}

	void SetSpeed (float speed){
		this.speed = speed;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Wall")
		{
			GameObject LandedArrowClone = (GameObject)Instantiate(LandedArrow, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
