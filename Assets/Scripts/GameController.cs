using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public string gameState = "live";
    public GameObject soupObj;
    public GameObject sandwichObj;
    public GameObject meatChunksObj;
    public GameObject grilledMeatObj;
    public GameObject yuckObj;
    public GameObject toastObj;
    public GameObject[] ingredientReward;
    public GameObject player;
    SpawnControl custSpawner;
    public int angryCustomers = 0;
    public int money = 20;
    public int wave = 0;
    float time = 0f;
    public int customersToFeed = 0;
    public int customersFed = 0;

    // Use this for initialization
    void Start() {
        gameState = "waiting";
        custSpawner = GameObject.Find("Customer Spawn").GetComponent<SpawnControl>();
    }

    // Update is called once per frame
    void Update() {
        switch (gameState) {
            case "waiting":
                if (Input.GetKeyDown(KeyCode.Return)) gameState = "start";
                break;
            case "start":
                customersFed = 0;
                wave++;
                customersToFeed += 3;
                custSpawner.spawn(customersToFeed);
                gameState = "live";
                break;
            case "live":
                if (customersFed >= customersToFeed) {
                    gameState = "start";
                }
                break;
        }
    }
}
