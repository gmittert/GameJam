using UnityEngine;
using System.Collections;
//public GameObject Laser;

public class Gunfire : MonoBehaviour {
	
	public GameObject Lazer;
	public float timer;
	public float fireRate = 0.1f;
	public bool enable;
	public int fireCone = 15;
	public float speed = 30;
	public float speedVariance = 5;
	public string PlayerString = "P1";
	public AudioClip shootSound;
	public int numArrows = 3;
	public GameObject ArrowUI;
	private AudioSource source;
	private RectTransform ArrowRect;
	// Use this for initialization
	void Start () {
		ArrowRect = ArrowUI.GetComponent<RectTransform> ();
	}


	void Awake () {
		source = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > fireRate && Input.GetButtonUp("Fire"+PlayerString) && numArrows>0){
			//Fire Arrow
			Quaternion bulletRotation = Quaternion.LookRotation(transform.forward, -transform.right);
			Vector3 eulerRotation = bulletRotation.eulerAngles;
			bulletRotation = Quaternion.Euler(eulerRotation);
			source.PlayOneShot(shootSound,1.0f);

			//instantiate
			GameObject lazerClone = (GameObject)Instantiate(Lazer,transform.position+transform.up*2,bulletRotation);

			//set speed
			float lazerSpeed = speed;
			lazerClone.SendMessage("SetSpeed", lazerSpeed);

			timer = 0;
			numArrows--;
			//Debug.Log(ArrowRect.sizeDelta.x);
			//ArrowRect.sizeDelta = new Vector2(ArrowRect.sizeDelta.x-1,1);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "GroundArrow")
		{
			numArrows++;
            //ArrowRect.sizeDelta = new Vector2(ArrowRect.sizeDelta.x+1,1);			
            col.GetComponentInChildren<LightScript>().FadeAway(.25f);
            col.GetComponentInChildren<BoxCollider2D>().enabled = false;
            col.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            Destroy(col.gameObject, .25f);
        }	}
}
