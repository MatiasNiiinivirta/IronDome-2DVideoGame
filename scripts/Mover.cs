using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the GameObject downward at the set speed, adjusted by frame time.
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

     private void OnTriggerEnter2D(Collider2D other)
 {
        // Called when this object's collider enters a trigger collider.
        // If the other collider has the tag "Building", stop movement by setting speed to 0.
        if (other.CompareTag("Building"))
    {
        Debug.Log("Collided with building");
        speed = 0;
    }

}
    private void OnMouseDown()
    {
        // Called when the user clicks on the GameObject's collider.
        // If the game is running (time scale >= 1), stop movement by setting speed to 0.
        if (Time.timeScale >= 1f)
        {
            speed = 0;
        }
    }
}
