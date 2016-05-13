using UnityEngine;
using System.Collections;

/// <summary>
/// This script gives enemy health. If health drops to 0, then enemy will be destroyed.
/// </summary>
public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;

<<<<<<< HEAD
	public GameObject deathEffect;
    public GameObject levelexit;

	// Use this for initialization
	void Start () {
	
	}
=======
<<<<<<< HEAD
	public GameObject deathEffect;
    public GameObject levelexit;
=======
    public GameObject deathEffect;

>>>>>>> master

    // Use this for initialization
    void Start()
    {

    }
>>>>>>> origin/master

    // Update is called once per frame
    /// <summary>
    /// Used deatheffect when enemy health drops to 0 and destroys enemy
    /// </summary>
<<<<<<< HEAD
    void Update () {
        if (enemyHealth <= 0 && gameObject.name == "Boss1") {
=======
<<<<<<< HEAD
    void Update () {
        if (enemyHealth <= 0 && gameObject.name == "Boss1") {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Instantiate(levelexit, transform.position, transform.rotation);
        }
		if (enemyHealth <= 0) {
			Instantiate (deathEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	
	}
=======
    void Update()
    {
        if (enemyHealth <= 0)
        {
>>>>>>> origin/master
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Instantiate(levelexit, transform.position, transform.rotation);
        }
<<<<<<< HEAD
		if (enemyHealth <= 0) {
			Instantiate (deathEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	
	}
=======

    }
>>>>>>> master
>>>>>>> origin/master

    /// <summary>
    /// Gives damage to enemy and play sound on hit.
    /// </summary>
    /// <param name="damageToGive">The damage to give.</param>
    public void giveDamage(int damageToGive) {
		enemyHealth -= damageToGive;
		GetComponent<AudioSource>().Play ();
	}
}
