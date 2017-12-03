using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingContainer : MonoBehaviour {

    public float progress = 0f;

    public List<string> ingredients = new List<string>();
    private PickupController pickupCtrl;

	// Use this for initialization
	void Start () {
        pickupCtrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PickupController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ingredient")
        {
            print("Added " + collision.collider.name.ToString());
            FoodController foodCtrl = collision.collider.GetComponent<FoodController>();

            ingredients.Add(collision.collider.name.ToString());

            if (pickupCtrl.pickedup_object.tag == "ingredient")
            {
                pickupCtrl.pickedup_object = null;
                pickupCtrl.pickedup_objectRb = null;
                pickupCtrl.pickedup = false;
                // set parent
                foodCtrl.transform.SetParent(gameObject.transform);
                collision.rigidbody.isKinematic = false;
            }

            //Destroy(collision.transform.gameObject);
            
        }
        
    }
    
}
