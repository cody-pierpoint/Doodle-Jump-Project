using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpheight = 10f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb2D = collision.collider.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 velocity = rb2D.velocity;
                velocity.y = jumpheight;
                rb2D.velocity = velocity;

            }
        }

    
      
    }

}
