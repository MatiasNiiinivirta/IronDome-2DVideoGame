using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeAlpha : MonoBehaviour
{
    [SerializeField] private SpriteRenderer dome;

    [SerializeField] private Color myColor;
    void Start()
    {
        myColor.a = 2;
        dome.color = myColor;
    }

    void OnParticleCollision(GameObject other)
    {
            myColor.a += 1;
            Debug.Log("collided");
          
    }
}
