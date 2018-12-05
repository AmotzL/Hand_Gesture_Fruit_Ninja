using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spin : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public float speed = 10f;


    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 direction = (col.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
        Destroy(slicedFruit, 3f);
        Destroy(gameObject);
        
    }

    private void ChangeScene()
    {
        string fruit = this.name;
        switch (fruit)
        {
            case "Strawberry":
                SceneManager.LoadScene("Credits");
                break;
            case "Watermelon":
                SceneManager.LoadScene("Game");
                break;
            case "Banana":
                SceneManager.LoadScene("HighScore");
                break;
            case "Bomb":
                Application.Quit();
                break;
            default:
                SceneManager.LoadScene("MenuScene");
                break;

        }
    }
}
