using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecailFruitArcade : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public GameObject particlesPrefab;
    public GameObject splashPrefab;
    public float speed = 10f;
    private bool isCut = false;

    void Update()
    {
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {

            Destroy(gameObject);
            GameObject scoreText = GameObject.Find("ScoreText");
            scoreText.GetComponent<ShowScore>().incrementScore(1);
        }
    }

    public bool getIsCut()
    {
        return isCut;
    }
}
