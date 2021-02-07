using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Temporary fix, due to some issue with the static call to HandleScene's StartChangeScene

public class PickUp : MonoBehaviour
{
    public string pickUpTag = "PickUpItem";
    public string forceTag = "Force";
    private int counterToChangeScene = 0;
    private int MIN_TO_CHANGE_SCENE = 8;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(pickUpTag))
        {
            Destroy(collision.gameObject);
            Debug.Log(counterToChangeScene);
            ++counterToChangeScene;
        }
    }

    private void Update()
    {
        if(counterToChangeScene >= MIN_TO_CHANGE_SCENE)
        {
            SceneController.StartChangeScene(5.0f);
            SceneManager.LoadScene("FreeFormWonderlandRaycastBuildOnPoint");
        }
    }
}
