using UnityEngine;
using System.Collections.Generic;

public class LightScript : MonoBehaviour {
    float radius;
    List<characterLight> characters;
    public bool overrideLight = false;
    float fadeTime = -1f;
    float age = 0f;
    float initialLightIntensity;

	// Use this for initialization
	void Start () {
        characters = new List<characterLight>();
        //makes the detection opject the same size as the light
        radius = GetComponent<Light>().range;
        GetComponent<CircleCollider2D>().radius = radius;
        initialLightIntensity = GetComponent<Light>().intensity;
    }
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;

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

    public void RemoveCharacter (characterLight character)
    {
        characters.Remove(character);
        Debug.Log("Removed: " + character);
    }

	void OnDisable()
	{
		foreach (characterLight character in characters)
		{
			character.removeLight(this);
		}
	}
	
	void OnDestroy()
	{
        foreach (characterLight character in characters)
        {
            character.removeLight(this);
        }
    }

    public void FadeAway(float timeToFade)
    {
        fadeTime = timeToFade;
        age = 0f;
        Destroy(gameObject, timeToFade);
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

        if (fadeTime != -1)
        {
            float percentDead = age / fadeTime;
            GetComponent<Light>().intensity = Mathf.Lerp(initialLightIntensity, 0f, percentDead);
            lightPercent *= percentDead;
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
