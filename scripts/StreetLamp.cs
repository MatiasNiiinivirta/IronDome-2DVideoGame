using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLamp : MonoBehaviour
{
    public GameObject streetlamp;

    public GameObject streetlamp2;

    public GameObject straatlamp3;
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Enemy"))
        {

            Destroy(streetlamp);
            Destroy(streetlamp2);
            Destroy(straatlamp3);

        }
    }


}
