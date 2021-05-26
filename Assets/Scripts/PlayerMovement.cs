using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    [SerializeField] TextMeshProUGUI scoreText;

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

    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= maincamera.transform.position.y - 5f && !isDead)
        {
            Death();
        }
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (transform.position.x <= -6f)
            transform.position = new Vector3(transform.position.x + 13, transform.position.y, transform.position.z);

        if (transform.position.x >= 6f)
            transform.position = new Vector3(transform.position.x - 13, transform.position.y, transform.position.z);
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
        Debug.LogError("You are dead");
        IsDead = true;
        //if (IsDead == !IsDead)
        //{
        //    Time.timeScale = 0;
        //    deathScreen.SetActive(true);
        //}


    }

    void scoring()
    {
        if(transform.position.y > score)
        {
            score = transform.position.y;
            scoreText.text = score.ToString("F0");
        }
        


    
    }



}
