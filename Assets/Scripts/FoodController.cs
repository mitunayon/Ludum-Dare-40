using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FoodController : MonoBehaviour {
    private static string[] types = { "Meat", "Vegetable", "Water", "Bread", "Potatoes", "Dairy" };
    [SerializeField]
    private string type;

    //gets type
    public string getType() {
        return this.type;
    }

    private void Start() {
        if (!types.Contains(type)) {
            Debug.Log("Error: Invalid weapon type");
        }
    }

}
