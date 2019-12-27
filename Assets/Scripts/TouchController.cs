using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    public Button btnJump;
    public GameObject player;
    public PlayerController pc;
    public GameObject[] health = new GameObject[3];
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
        btnJump.onClick.AddListener(pc.Jump);
    }

    // Update is called once per frame
    void Update()
    {
        if (Starter.Health == 0)
        {
            Destroy(this);
        }
        btnJump.onClick.AddListener(pc.Jump);
        for (int i = 0; i < 3; i++)
        {
            if (i < Starter.Health)
            {
                health[i].SetActive(true);
            }
            else
            {
                health[i].SetActive(false);
            }
        }

    }
}
