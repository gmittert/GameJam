using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float lifetime = 0.5f;
	private int damage = -1;
	private float speed = 0;
	public GameObject LandedArrow;

	public AudioClip clatter;
	public AudioClip deathSound1;
	public AudioClip deathSound2;
	public AudioClip deathSound3;
	public AudioClip deathSound4;

	private AudioSource source;

	// Use this for initialization
	void Start () {
	}

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		this.lifetime -= 1*Time.deltaTime;
		if (lifetime < 0.1f) {
			GameObject LandedArrowClone = (GameObject)Instantiate(LandedArrow, transform.position, transform.rotation);
			source.PlayOneShot(clatter,1.0f);
			Destroy(gameObject);
		}
		transform.Translate(Vector3.right*(speed*Mathf.Sqrt(this.lifetime*2))*Time.deltaTime);
	}

	void SetSpeed (float speed){
		this.speed = speed;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.gameObject.SendMessage("Die",1);

			float x = Random.Range(0,4);
			Debug.Log (x);
			if(x <= 1) AudioSource.PlayClipAtPoint(deathSound1,transform.position, 0.25f);
			else if(x <= 2) AudioSource.PlayClipAtPoint(deathSound2,transform.position, 0.15f);
			else if(x <= 3) AudioSource.PlayClipAtPoint(deathSound3,transform.position, 0.25f);
			else if(x <= 4) AudioSource.PlayClipAtPoint(deathSound4,transform.position, 0.25f);
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Wall")
		{
			GameObject LandedArrowClone = (GameObject)Instantiate(LandedArrow, transform.position, transform.rotation);
			source.clip = clatter;
			AudioSource.PlayClipAtPoint(clatter,transform.position, 0.25f);
			Destroy(gameObject);
		}
	}
}
