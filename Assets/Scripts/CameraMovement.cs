using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    Vector3 velocity = Vector3.zero;
    public Vector3 maxPos;
    public Vector3 minPos;
    public float smoothTime = .125f;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }


    private void FixedUpdate()
    {
        Vector3 playerPos = player.position;

        playerPos.x = Mathf.Clamp(player.position.x, minPos.x, maxPos.x);
        playerPos.y = Mathf.Clamp(player.position.y, minPos.y, maxPos.y);

        playerPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smoothTime);
    }
}
