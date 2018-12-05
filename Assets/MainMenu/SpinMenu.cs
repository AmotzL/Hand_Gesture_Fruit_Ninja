using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinMenu : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public GameObject particlesPrefab;
    public GameObject splashPrefab;
    public float speed = 10f;

	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            GameObject particles = Instantiate(particlesPrefab, transform.position, transform.rotation);
            GameObject splash = Instantiate(splashPrefab, transform.position, transform.rotation);
            splash.transform.Translate(0, 0, 60);
            Destroy(particles, 1f);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }

    }
}
