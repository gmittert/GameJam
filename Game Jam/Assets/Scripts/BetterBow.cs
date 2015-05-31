using UnityEngine;
using System.Collections;

public class BetterBow : MonoBehaviour {

    public float lightUpLength = 2.0f;
    public float fadeTime = .25f;
    public float factorToIncreaseBowStrength = 2f;

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
            float speed = parent.GetComponentInChildren<Gunfire>().speed;
            parent.GetComponentInChildren<Gunfire>().speed = speed * factorToIncreaseBowStrength;

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
