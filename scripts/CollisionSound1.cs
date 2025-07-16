using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound1 : MonoBehaviour
{
    // Play demolition sound 
    public AudioSource source;
    public AudioClip collapseSound;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        
            source.PlayOneShot(collapseSound);
   
    }
}

