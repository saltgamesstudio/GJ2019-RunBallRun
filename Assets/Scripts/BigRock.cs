using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRock : MonoBehaviour
{
    public bool isTriggered = false;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && isTriggered)
        {
            player.Die();
        }
    }
}
