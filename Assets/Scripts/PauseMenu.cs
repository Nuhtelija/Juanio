using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This script puts game on pause when Escape is pressed.
/// </summary>
public class PauseMenu : MonoBehaviour {

	public string levelSelect;

	public string mainMenu;

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    /// <summary>
    /// Sets Pause Menu active when escape is pressed and takes it away when pressed again.
    /// </summary>
    void Update () {

		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			PauseUnpause ();
		}
	
	}

    /// <summary>
    /// Pauses and unpauses the game when called.
    /// </summary>
    public void PauseUnpause() {
		isPaused = !isPaused;
	}

    /// <summary>
    /// Resumes game when resume button is pressed in pause menu.
    /// </summary>
    public void Resume(){
		isPaused = false;
	}

    /// <summary>
    /// Load main menu the game when quit to main menu button is pressed.
    /// </summary>
    public void QuitGame(){

		SceneManager.LoadScene (mainMenu);
	}
}
