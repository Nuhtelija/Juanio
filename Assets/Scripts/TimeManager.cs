using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script counts down user set playing time and load game over screen when timer hits 0.
/// After game over screen script load main menu.
/// </summary>
public class TimeManager : MonoBehaviour {

	public float startingTime;


	private Text theText;

	private PauseMenu thePauseMenu;

	public GameObject gameOverScreen;

	public PlayerScript player;

	public float waitAfterGameOver;

	// Use this for initialization
	void Start () {

		theText = GetComponent<Text> ();

		thePauseMenu = FindObjectOfType<PauseMenu> ();

		player = FindObjectOfType<PlayerScript> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (thePauseMenu.isPaused)
			return;

		startingTime -= Time.deltaTime;

		if (startingTime <= 0) {
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

		if (gameOverScreen.activeSelf) {
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 0) {
			SceneManager.LoadScene ("MainMenu");
		}

		theText.text = "" + Mathf.Round (startingTime);
	
	}
}
