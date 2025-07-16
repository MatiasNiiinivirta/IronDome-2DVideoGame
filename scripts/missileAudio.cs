using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip cliP;
    public AudioClip explosion;


    void Start()
    {
        source.clip = cliP;          // Set the AudioSource clip to the missile flying sound
        source.Play();               // Play the flying sound immediately

    }
    // Called when the user clicks the mouse button on this object
    private void OnMouseDown()
    {
        if (Time.timeScale != 0 && GameOverHandler.GameOverIsOn == false)
        {
            source.Stop();
            source.PlayOneShot(explosion);
        }
    }

    // Called when the object collides with another collider marked as "Building"

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            source.PlayOneShot(explosion);
        }

    }
}

