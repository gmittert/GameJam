using UnityEngine;
using System.Collections.Generic;

public class characterLight : MonoBehaviour {

    Dictionary<LightScript, float> lights;

	// Use this for initialization
	void Start () {
        lights = new Dictionary<LightScript, float>();
	}
	
	// Update is called once per frame
	void Update () {
        SetTransperency();
	}

    void SetTransperency ()
    {
        float alpha = 0f;
        foreach (KeyValuePair<LightScript,float> light in lights)
        {
            alpha += light.Value;
        }
        Color spiteColour = GetComponentInChildren<SpriteRenderer>().color;
        spiteColour.a = alpha;
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.color = spiteColour;
        }
    }

    public void updateTransperencyByLight(LightScript light, float transperency)
    {
        if (lights.ContainsKey(light))
        {
            lights[light] = transperency;
        }
        else
        {
            lights.Add(light, transperency);
        }
    }

    public void removeLight (LightScript light)
    {
        lights.Remove(light);
    }

    void OnDestroy()
    {
        Debug.Log("Removing characters");
        foreach (KeyValuePair<LightScript, float> light in lights)
        {
            light.Key.RemoveCharacter(this);
        }
    }
}
