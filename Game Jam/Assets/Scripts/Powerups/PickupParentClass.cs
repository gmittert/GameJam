using UnityEngine;
using System.Collections;

public abstract class PickupParentClass : MonoBehaviour {
    public float fadeTime = .25f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject parent = other.transform.parent.gameObject;

            UsePickup(parent);

            Destroy(gameObject, fadeTime);
            GetComponentInChildren<LightScript>().FadeAway(fadeTime);
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
    }

    public virtual void UsePickup( GameObject parent)
    {
        Debug.Log("Pickup not overridden!");
    }

    void OnDestroy()
    {
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            if (spawner.activeSelf) //IAN: doesn't work. check if its about to be deleted
            {
                spawner.SendMessage("Reset");
            }
            
        }

    }
}
