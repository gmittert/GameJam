using UnityEngine;
using System.Collections;

public class MoreArrows : MonoBehaviour {
    
    public float fadeTime = .25f;
    public int arrowsToAdd = 2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject parent = other.transform.parent.gameObject;
            int arrows = parent.GetComponentInChildren<Gunfire>().numArrows;
            parent.GetComponentInChildren<Gunfire>().numArrows = arrows + arrowsToAdd;
			parent.GetComponentInChildren<Gunfire>().ArrowRect.sizeDelta = new Vector2(parent.GetComponentInChildren<Gunfire>().ArrowRect.sizeDelta.x+arrowsToAdd,1);

            Destroy(gameObject, fadeTime);
            GetComponentInChildren<LightScript>().FadeAway(fadeTime);
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);


        }
    }

    void OnDestroy()
    {
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawner.SendMessage("Reset");
        }

    }
}
