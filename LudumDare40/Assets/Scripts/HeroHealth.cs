using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealth : MonoBehaviour {
    
    BoxCollider2D bc2d;
    // Use this for initialization
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        print("Mouse");
        if (coll.gameObject.CompareTag("Enemy"))
        {
            print("Leg");
        }
        if (coll.gameObject.CompareTag("Mouse"))
            print("Mouse");
    }
}
