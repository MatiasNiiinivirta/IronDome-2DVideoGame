using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotNuclearBomb : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public ParticleSystem flame;
    public SpriteRenderer sr;
    public BoxCollider2D boxCollider2D;
    public bool once = true;
    public AudioSource source;
    public AudioClip distantExplosion;

    public static bool enemyWasClicked = false;
    public static float lastEnemyClickTime = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when the object is clicked with the mouse. Only works when the time is normal (not paused or game over). Plays particleffect and gives different score on day or night. Because this is Nuclear. It also destrous the flame.
    private void OnMouseDown()
    {
        if (Time.timeScale >= 1f && (sr != null))
        {

            var em = collisionParticleSystem.emission;

            var dur = collisionParticleSystem.duration;


            em.enabled = true;
            collisionParticleSystem.Play();
            source.PlayOneShot(distantExplosion);
            once = false;

            if (DayNightCycle.isNight)
            {
                GameOver.ScoreAmount += 100;
                ScoreScript.ScoreAmount += 100;
                Debug.Log("Tuplapisteet");
            }
            else
            {
                GameOver.ScoreAmount += 50;
                ScoreScript.ScoreAmount += 50;
            }

            Destroy(flame);
            Destroy(boxCollider2D);
            Destroy(sr);
            Invoke(nameof(DestroyObj), dur);
          

        }



    }

    void DestroyObj()
    {

        Destroy(gameObject);

    }
}

