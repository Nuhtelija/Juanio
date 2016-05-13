using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys deathparticles that have no use no more so they wont use memory. 
/// </summary>
public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem> ();
	
	}

    // Update is called once per frame
    /// <summary>
    /// Check if particle is still playing. If not then destroys it.
    /// </summary>
    void Update()
    {
        if (thisParticleSystem.isPlaying)
            return;

        Destroy(gameObject);

    }

    void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
