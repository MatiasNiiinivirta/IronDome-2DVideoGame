using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip cliP;
    public AudioClip distantExplosion;
    public AudioClip ExplosionatSKy;
    public AudioClip explosion;


    void Start()
    {
        // Set the audio clip to cliP and start playing it
        source.clip = cliP;
        source.Play();
        // Play the distantExplosion sound effect once immediately after cliP starts
        source.PlayOneShot(distantExplosion);
    }
    private void OnMouseDown()
    {
        // When the object is clicked and the game is not paused or over,
        // stop current audio and play the ExplosionatSKy sound effect once
        if (Time.timeScale != 0 && GameOverHandler.GameOverIsOn == false)
        {
            source.Stop();
            source.PlayOneShot(ExplosionatSKy);
        }
 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // When this collider hits an object tagged "Building",
        // stop current audio and play the explosion sound once
        if (other.CompareTag("Building"))
        {
            source.Stop();
            source.PlayOneShot(explosion);
        }

    }

    public void SetPauseState(bool isPaused)
    {
        // Update the game's pause state and call the pause handler
        GameManagerScript.GameIsPaused = isPaused;
        PauseStopper(); 
    }

    private void PauseStopper()
	{
        // If the game is paused, stop playing any audio
        if (GameManagerScript.GameIsPaused == true)
		{
            source.Stop();
        }
	}


}
