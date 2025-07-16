using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D other)
 {
        //This code disposes the exploded bomb from the game
    if(other.CompareTag("Building"))
    {
        Debug.Log("Collided with ground");
        gameObject.SetActive(false);
    }
 }
}
