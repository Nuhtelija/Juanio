using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This script load new level if player is zone and press jump button.
/// </summary>
public class LevelLoader : MonoBehaviour {

	public bool playerInZone;

	public string levelToLoad;



	// Use this for initialization
	void Start () {
		playerInZone = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Vertical") > 0 && playerInZone) {
			SceneManager.LoadScene(levelToLoad);
		}
	
	}

    /// <summary>
    /// Loads the level.
    /// </summary>
    public void LoadLevel(){
		SceneManager.LoadScene(levelToLoad);
	}

    /// <summary>
    /// Sets playInZone true when player is in zone
    /// </summary>
    /// <param name="other">The other.</param>
    void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			playerInZone = true;
		}
	}

    /// <summary>
    /// Sets playInZone false when player is not in zone
    /// </summary>
    /// <param name="other">The other.</param>
    void OnTriggerExit2D(Collider2D other){
		if (other.name == "Player") {
			playerInZone = false;
		}
	}
}
