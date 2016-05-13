using UnityEngine;
using System.Collections;

/// <summary>
/// This script makes enemy patrol. Enemy walks until he hits wall or edge and then turns around.
/// </summary>
public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool notAtEdge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    /// <summary>
    /// Checks if enemy is on edge or hitting wall. If this is true enemy turn around and keeps on moving.
    /// </summary>
    void Update () {
		
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge)
			moveRight = !moveRight;

		if (moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}
}
