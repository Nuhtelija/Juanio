using UnityEngine;
using System.Collections;

/// <summary>
/// This script gives to players bullet speed, damage and impact effect.
/// </summary>
public class NinjaStarController : MonoBehaviour {

	public float speed;

	public PlayerScript player;

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	public int damageToGive;


    // Use this for initialization
    /// <summary>
    /// Makes player shoot at right direction
    /// </summary>
    void Start () {
		player = FindObjectOfType<PlayerScript> ();

		if(player.transform.localScale.x < 0)
			speed = -speed;

	}

    // Update is called once per frame
    /// <summary>
    /// Gives bullet a speed.
    /// </summary>
    void Update () {

		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);

	}

    /// <summary>
    /// Gives enemy set damage when players bullet hit him.
    /// </summary>
    /// <param name="other">The other.</param>
    void OnTriggerEnter2D(Collider2D other){

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);

		if (other.tag == "Enemy") {
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);

			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}
	}
}