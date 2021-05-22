using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > transform.position.y)
        {
            Vector3 newPos = transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
