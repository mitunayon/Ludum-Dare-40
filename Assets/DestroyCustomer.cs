using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCustomer : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
