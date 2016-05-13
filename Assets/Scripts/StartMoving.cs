using UnityEngine;
using System.Collections;

public class StartMoving : MonoBehaviour {


    GameObject platform;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            gameObject.GetComponentInChildren<MovingPlatform>().enabled = true;
        }
    }
}
