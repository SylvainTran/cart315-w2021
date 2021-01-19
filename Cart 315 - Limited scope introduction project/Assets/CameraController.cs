using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class CameraController : MonoBehaviour
{
    public GameObject BartenderIntroCam;
    public GameObject BarSceneOverviewCam;
    public GameObject player;
    public GameObject introScreen;

    public void Start() {
        Invoke("CloseIntroScreen", 7.0f);
    }

    public void StartGameplay() {
        BartenderIntroCam.GetComponent<CinemachineVirtualCamera>().Priority = 0;
        BarSceneOverviewCam.GetComponent<CinemachineVirtualCamera>().Priority = 100;
    }

    public void EnablePlayerController() {
        player.GetComponent<PlayerController>().enabled = true;
    }

    void CloseIntroScreen() {
        InvokeRepeating("FadeScreen", 0.0f, 10.0f);
        Invoke("TerminateFadeScreen", 15.0f);
    }

    void FadeScreen() {
        introScreen.GetComponentInChildren<Image>().CrossFadeAlpha(0, 18.0f, false);
    }

    void TerminateFadeScreen() {
        introScreen.SetActive(false);
        CancelInvoke();
    }
}
