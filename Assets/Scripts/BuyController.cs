using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyController : MonoBehaviour {
    public bool pressed;
    public GameObject foodToSpawn;
    public float distanceFromButton;
	// Use this for initialization
	void Start () {
        pressed = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (pressed) {
            Debug.Log("Works?");
            SpawnFood(foodToSpawn);
            pressed = false;
        }
	}
    void SpawnFood(GameObject foodToSpawn) {
        Instantiate(foodToSpawn, transform.position+transform.forward * distanceFromButton, Quaternion.identity);  
    }
}
