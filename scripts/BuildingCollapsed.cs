using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollapsed : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D other)
 {
        //Buildings collapse on contact with enemy

    if(other.CompareTag("Enemy"))
    {
        Debug.Log("Collided with ground");
        gameObject.SetActive(false);

    }
 }
}

