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
        //find object with player tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //if found
        if (player != null)
        {
            //store animator and audio souce in variable
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
        //if velocity is less then 0
        if(collision.relativeVelocity.y <= 0)
        {
            //store rigidbody
            Rigidbody2D rb2D = collision.collider.GetComponent<Rigidbody2D>();
            //if rigidbody exists
            if (rb2D != null)
            {
                //set velocity to be rigidbody velocity
                Vector2 velocity = rb2D.velocity;
                //the velocity y movement becomes jumpheight
                velocity.y = jumpheight;
                //set rigidbody velocity to be velocity
                rb2D.velocity = velocity;
                //play bound audio
                Bounce.Play();
                //play animation Jumped;
                LeftRight.SetTrigger("Jumped");
                //if the doodle character is facing left play appropriate animation
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
