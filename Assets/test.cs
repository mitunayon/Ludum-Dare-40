using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    float speed = 10f; //how fast the object should rotate
                        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
    }
}
