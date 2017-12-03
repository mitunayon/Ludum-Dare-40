using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingContainer : MonoBehaviour {

    public float progress = 0f;

    public List<string> ingredients = new List<string>();
    private PickupController pickupCtrl;
    GameController gameCtrl;
    
    public bool isCooked = false;

    public float cookRate = 0.5f;

    // Use this for initialization
    void Start () {
        pickupCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PickupController>();
        gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        

        switch (collision.transform.tag)
        {
            case "ingredient":
                print("Added " + collision.collider.name.ToString());
                FoodController foodCtrl = collision.collider.GetComponent<FoodController>();

                ingredients.Add(collision.collider.name.ToString());

                if (pickupCtrl.pickedup_object.tag == "ingredient")
                {
                    pickupCtrl.pickedup_object = null;
                    pickupCtrl.pickedup_objectRb = null;
                    pickupCtrl.pickedup = false;
                    /*
                    // set parent
                    foodCtrl.transform.SetParent(gameObject.transform);
                    collision
                    */
                }
                Destroy(collision.transform.gameObject);
                break;

            case "serving plate":
                print("served");
                if (isCooked && ingredients.Count > 0)
                {

                    Instantiate(gameCtrl.soupObj, transform.position, transform.rotation);
                    ClearIngredients();
                }
                break;
            
        }

    }
    void ClearIngredients()
    {
        ingredients.Clear();
        progress = 0f;
        isCooked = false;

    }
    public void AddCookingProgress(float cookRate)
    {
        if (ingredients.Count > 0)
        {
            if (isCooked == false)
            {
                progress += cookRate;
            }

            if (progress >= 100f)
            {
                isCooked = true;

            }
        }
        
    }
}
