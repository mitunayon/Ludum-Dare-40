using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOverheadBar : OverheadHealthbarController {
    CustomerController objCtrl;
    // Use this for initialization
    void Start() {
        Initialise();
        objCtrl = GetComponentInParent<CustomerController>();
    }

    // Update is called once per frame
    void Update() {
        ChangeSprite((float)objCtrl.countdown, (float)objCtrl.leaveTimer);
    }
}
