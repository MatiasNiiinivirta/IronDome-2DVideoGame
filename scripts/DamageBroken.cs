using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBroken : MonoBehaviour
{
    //public int maxHealth = 8;
    public int currentHealth;
    public Healthbar healtbar;

    private void OnTriggerEnter2D(Collider2D other)
    {

        // Called automatically when another collider enters this object's trigger;
        // if collided with an enemy, logs the event and disables this game object
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collided with ground");
            gameObject.SetActive(false);
            //TakeDamage(1);

        }
    }


}
