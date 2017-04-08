using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    public Vector3 rotateDirection;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public void DoRotate () {
            transform.Rotate(rotateDirection);
        }
}



