using UnityEngine;
using System.Collections;

public class AimAndShoot : MonoBehaviour {
	public float RotateSpeed = 10;
	// Use this for initialization
	void Start () {
	
	}

	Vector3 getInputDirection(){
		// TODO: Add controller support here
		Vector3 inputPos = Input.mousePosition;
		inputPos.Normalize ();
		return inputPos;
	}
	// Update is called once per frame
	void Update () {
		Vector3 characterPos = this.transform.position;
		characterPos.Normalize ();
		this.Aim (getInputDirection() - characterPos);
	}

	void Aim(Vector3 targetAim){
		if (targetAim != Vector3.zero) {
			float step = RotateSpeed * Time.deltaTime;
			Vector3 newAim = Vector3.RotateTowards (transform.forward, targetAim, step, 0.0F);
			transform.rotation = Quaternion.LookRotation (Vector3.forward,newAim);
		}
	}
}
