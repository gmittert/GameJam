using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Die(int a){
		Debug.Log ("I'm Dead!");
		Transform parent = transform.parent;
		parent.SendMessage ("Die",1);
	}
}
