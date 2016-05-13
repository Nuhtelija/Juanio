using UnityEngine;
using System.Collections;

public class IfKeys : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player" && PickUp.keys == 3)
        {
            gameObject.GetComponentInChildren<MovingPlatform>().enabled = true;
        }
    }
}
