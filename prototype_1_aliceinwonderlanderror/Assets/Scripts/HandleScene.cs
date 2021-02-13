using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleScene : MonoBehaviour
{
    public static IEnumerator StartChangeScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        ChangeScene();
    }
    // Static method for ease
    public static void ChangeScene() {
        // There is a bug with unity's scenemanagement methods related to using build index (int)
        if (SceneManager.GetActiveScene().name == "Preface")
        {
            SceneManager.LoadScene("HorizontalWonderland");
        } else if(SceneManager.GetActiveScene().name == "HorizontalWonderland")
        {
            SceneManager.LoadScene("FreeFormWonderland");
        } else if(SceneManager.GetActiveScene().name == "FreeFormWonderland")
        {
            SceneManager.LoadScene("FreeFormWonderlandCollision");
        } else if (SceneManager.GetActiveScene().name == "FreeFormWonderlandCollision")
        {
            SceneManager.LoadScene("FreeFormWonderLandCollision2");
        } else if (SceneManager.GetActiveScene().name == "FreeFormWonderLandCollision2")
        {
            Debug.Log("Changing to second to final scene");
            SceneManager.LoadScene("FreeFormWonderlandRaycastBuildOnPoint");
        }
    }

}
