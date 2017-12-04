using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodController : MonoBehaviour
{
    public static string[] types = { "Meat", "Vegetable", "Water", "Bread", "Potatoes", "Dairy"};
    [SerializeField]
    private string type;

    //gets type
    public string getType() {
        return this.type;
    }

    private void Start()
    {
    }

}
