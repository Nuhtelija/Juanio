using UnityEngine;
using System.Collections;

/// <summary>
/// Controls many scripts of the game
/// </summary>
public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerScript player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	private CameraController camera;

	private float gravityStore;

	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerScript> ();

		camera = FindObjectOfType<CameraController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Respawns the player to nearest checkpoint. 
    /// </summary>
    public void RespawnPlayer(){

		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo (){

		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		camera.isFollowing = false;
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
		camera.isFollowing = true;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		yield return null;
	}

}
