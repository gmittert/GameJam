using UnityEngine;
using System.Collections;

public class LightTimer : MonoBehaviour {

	public Light light;
	// Use this for initialization
	void Start () {
		light = this.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		Light.intensity = 2;
	}
}
