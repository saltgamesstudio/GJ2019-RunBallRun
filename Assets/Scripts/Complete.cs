using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Complete : MonoBehaviour
{
    public GameObject completeUI;
    public GameObject timerObject;
    public GameObject timerObjectComplete;
    public Text txtTimer;
    public Text txtTimerObjectComplete;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timerObject = GameObject.Find("Timer");
        txtTimerObjectComplete = timerObjectComplete.GetComponent<Text>();
        timer = timerObject.GetComponent<Timer>();
        txtTimer = timerObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            completeUI.SetActive(true);
            timer.isCounting = false;

            txtTimerObjectComplete.text = timer.niceTime;
        }
    }
}
