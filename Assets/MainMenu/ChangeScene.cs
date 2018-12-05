using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {


    private float timer = 1.2f;


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            MoveScene();
        }
    }

    private void MoveScene()
    {
        string fruit = this.name;
        switch (fruit)
        {
            case "StrawberrySlicedMain(Clone)":
                SceneManager.LoadScene("Credits");
                break;
            case "WatremelonSlicedMain(Clone)":
                SceneManager.LoadScene("ChooseMode");
                break;
            case "LemonSlicedMenu(Clone)":
                SceneManager.LoadScene("Rules");
                break;
            case "PepperSlicedMode(Clone)":
                Debug.Log("dasdas");
                SceneManager.LoadScene("Arcade");
                break;
            case "PomegranteSlicedMode(Clone)":
                SceneManager.LoadScene("Classic");
                break;
            case "SlicedForClassic(Clone)":
                SceneManager.LoadScene("Classic");
                break;
            case "SlicedForArcade(Clone)":
                SceneManager.LoadScene("Arcade");
                break;
            default:
                SceneManager.LoadScene("MenuScene");
                break;

        }
    }
}
