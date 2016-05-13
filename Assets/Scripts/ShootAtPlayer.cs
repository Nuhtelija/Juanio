using UnityEngine;
using System.Collections;

/// <summary>
/// This script makes enemy shoot at player when player is on range.
/// </summary>
public class ShootAtPlayer : MonoBehaviour {

	public float playerRange;

	public GameObject enemyFire;

	public PlayerScript player;

	public Transform launchPoint;

	public float waitBetweenShots;

	private float shotCounter;

	// Use this for initialization
	void Start () {

		shotCounter = waitBetweenShots;
	
	}
	
	// Update is called once per frame
	void Update () {

		player = FindObjectOfType<PlayerScript> ();

		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z),new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));
		shotCounter -= Time.deltaTime;

		if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0) {
			Instantiate (enemyFire, launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShots;
		}

		if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0) {
			Instantiate (enemyFire, launchPoint.position, launchPoint.rotation);
			shotCounter = waitBetweenShots;
		}
	}
}
