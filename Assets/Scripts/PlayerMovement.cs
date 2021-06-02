using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    float movement = 0f;
    Rigidbody2D rb2d;
    public Camera maincamera;
    bool isDead = false;
    public GameObject deathScreen;
    private float score;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] public Animator LeftRight;
    [SerializeField] public Animator flip;
    public float jumpheight = 10f;
    public AudioSource Bounce;
    public AudioSource GameMusic;
    public AudioSource DeathAudio;
   // public static PlayerMovement instance;

    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            isDead = value;
            deathScreen.SetActive(value);
            Time.timeScale = value ? 0 : 1;

        }
    }
    //void Awake()
    //{
    //    if (instance != null)
    //        Debug.LogError("More then one instance of playermovement in scene");

    //    instance = this;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
        deathScreen.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
        GameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(movement);
        if (transform.position.y <= maincamera.transform.position.y - 5f && !isDead)
        {
            Death();
        }
        
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //flip();
        if (movement < 0)
        {
            //isRight = true;
            //flip();
            LeftRight.SetFloat("IsLeft", 1);
        }

        else
        {
            //isRight = !isRight;
            //flip();
            LeftRight.SetFloat("IsLeft", -1);
        }


        if (transform.position.x <= -4f)
            transform.position = new Vector3(transform.position.x + 9, transform.position.y, transform.position.z);

        if (transform.position.x >= 4f)
            transform.position = new Vector3(transform.position.x - 9, transform.position.y, transform.position.z);
        scoring();
    }

    private void FixedUpdate()
    {

        Vector2 velocity = rb2d.velocity;
        velocity.x = movement;
        rb2d.velocity = velocity;
       
    }

    public void Death()
    {
        GameMusic.Stop();
        Debug.LogError("You are dead");
        IsDead = true;
        DeathAudio.Play();
        //if (IsDead == !IsDead)
        //{
        //    Time.timeScale = 0;
        //    deathScreen.SetActive(true);
        //}


    }

    void scoring()
    {
        if (transform.position.y > score)
        {
            score = transform.position.y;
            scoretext.text = score.ToString("F0");
        }
            

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.collider ==)
    //    {
    //        LeftRight.SetTrigger("Jumped");
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.y <= 0)
        {
            Bounce.Play();
            LeftRight.SetTrigger("Jumped");

            //    Rigidbody2D rb2D = collision.collider.GetComponent<Rigidbody2D>();
            //    if (rb2D != null)
            //    {
            //        Vector2 velocity = rb2D.velocity;
            //        velocity.y = jumpheight;
            //        rb2D.velocity = velocity;
            //        if (transform.rotation.y < 180f)
            //        {

            //            flip.SetTrigger("JumpedBack");
            //        }
            //        else
            //        {
            //            flip.SetTrigger("Jumped");
            //        }


            //    }

        }



    }

    public void save()
    {


    }

   public void load()
    {

    }
}
