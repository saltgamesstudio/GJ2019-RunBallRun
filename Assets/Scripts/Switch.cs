using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isActive = false;
    public float openAmount = 7f;
    public float closeAmount = -1f;
    public Transform door;
    public Sprite onSwitch;
    public Sprite offSwitch;
    public SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    public void OpenDoor()
    {
            float openedPos = Mathf.Lerp(door.position.y, openAmount, .5f);
            door.position += new Vector3(0, openAmount, 0) ;
    }
    public void CloseDoor()
    {
            float closedPos = Mathf.Lerp(door.position.y, closeAmount, .5f);
            door.position = new Vector3(door.position.x, closeAmount, door.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isActive)
            {
                isActive = true;
                renderer.sprite = offSwitch;
                CloseDoor();
            } else
            {
                OpenDoor();
                isActive = false;
                renderer.sprite = onSwitch;
            }

        }

    }
}
