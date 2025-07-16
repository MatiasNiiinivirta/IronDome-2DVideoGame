using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public AudioSource source;
    public AudioClip cliP;

    void Start()
    {
        // Starts repeatedly calling the Acceleration method every 1 second after a 1-second delay
        InvokeRepeating("Acceleration", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the missile downwards each frame, based on the current speed and frame time
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When missile collides with an object tagged "Building"
        if (other.CompareTag("Building"))
        {
            Debug.Log("Collided with building");
            speed = 0;
        }

    }
    // If game is running at normal speed or faster, stop the missile when clicked
    private void OnMouseDown()
    {
        if (Time.timeScale >= 1f)
        {
            speed = 0;
        }
    }

    public void Acceleration()
    {
        // Called repeatedly to increase the missile's speed and play a sound if it is still moving
        if (speed > 0)
        {
            speed += 18f;
            source.PlayOneShot(cliP);
        }
       
     
    }
}
