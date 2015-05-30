using UnityEngine;
using System.Collections;
//public GameObject Laser;

public class Gunfire : MonoBehaviour {
	
	public GameObject Lazer;
	public float timer;
	public float fireRate = 0.1f;
	public bool enable;
	public int fireCone = 15;
	public float speed = 10;
	public float speedVariance = 5;
	public string PlayerString = "P1";
	public AudioClip shootSound;

	private AudioSource source;
	// Use this for initialization
	void Start () {
	}


	void Awake () {
		source = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > fireRate && Input.GetButtonUp("Fire"+PlayerString)){
			//Fire Arrow
			Quaternion bulletRotation = Quaternion.LookRotation(transform.forward, -transform.right);
			Vector3 eulerRotation = bulletRotation.eulerAngles;
			bulletRotation = Quaternion.Euler(eulerRotation);
			source.PlayOneShot(shootSound,1.0f);

			//instantiate
			GameObject lazerClone = (GameObject)Instantiate(Lazer,transform.position+transform.up,bulletRotation);

			//set speed
			float lazerSpeed = speed;
			lazerClone.SendMessage("SetSpeed", lazerSpeed);

			timer = 0;
		}
	}
}
