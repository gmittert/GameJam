using UnityEngine;
using System.Collections.Generic;

public class LightScript : MonoBehaviour {
    float radius;
    List<characterLight> characters;
    public bool overrideLight = false;

	// Use this for initialization
	void Start () {
        characters = new List<characterLight>();
        //makes the detection opject the same size as the light
        radius = GetComponent<Light>().range;
        GetComponent<CircleCollider2D>().radius = radius;
    }
	
	// Update is called once per frame
	void Update () {
        foreach (characterLight character in characters)
        {
            character.updateTransperencyByLight(this, GetLightValue(character.transform.position));
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            characters.Add(other.GetComponentInParent<characterLight>());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<characterLight>().removeLight(this);
            characters.Remove(other.GetComponentInParent<characterLight>());
        }
    }

    void OnDestroy()
    {
        foreach (characterLight character in characters)
        {
            character.removeLight(this);
        }
    }

    float GetLightValue( Vector2 position )
    {
        float lightPercent = Mathf.Max(radius - GetDistance(position), 0f) / radius;

        if (overrideLight)
        {
            if (lightPercent >= 0.5f)
            {
                lightPercent = 0.75f + (lightPercent - .5f) / 2f;
            }
            else
            {
                lightPercent *= 1.5f;
            }
        }
        else
        {
            if (lightPercent >= 0.5f)
            {
                lightPercent = (lightPercent / 4f) + (lightPercent - 0.5f) * 1.5f;
            }
            else
            {
                lightPercent /= 4f;
            }
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
