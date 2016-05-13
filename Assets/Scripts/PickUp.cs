using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public Transform start;
    public GameObject lights;
    public static int keys;
    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.name == "Player")
        {
            keys++;
            LightUp(keys);
            gameObject.SetActive(false);
        }
    }

    void LightUp(int keys)
    {
        GameObject.Instantiate(lights, new Vector2(start.position.x + (keys - 1), start.position.y), Quaternion.identity);
    }
}
