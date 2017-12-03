using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour {
    private bool isHungry = true;
    private NavMeshAgent agent;
    [SerializeField]
    private Transform target;
    private Renderer renderer;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        

    }
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindWithTag("seat").transform;
        agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));

        if (isHungry) {
            renderer.material.color = Color.red;
        }
    }
}
