using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyController : MonoBehaviour {
    public bool pressed;
    public GameObject foodToSpawn;
    public float distanceFromButton;
    public GameController gameController;
    public int cost;
    // Use this for initialization
    void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        pressed = false;
    }

    // Update is called once per frame
    void Update() {
        if (pressed && gameController.money >= cost) {
            SpawnFood(foodToSpawn);
            pressed = false;
            gameController.money -= cost;
        }
    }
    void SpawnFood(GameObject foodToSpawn) {
        Instantiate(foodToSpawn, transform.position + transform.forward * distanceFromButton, Quaternion.identity);
    }
}
