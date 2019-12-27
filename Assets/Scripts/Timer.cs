using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timer;
    public Text text;
    public bool isCounting = true;
    public string niceTime;
    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCounting)
        timer += Time.deltaTime;


        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        text.text = niceTime;
    }
}
