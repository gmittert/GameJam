using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float lifetime = 0.5f;
	private int damage = -1;
	private float speed = 60;
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
		transform.Translate(Vector3.right*(speed*Mathf.Sqrt(this.lifetime*2))*Time.deltaTime);
	}

	void SetSpeed (float speed){
		this.speed = speed;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log (col.gameObject.tag);
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
