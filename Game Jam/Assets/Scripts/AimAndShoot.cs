using UnityEngine;
using System.Collections;

public class AimAndShoot : MonoBehaviour {
	public float RotateSpeed = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float aimHorizontal = 0;
		float aimVertical = 0;


		//aimHorizontal = Input.GetAxis ("X Axis");
			
		//aimVertical = Input.GetAxis("Y Axis");



		Vector3 toAim = new Vector3(aimHorizontal,aimVertical,0);
		toAim.Normalize ();
		this.Aim (toAim);

	}

	void Aim(Vector3 targetAim){
		if (targetAim != Vector3.zero) {
			float step = RotateSpeed * Time.deltaTime;
			if (targetAim == transform.forward*-1){ //if this is the exact opposite it will not rotate, this deals with that.
				targetAim.y+=0.5F;
				targetAim.x+=0.5F;
			}
			Debug.Log(targetAim.ToString());
			Vector3 newAim = Vector3.RotateTowards (transform.forward, targetAim, step, 0.0F);

			transform.rotation = Quaternion.LookRotation (newAim);
		}
	}
}
