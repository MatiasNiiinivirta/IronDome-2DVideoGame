using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{

    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer sr;
    public bool once = true;
    public BoxCollider2D boxCollider2D;



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Called when this object's collider enters another collider marked as a trigger.
        // Checks if the other collider's GameObject has the tag "Building" and if this is the first trigger event (once == true).
        if (other.gameObject.CompareTag("Building") && once) {

           var em = collisionParticleSystem.emission;

           var dur = collisionParticleSystem.duration;

         
           em.enabled = true;
           collisionParticleSystem.Play();

           once = false;
      
            
            Destroy(boxCollider2D);
            Destroy(sr);
           Invoke(nameof(DestroyObj), dur);

      

        }

     
    }
    
    void DestroyObj() 
    {
        // Destroys this entire GameObject
        Destroy(gameObject);  

    }
    
}
