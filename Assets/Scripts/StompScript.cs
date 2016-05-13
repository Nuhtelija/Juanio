using UnityEngine;
using System.Collections;

public class StompScript : MonoBehaviour {

	public GameObject impactEffect;

	public LevelManager levelManager;

	// Use this for initialization
	void Start () {

		levelManager = FindObjectOfType<LevelManager> ();
	
	}


		/// <summary>
		/// Kills player on hit.
		/// </summary>
		/// <param name="other"></param>
		void OnTriggerEnter2D(Collider2D other){

			//Instantiate (impactEffect, transform.position, transform.rotation);


			if (other.name == "Player") {
			other.GetComponent<AudioSource>().Play ();
			levelManager.RespawnPlayer ();
			}
	
	}
}
