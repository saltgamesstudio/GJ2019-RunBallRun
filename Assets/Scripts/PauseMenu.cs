using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject menuUI;

    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        menuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
