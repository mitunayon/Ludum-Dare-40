using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEmitter : MonoBehaviour {
    public float cookRate = 1f;
    public GameObject smokePfx;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "container")
        {
            
            CookingContainer cookCtrl = other.transform.GetComponent<CookingContainer>();
            
            cookCtrl.AddCookingProgress(cookRate);
            GameObject inst = Instantiate(smokePfx, other.transform.position,other.transform.rotation);
            Destroy(inst, 3f);
        }
        
    }
    
}
