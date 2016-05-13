using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Load new game and quits the game.
/// </summary>
public class MainMenu : MonoBehaviour {

	public string startLevel;

    /// <summary>
    /// Load new game.
    /// </summary>
    public void NewGame(){
		SceneManager.LoadScene (startLevel);

	}

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame() {
		Application.Quit ();
	}


}
