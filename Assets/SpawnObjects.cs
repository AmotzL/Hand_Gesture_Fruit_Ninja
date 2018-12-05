using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    [SerializeField]
    private GameObject prefabToSpawn;

    [SerializeField]
    private float spawnInterval, objectMinX, objectMaxX, objectY;

    [SerializeField]
    private Sprite[] objectSprites;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("spawnObject", this.spawnInterval, this.spawnInterval);
    }

    private void spawnObject()
    {
        GameObject newObject = Instantiate(this.prefabToSpawn);
        newObject.transform.position = new Vector2(Random.Range(this.objectMinX, this.objectMaxX), this.objectY);

        Sprite objectSprite = objectSprites[Random.Range(0, this.objectSprites.Length)];
        newObject.GetComponent<SpriteRenderer>().sprite = objectSprite;

    }
}
