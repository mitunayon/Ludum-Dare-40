using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucepanOverheadBar : OverheadHealthbarController {
    CookingContainer objCtrl;
    // Use this for initialization
    void Start () {
        Initialise();
        objCtrl = GetComponentInParent<CookingContainer>();
    }
	
	// Update is called once per frame
	void Update () {
        ChangeSprite((float) objCtrl.progress, 100f);
	}
}
