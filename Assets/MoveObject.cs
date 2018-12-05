using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    [SerializeField]
    private float minXSpeed, maxXSpeed, minYSpeed, maxYSpeed;

    [SerializeField]
    private float destroyTime;

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minXSpeed, maxXSpeed), Random.Range(minYSpeed, maxYSpeed));
        Destroy(this.gameObject, this.destroyTime);
    }
}