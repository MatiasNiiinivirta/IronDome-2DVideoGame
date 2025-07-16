using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBusstop : MonoBehaviour
{
    public GameObject busstop;

	public GameObject SettingsButton;

    public GameObject SettingsButtonBroken;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // busstop breaks on contact with enemy

        if (other.CompareTag("Enemy"))
        {
         

            SettingsButton.SetActive(false);

            SettingsButtonBroken.SetActive(true);


            Destroy(busstop);
        }
    }

    void DestroyObj()
    {

        Destroy(gameObject);

    }
}

