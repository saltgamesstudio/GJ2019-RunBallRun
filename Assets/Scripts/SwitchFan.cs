using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFan : MonoBehaviour
{
    public bool isActive = false;
    public float closeAmount = -1f;
    public GameObject onFan;
    public GameObject offFan;
    public SpriteRenderer renderer;
    public Sprite onSwitch;
    public Sprite offSwitch;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isActive)
            {
                isActive = true;
                onFan.SetActive(true);
                renderer.sprite = offSwitch;
            }
            else
            {
                isActive = false;
                onFan.SetActive(false);
                renderer.sprite = onSwitch;

            }

        }

    }
}
