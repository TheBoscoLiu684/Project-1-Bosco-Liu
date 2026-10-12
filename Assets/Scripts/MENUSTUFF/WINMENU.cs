using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WINMENU : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI finalTime;
    void Start()
    {
        int minutes = Mathf.FloorToInt(GameManager.instance.time / 60);
        int seconds = Mathf.FloorToInt(GameManager.instance.time % 60);
        finalTime.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressRetry()
    {
        GameManager.instance.time = 0f;
        GameManager.instance.win = false;
        SceneManager.LoadScene("Game");

    }
    public void PressMenu()
    {
        GameManager.instance.time = 0f;
        GameManager.instance.win = false;
        SceneManager.LoadScene("Start");
    }
}
