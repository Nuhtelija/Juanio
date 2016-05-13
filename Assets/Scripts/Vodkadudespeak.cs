using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Vodkadudespeak : MonoBehaviour {

	Text myText;
	///<summary>
	/// Use this for initialization
	///</summary>
	void Start () {
		///<summary>
		/// finds text box object
		/// </summary>
		myText = (Text)GameObject.Find ("myText").GetComponent<Text> ();
	}
	///<summary>
	/// Update is called once per frame
	///</summary>
	void Update () {
	
	}
	/// <summary>
	/// When player enters the area with 2D box collider text will apear on text object and when player wxits the area text will disapear
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			myText.text = "I'll let you pass if you do some Vodka for me. You need 3 buckets of water and 2 buckets of ethanol.";
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			myText.text = " ";
		}
	}
}
