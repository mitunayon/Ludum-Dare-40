using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEmitter : MonoBehaviour {
    public float cookRate = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "container")
        {
            print("Cooking Added");
            CookingContainer cookCtrl = collision.transform.GetComponent<CookingContainer>();
            
            cookCtrl.AddCookingProgress(cookRate);
        }
        
    }
}
