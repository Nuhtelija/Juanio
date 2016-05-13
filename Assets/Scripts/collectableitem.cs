using UnityEngine;
using System.Collections;

public class collectableitem : MonoBehaviour {
	///<summary>
	/// Use this for initialization
	///</summary>
	void Start () {
	
	}
	///<summary>
	/// Update is called once per frame
	///</summary>
	void Update () {
	
	}
	/// <summary>
	/// If object collides with player tagged object it will be destroyed
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
