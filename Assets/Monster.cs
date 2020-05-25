using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {

        bool didHitBird = collision.collider.GetComponent<Bird>() != null;

        if (didHitBird) {
            Destroy(gameObject);
            return;
        }

        Monster monster = collision.collider.GetComponent<Monster>();
        if (monster != null) {
            return;
        }

        if (collision.contacts[0].normal.y <-0.5) {
            Destroy(gameObject);
        }
        
    }
    
}
