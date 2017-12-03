using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour {
    private bool isHungry = true;
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject target;
    private Renderer renderer;
    private Collider collider;
    private bool isSeated = false;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (!isSeated) {
            target = GameObject.FindWithTag("empty seat");
            if (target == null) {
                target = GameObject.Find("Player");
            }
            agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
        }
        if (isHungry) {
            renderer.material.color = Color.red;
        }
    }

    void OnCollisionEnter(Collision collision){
        GameObject seatGo = collision.gameObject;
        if (seatGo == target && !isSeated && target != GameObject.Find("Player")) {
            target.tag = "seat";
            isSeated = true;
            agent.isStopped = true;
            agent.enabled = false;
            collider.isTrigger = true;
            rb.isKinematic = true;
            transform.position = seatGo.transform.Find("Sitting Position").transform.position;
        }
    }


}
