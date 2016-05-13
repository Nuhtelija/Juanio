using UnityEngine;
using System.Collections;

/// <summary>
/// This script makes background move so it feels more realistic.
/// </summary>
public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;

    /// <summary>
    /// Sets the scale how much background moves when the player moves
    /// </summary>
    private float[] parallaxScales;

	public float smoothing;

	private Transform cam;
	private Vector3 previousCamPos;

	// Use this for initialization
	void Start () {
		cam = Camera.main.transform;

		previousCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];

		for(int i = 0; i < backgrounds.Length; i++){
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0; i < backgrounds.Length; i++){

			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			float backgroundTargetPosX = backgrounds [i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds [i].position.y, backgrounds [i].position.z);

			backgrounds [i].position = Vector3.Lerp (backgrounds [i].position, backgroundTargetPos, smoothing * Time.deltaTime);
			
		}

		previousCamPos = cam.position;
	
	}
}
