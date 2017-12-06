using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {
    public GameObject customer;
    private int spawned = 0;
    [SerializeField]
    private float difficultyScale = 1f;
    void Start() {
        //InvokeRepeating("spawn", 2f, 10f/difficultyScale);
    }
    public void spawn(int repeat) {
        for (int i = 0; i < repeat; i++) {
            Instantiate(customer, transform.position, Quaternion.identity);
            StartCoroutine("Timer");
            spawned++;
        }

    }
    void Update() {

    }

    public IEnumerator Timer() {
        yield return new WaitForSeconds(2);
    }
}
