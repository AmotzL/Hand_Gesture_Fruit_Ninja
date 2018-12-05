using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeLoading : MonoBehaviour {

    public GameObject bladeTrailPrefab;
    private GameObject curentBladeTrail;
    private float minCuttingVelocity = 0.0025f;
    public handtracking hand;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    Vector2 previousPosition;

    bool isCutting = true;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        hand = GetComponent<handtracking>();
    }

    // Update is called once per frame
    void Update()
    {
        //update the position of the blade
        //Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newPosition = hand.vector;
        rb.position = newPosition;


        // calculate the speed pf the blade between two frames
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        //Debug.Log(velocity);
        if (velocity > minCuttingVelocity)
        {
            StartCutting();
        }
        else
        {
            StopCutting();
        }
        previousPosition = newPosition;


    }

    void StartCutting()
    {
        isCutting = true;
        //create the trail
        curentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        //update the previous position (allowing to colider to move to different position when statring new cut)
        previousPosition = cam.ScreenToWorldPoint(hand.vector);
        //enable the cutting only when we click
        circleCollider.enabled = true;
        LoadingGame test =  GetComponent<LoadingGame>();
        test.SetIsMove(true);
    }

    void StopCutting()
    {
        isCutting = false;
        //destroy the blade
        curentBladeTrail.transform.SetParent(null);
        Destroy(curentBladeTrail, 2f);
        //stop the cutting when finger is up
        circleCollider.enabled = false;
    }
}
