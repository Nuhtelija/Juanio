using UnityEngine;
using System.Collections;

public class PickUpKey : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
