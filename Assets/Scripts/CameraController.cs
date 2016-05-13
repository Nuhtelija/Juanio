using UnityEngine;
using System.Collections;

/// <summary>
/// This script set camera to follow player.
/// </summary>
public class CameraController : MonoBehaviour {

	public PlayerScript player;

    /// <summary>
    /// Sets camera to follow player
    /// </summary>
    public bool isFollowing;

    /// <summary>
    /// Developer can set camera place on X-axis
    /// </summary>
    public float xOffset;


    /// <summary>
    /// Developer can set camera place on Y-axis
    /// </summary>
    public float yOffset;

	void Start () {
		player = FindObjectOfType<PlayerScript> ();

		isFollowing = true;
	
	}

   
    /// <summary>
    /// Sets camera to follow player and developer can set camera position on X and Y-Axis
    /// </summary>
    void Update()
    {

        if (isFollowing)
            transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);

    }
}
