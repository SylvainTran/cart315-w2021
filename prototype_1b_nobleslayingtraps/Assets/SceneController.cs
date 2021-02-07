using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
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
            SceneManager.LoadScene("Arena");
        }
        else if (SceneManager.GetActiveScene().name == "Arena")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
