using UnityEngine;
using System.Collections;

/// <summary>
///  This script checks if player is on ladder zone or not
/// </summary>
public class LadderZone : MonoBehaviour {

	private PlayerScript thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerScript> ();
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "Player") {
			thePlayer.onLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.name == "Player") {
				thePlayer.onLadder = false;
		}
	}

}
