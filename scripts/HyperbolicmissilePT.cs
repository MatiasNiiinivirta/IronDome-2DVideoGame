using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperbolicmissilePT : MonoBehaviour
{

    public ParticleSystem collisionParticleSystem;
    public ParticleSystem flame;
    public SpriteRenderer sr;
    public bool once = true;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D m2circle;
    public bool circ = false;
    float timer = 0f;
    public static bool hasNuclearHit = false;

    private void Start()
    {

        circ = false;
    }

    // Called when the object is clicked with the mouse. Only works when the time is normal (not paused or game over). Plays particleffect and gives different score on day or night. Because this is missile. It also destrous the flame.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building") && once)
        {
            hasNuclearHit = true;

           var em = collisionParticleSystem.emission;

            var dur = collisionParticleSystem.duration;


            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;

            circ = true;
            Destroy(flame);
            Destroy(boxCollider2D);
            Destroy(sr);


            if (circ == true)
            {
                m2circle.enabled = true;
            }


        }


    }


}
