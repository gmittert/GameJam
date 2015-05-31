using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VictoryChecks : MonoBehaviour {
	private ArrayList playerlist = new ArrayList();
	public GameObject VictoryBanner;
	// Use this for initialization
	void Start () {
		playerlist.Add (1);
		playerlist.Add (2);
		playerlist.Add (3);
		playerlist.Add (4);
		
		VictoryBanner.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerlist.Count == 1) {
			Debug.Log ("Almost DONE");
			StartCoroutine(Endgame((int)playerlist[0]));
		} else if (playerlist.Count < 1) {
			StartCoroutine(Endgame(0));
		}
	}

	void deathNotice(int player){
		playerlist.Remove ((object)player);
		Debug.Log (playerlist.Count);
	}

	IEnumerator Endgame(int winner){
		Debug.Log ("DONE");
		Text VictoryText = VictoryBanner.GetComponent<Text> ();
		if (winner > 0) {
			VictoryText.text = "Player " + winner.ToString () + " wins!";
		} else {
			VictoryText.text = "Nobody wins.";
		}
		VictoryBanner.SetActive (true);
		
		yield return new WaitForSeconds(1);
		Application.LoadLevel (Application.loadedLevel);
	}
}
