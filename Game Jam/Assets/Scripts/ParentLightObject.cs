using UnityEngine;

public abstract class ParentLightObject : MonoBehaviour
{

    public float defaultFadeTime = .25f;

    public virtual float getFadeTime()
    {
        return defaultFadeTime;
    }

    public void fadeObjectAway()//GameObject gameObject)
    {
        Destroy(gameObject, getFadeTime());
        GetComponentInChildren<LightScript>().FadeAway(getFadeTime());
        GetComponent<SpriteRenderer>().enabled = false;//color = new Color(255, 255, 255, 0);
    }
}
