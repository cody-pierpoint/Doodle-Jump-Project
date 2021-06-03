using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Jumping : MonoBehaviour
{
    public float jumpheight = 10f;
    [SerializeField] private GameObject doodleCharacter;
    private float doodleRot;
    public AudioSource Bounce;

    [SerializeField] Animator LeftRight;

    // PlayerMovement animate;
    [SerializeField] public Animator flip;


    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            LeftRight = player.GetComponent<Animator>();
            Bounce = player.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("Could not find player tag in the scene");
        }
    }

    // void OnTriggerEnter2D(Collider cube);
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
                Bounce.Play();
                LeftRight.SetTrigger("Jumped");
                if (doodleCharacter.transform.rotation.y < 180f)
                {

                    LeftRight.SetTrigger("JumpedBack");
                }
                
                
               
                
                //if (doodleCharacter.transform.rotation.y < 180f)
                //{

                //    flip.SetTrigger("JumpedBack");
                //}
                //else
                //{
                //   flip.SetTrigger("Jumped");
                //}
                //  flip = doodleCharacter.GetComponent(Animator);

            }
           
        }

    
      
    }
  

}
