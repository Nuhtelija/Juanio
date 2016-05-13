using UnityEngine;
using System.Collections;

/// <summary>
/// This script destroys object that has use no more so it wont take memory for no reason
/// </summary>
public class DestroyObjectOverTime : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () {
	
	}

 
    /// <summary>
    /// Coounts down user set lifetime of the object and the destroys it.
    /// </summary>
    void Update () {

		lifetime -= Time.deltaTime;

		if (lifetime < 0) {
			Destroy (gameObject);
		}
	
	}
}
