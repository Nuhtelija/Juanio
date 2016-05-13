using UnityEngine;
using System.Collections;

/// <summary>
/// Floor will fall after set delay
/// </summary>
public class PlatformFall : MonoBehaviour
{

    public float fallDelay = 1f;
    private Rigidbody2D platform;
    private BoxCollider2D box;

    void Awake()
    {
        platform = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.tag = "Finish";
        if (other.gameObject.CompareTag("Player"))
            Invoke("Fall", fallDelay);
    }

    void Fall()
    {
        platform.isKinematic = false;

    }
}
