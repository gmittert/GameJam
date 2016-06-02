using UnityEngine;
using System.Collections.Generic;

public class LightScript : MonoBehaviour {
    float radius;
    List<PlayerLight> characters;
    public bool overrideLight = false;
    float fadeTime = -1f;
    float age = 0f;
    float initialLightIntensity;

	// Use this for initialization
	void Start () {
        characters = new List<PlayerLight>();
        //makes the detection opject the same size as the light
        radius = GetComponent<Light>().range;
        GetComponent<CircleCollider2D>().radius = radius;
        initialLightIntensity = GetComponent<Light>().intensity;
    }
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        List<PlayerLight> toRemove = null;
        foreach (PlayerLight character in characters)
        {
            if (character == null)
            {
                if (toRemove == null)
                {
                    toRemove = new List<PlayerLight>();
                }
                toRemove.Add(character);
            }
            else
            {
                character.updateTransperencyByLight(this, GetLightValue(character.transform.position));
            }
        }
        if (toRemove != null)
        {
            foreach (PlayerLight character in toRemove)
            {
                characters.Remove(character);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            characters.Add(other.GetComponentInParent<PlayerLight>());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<PlayerLight>().removeLight(this);
            characters.Remove(other.GetComponentInParent<PlayerLight>());
        }
    }

    public void RemoveCharacter (PlayerLight character)
    {
        characters.Remove(character);
        Debug.Log("Removed: " + character);
    }

	void OnDisable()
	{
        if (characters == null)
        {
            return;
        }
		foreach (PlayerLight character in characters)
		{
			character.removeLight(this);
		}
	}
	
	//void OnDestroy()
	//{
 //       foreach (characterLight character in characters)
 //       {
 //           character.removeLight(this);
 //       }
 //   }

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
