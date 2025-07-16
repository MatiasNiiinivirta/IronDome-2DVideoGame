using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleTriggerMissile : MonoBehaviour
{

    public ParticleSystem collisionParticleSystem;
    public ParticleSystem flame;
    public SpriteRenderer sr;
    public bool once = true;
    public BoxCollider2D boxCollider2D;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building") && once)
        {

            var em = collisionParticleSystem.emission;

            var dur = collisionParticleSystem.duration;


            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;

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

