using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            HandleScene.StartChangeScene(5.0f);
            SceneManager.LoadScene("FreeFormWonderlandRaycastBuildOnPoint");
        }
    }
}
