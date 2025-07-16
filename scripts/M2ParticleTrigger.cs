using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2ParticleTrigger : MonoBehaviour
{

    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer sr;
    public bool once = true;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D m2circle;
    public bool circ = false;
    float timer = 0f;

    private void Start()
    {

        circ = false;
    }

    // Triggers the particle effect for Mortar 2 and activates an area-of-effect circle to destroy multiple buildings
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building") && once)
        {

            var em = collisionParticleSystem.emission;

            var dur = collisionParticleSystem.duration;


            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;

            circ = true;
            Destroy(boxCollider2D);
            Destroy(sr);
            Invoke(nameof(DestroyObj), dur);

            if (circ == true)
            {
                m2circle.enabled = true;
            }


        }


    }

    void DestroyObj()
    {

        Destroy(gameObject);

    }

}
