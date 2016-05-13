using UnityEngine;
using System.Collections;

public class SwitchArea : MonoBehaviour {


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {

            AudioSource audiosour = GameObject.Find("LevelManager").GetComponent<AudioSource>();
            audiosour.Stop();
            audiosour.clip = Resources.Load<AudioClip>("Jumpshot");
            audiosour.Play();
            GameObject.Find("Part1").SetActive(false);
        }
    }
}
