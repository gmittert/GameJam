using UnityEngine;
//using System.Collections.Generic;

public class LightScript : MonoBehaviour {
    float radius;
    //List<characterLight> characters;

	// Use this for initialization
	void Start () {
        //makes the detection opject the same size as the light
        radius = GetComponent<Light>().range;
        GetComponent<CircleCollider2D>().radius = radius;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<characterLight>().removeLight(this);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<characterLight>().updateTransperencyByLight(this, GetLightValue(other.transform.position));
        }
    }

        float GetLightValue( Vector2 position )
    {
        float lightPercent = Mathf.Max(radius - GetDistance(position), 0f) / radius;

        if (lightPercent >= 0.5f)
        {
            lightPercent += (lightPercent / 4f) + (lightPercent - 0.5f) * 1.5f;
        }
        else
        {
            lightPercent /= 4f;
        }

        return lightPercent;
    }

    float GetDistance ( Vector2 position)
    {
        Vector2 difference = this.transform.position;
        difference -= position;
        return Mathf.Sqrt(Mathf.Pow(difference.x, 2f) + Mathf.Pow(difference.y, 2f));
    }
}
