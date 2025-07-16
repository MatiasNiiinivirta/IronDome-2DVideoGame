using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour

{
    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer sr;
    public BoxCollider2D boxCollider2D;
    public bool once = true;
    public AudioSource source;
    public AudioClip distantExplosion;

    public int score;

    public static bool enemyWasClicked = false; // Flag to prevent multiple triggers
    public static float lastEnemyClickTime = 0f;// Stores the time of the last click
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when the object is clicked with the mouse. Only works when the time is normal (not paused or game over). Plays particleffect and gives different score on day or night
    private void OnMouseDown()
    {

        if (Time.timeScale >= 1f && (sr != null))
        {
            lastEnemyClickTime = Time.time; // **Tallennetaan aika**
            enemyWasClicked = true;

            var em = collisionParticleSystem.emission;

            var dur = collisionParticleSystem.duration;

      
            em.enabled = true;
            collisionParticleSystem.Play();
            source.PlayOneShot(distantExplosion);
            once = false;

			if(DayNightCycle.isNight)
            {
                GameOver.ScoreAmount += score * 2;
                ScoreScript.ScoreAmount += score * 2;
                Debug.Log("Tuplapisteet");
            }
            else
			{
                GameOver.ScoreAmount += score;
                ScoreScript.ScoreAmount += score;
            }

            Destroy(boxCollider2D);
 
            Destroy(sr);

          
           Invoke(nameof(DestroyObj), dur);

        }  
    }

    // Destroys the object

    void DestroyObj()
    {

        Destroy(gameObject);
    }
}
