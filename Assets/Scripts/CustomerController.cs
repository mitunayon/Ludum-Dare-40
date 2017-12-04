using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour {
    private bool isHungry = true;
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject target;
    private Renderer rend;
    private Collider coll;
    private bool isSeated = false;
    private Rigidbody rb;
    private GameObject door;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        agent.enabled = true;


        target = GameObject.FindWithTag("empty seat");
        agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
    }
	
	// Update is called once per frame
	void Update () {


        if (!isSeated)
        {
            target = GameObject.FindWithTag("empty seat");
            if (target == null)
            {
                target = GameObject.Find("Player");
            }
            agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
        }
       
        

        if (isHungry) {
            rend.material.color = Color.red;
            
        }
        else{
            rend.material.color = Color.green;
        }
    }

    void OnCollisionEnter(Collision collision){
        GameObject seatGo = collision.gameObject;
        if (seatGo == target && !isSeated && target != GameObject.Find("Player")) {
            //stop movement
            target.tag = "seat";
            isSeated = true;
            agent.isStopped = true;
            agent.enabled = false;
            coll.isTrigger = true;
            rb.isKinematic = true;
            //moves customer to seat
            transform.position = seatGo.transform.Find("Sitting Position").transform.position;
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "finished food" && isSeated) {
            //restarts movement
            Destroy(other.gameObject);
            target.tag = "empty seat";
            agent.enabled = true;
            agent.isStopped = false;
            coll.isTrigger = false;
            rb.isKinematic = false;
            isHungry = false;
            //customer leaves
            target = GameObject.Find("Customer Spawn");
            agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
            // drop an ingredient + money

        }
        
    }


}
