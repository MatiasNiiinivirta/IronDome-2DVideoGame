using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public int maxHealth = 8;
    public int damageAmount;
    public static int currentHealth;
    public Healthbar healtbar;
    public SpriteRenderer sr1, sr2;
    public GameObject light1;
    public PolygonCollider2D pg;

    // Runs once at the start; initializes health and updates health bar
    void Start()
    {
        currentHealth = maxHealth;
        healtbar.SetMaxHealth(maxHealth);
    }

    // Called automatically when another collider enters this object's trigger;
    // checks for collision with enemy and applies damage, disables visuals and collider
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Enemy"))
        {
            Destroy(pg);
            Destroy(sr1);
            Destroy(sr2);
			Destroy(light1);
			Debug.Log("Collided with ground");
            Destroy(gameObject, 5f);
            TakeDamage(damageAmount);

        }

    }


    // Reduces health by damage amount if damage > 0 and updates the health bar UI
    void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            Debug.Log("Ei damagea, palautetaan.");
            return; // Stops the function
        }

        Debug.Log($"TakeDamage kutsuttu! Damage: {damage}, Nykyinen elämä: {currentHealth}");
        currentHealth -= damage;
        healtbar.SetHealth(currentHealth);
    }

}
