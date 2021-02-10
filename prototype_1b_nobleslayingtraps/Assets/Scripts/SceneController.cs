using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    public float timer = 0.0f;
    public int seconds;
    public GameObject clockTimerUI;
    private TextMeshProUGUI clockTimerUIText;

    private void Start()
    {
        clockTimerUI = GameObject.FindWithTag("ClockTimer");
        clockTimerUIText = clockTimerUI.GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        // seconds in float
        timer += Time.deltaTime;
        // turn seconds in float to int
        seconds = (int)(timer % 10);
        //print(seconds);
        clockTimerUIText.SetText(10 - seconds + " seconds.");
        if (10 - seconds <= 0)
        {
            SceneManager.LoadScene("Arena");
        }
    }

    public static IEnumerator StartChangeScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        ChangeScene();
    }
    // Static method for ease
    public static void ChangeScene()
    {
        // There is a bug with unity's scenemanagement methods related to using build index (int)
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            SceneManager.LoadScene("Template");
        }
        else if (SceneManager.GetActiveScene().name == "Template")
        {
            SceneManager.LoadScene("Arena");
        }
        else if( SceneManager.GetActiveScene().name == "Arena")
        {
            SceneManager.LoadScene("Template");
        }
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
