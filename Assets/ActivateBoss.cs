using UnityEngine;
using System.Collections;


/// <summary>
/// Activates the player when stepped into given trigger
/// </summary>
public class ActivateBoss : BossAI
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            GameObject.Find("Boss").GetComponent<BossAI>().Fight();
            gameObject.SetActive(false);
        }
    }
}
