using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {
    public GameObject customer;
    private int spawned = 0;
    [SerializeField]
    private float difficultyScale = 1f;
    void Start()
    {
        InvokeRepeating("spawn", 2f, 10f/difficultyScale);
    }
    public void spawn()
    {
        Instantiate(customer, transform.position, Quaternion.identity);
        spawned++;
    }
    void Update()
    {

    }
}
