using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouchMissile : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public ParticleSystem flame;
    public SpriteRenderer sr;
    public BoxCollider2D boxCollider2D;
    public bool once = true;
    public AudioSource source;
    public AudioClip distantExplosion;

    public int score;

    public static bool enemyWasClicked = false; 
    public static float lastEnemyClickTime = 0f;

    // Called when the object is clicked with the mouse. Only works when the time is normal (not paused or game over). Plays particleffect and gives different score on day or night. Because this is missile. It also destrous the flame.
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


            if (DayNightCycle.isNight)
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

            Destroy(flame);
            Destroy(boxCollider2D);
            Destroy(sr);
            Invoke(nameof(DestroyObj), dur);


        }



    }
    // Destroys the gameobject
    void DestroyObj()
    {

        Destroy(gameObject);

    }
}

