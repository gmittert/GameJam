using UnityEngine;
using System.Collections;

public class AimAndShoot : MonoBehaviour {
	public float RotateSpeed = 10;
	public string PlayerString = "P1";

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform){ 
			Renderer[] renderers;
			if (child.name == "PreppedArrow"){
				renderers = child.gameObject.GetComponentsInChildren<Renderer>();
				foreach (Renderer r in renderers)
				{
					child.gameObject.SetActive(false);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		float aimHorizontal = 0;
		float aimVertical = 0;
		aimHorizontal = Input.GetAxis ("AimHorizontal"+PlayerString);
		aimVertical = Input.GetAxis("AimVertical"+PlayerString);
		
		Vector3 toAim = new Vector3(aimHorizontal,aimVertical,0);
		toAim.Normalize ();
		this.Aim (toAim);
		Renderer[] renderers;
		if (Input.GetButtonDown ("Fire" + PlayerString)) {
			foreach (Transform child in transform){ 
				if (child.name == "PreppedArrow"){
					child.gameObject.SetActive(true);
				}
			}
		}
		
		if (Input.GetButtonUp ("Fire" + PlayerString)) {
			foreach (Transform child in transform){ 
				if (child.name == "PreppedArrow"){
					renderers = child.gameObject.GetComponentsInChildren<Renderer>();
					foreach (Renderer r in renderers)
					{
						child.gameObject.SetActive(false);
					}
				}
			}
		}
	}
	
	void Aim(Vector3 targetAim){
		if (targetAim != Vector3.zero) {
			float step = RotateSpeed * Time.deltaTime;
			Vector3 newAim = Vector3.RotateTowards (transform.forward, targetAim, step, 0.0F);
			transform.rotation = Quaternion.LookRotation (Vector3.forward,newAim);
		}
	}
}
