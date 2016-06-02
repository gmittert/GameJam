using UnityEngine;
using System.Collections.Generic;

public class PlayerLight : MonoBehaviour {

    Dictionary<LightScript, float> lights;
    private SpriteRenderer characterSpritRender;
    private SpriteRenderer arrowSpritRender;
    void Start () {
        lights = new Dictionary<LightScript, float>();
        characterSpritRender = GetComponent<SpriteRenderer>();
        arrowSpritRender = GetComponentInChildren<SpriteRenderer>();
    }
	
	void Update () {
        //SetTransperency();
	}

    public void SetTransperency ()
    {
        float alpha = 0f;
        foreach (KeyValuePair<LightScript,float> light in lights)
        {
            alpha += light.Value;
        }
        Color spiteColour = characterSpritRender.color;
        spiteColour.a = alpha; //TODO this should be clamped
        characterSpritRender.color = spiteColour;
        arrowSpritRender.color = spiteColour;
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
        GameManager.Log("Removing characters", this, LogLevel.Verbose);
        foreach (KeyValuePair<LightScript, float> light in lights)
        {
            light.Key.RemoveCharacter(this);
        }
    }
}
