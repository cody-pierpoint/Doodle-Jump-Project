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
    [HideInInspector] public float score;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] public Animator LeftRight;
    [SerializeField] public Animator flip;
    [SerializeField] private TextMeshProUGUI highScoreText;
    public float jumpheight = 10f;
    public AudioSource Bounce;

    public AudioSource DeathAudio;
    private float highScore;
    public float HighScore
    {
        get { return highScore; }
        set
        {
            highScore = value;
            highScoreText.text = highScore.ToString("N0");
        }
    }


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



    void Start()
    {
        //main camera is the camer.main
        maincamera = Camera.main;
        //death screen set to inactive
        deathScreen.SetActive(false);
        //grab rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
        //load score
        Load();
    }

    // Update is called once per frame
    void Update()
    {

        //if players y becomes lower then cameras y and is alive
        if (transform.position.y <= maincamera.transform.position.y - 5f && !isDead)
        {
            //kill player
            Death();
        }
        //movement stores the horizontal input
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        //if movement axis value is less then 0 
        if (movement < 0)
        {
            // player faces left
            LeftRight.SetFloat("IsLeft", 1);
        }

        else
        {

            //player faces right
            LeftRight.SetFloat("IsLeft", -1);
        }

        //if player x is less then -4
        if (transform.position.x <= -4f)
            //teleport player to other side of the screen
            transform.position = new Vector3(transform.position.x + 9, transform.position.y, transform.position.z);

        //if player x is greater than 4
        if (transform.position.x >= 4f)
            //teleport player to the other side of screen
            transform.position = new Vector3(transform.position.x - 9, transform.position.y, transform.position.z);
        //update scoring
        Scoring();
    }

    private void FixedUpdate()
    {
        //store rigidbody velocity in velocty
        Vector2 velocity = rb2d.velocity;
        //velocity x = movement
        velocity.x = movement;
        //set velocty back to rigidbody Velocity
        rb2d.velocity = velocity;

    }

    public void Death()
    {
        //GameMusic.Stop();
        Debug.Log("You are dead");
        //player is dead
        IsDead = true;
        //if score is greater than high score
        if (score >= HighScore)
            //save high score
            Save();
        //play death audio
        DeathAudio.Play();



    }

    void Scoring()
    {
        //if players y is greater than score 
        if (transform.position.y > score)
        {
            //score becomes players y
            score = transform.position.y;
            //show score as text
            scoretext.text = score.ToString("N0");
            //if score is greater then highscore
            if (score > HighScore)
            {
                //score becomes highscore
                HighScore = score;
            }
        }


    }

    public void Save()
    {
        //save
        SaveSystem.SavePlayer(this);

    }

    public void Load()
    {
        //load
        PlayerData data = SaveSystem.LoadPlayer();
        //if data exists highscore = data.scores;
        if (data != null)
            HighScore = data.Scores;

    }
}
