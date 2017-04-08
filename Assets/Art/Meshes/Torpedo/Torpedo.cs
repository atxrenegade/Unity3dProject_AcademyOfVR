using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour {
    public float speed;
    public Transform explosionPrefab;
	// Use this for initialization
	void Start () {

        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
		
	}
    // When something enters out trigger
    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        // Check tag of the thing we collided with and see if it's called Destroy
        if(other.CompareTag("Destroy"))
        {
            // Destroy thing we collided with
            Destroy(other.gameObject);
        }
        // Destroy my own game object (the torpedo)
        Destroy(gameObject);
        submarine_controller.instance.MineDestroyed();
    }
}
