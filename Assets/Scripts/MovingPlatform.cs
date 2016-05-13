using UnityEngine;
using System.Collections;

/// <summary>
/// Makes platform move as many point user wants.
/// </summary>
public class MovingPlatform : MonoBehaviour {

	public GameObject platform;

	public float moveSpeed;

	private Transform currenPoint;

	public Transform[] points;

	public int pointSelection;

    // Use this for initialization
    /// <summary>
    /// Takes points where user wants platform to move
    /// </summary>
    void Start () {

		currenPoint = points [pointSelection];
	
	}

    // Update is called once per frame
    /// <summary>
    /// Moves platform towards next position and when gets to position takes the next one.
    /// </summary>
    void Update () {

		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currenPoint.position, Time.deltaTime * moveSpeed);

		if (platform.transform.position == currenPoint.position) {

			pointSelection++;

			if (pointSelection == points.Length) {

				pointSelection = 0;
			}

			currenPoint = points [pointSelection];
		}
	
	}
}
