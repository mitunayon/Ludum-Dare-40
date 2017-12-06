using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour {
    private GameObject player;
    private Transform cam;
    [SerializeField]
    private Slider chargeUI;
    private float startTime;
    private float durationTime;
    private RaycastHit hit;
    public GameObject pickedup_object;
    public Rigidbody pickedup_objectRb;
    [SerializeField]
    private float pickupDistance = 4f;
    [SerializeField]
    private float distanceFromFace = 2f;
    [SerializeField]
    private float smooth;
    public bool pickedup;
    [SerializeField]
    private float throwStrength;
    private float chargeUpTime;
    [SerializeField]
    private float rotationSpeed = 50f; //how fast the object should rotate


    private void Start() {
        cam = Camera.main.transform;
    }

    void Update() {
        ButtonPress();

        if (pickedup_object != null) {
            if (pickedup) {
                ShootItem(pickedup_objectRb);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate() {
        pickingUp();

    }


    private void pickingUp() {
        //if left click with out holding anything
        if (Input.GetMouseButtonDown(0) && !pickedup) {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(new Ray(transform.position, transform.forward), pickupDistance);

            for (int i = 0; i < hits.Length; i++) {
                RaycastHit hit = hits[i];
                Renderer rend = hit.transform.GetComponent<Renderer>();
                pickedup_object = hit.collider.gameObject;
                pickedup_objectRb = hit.rigidbody;
                if (pickedup_object.tag == "pickup" || pickedup_object.tag == "ingredient" || pickedup_object.tag == "container" || pickedup_object.tag == "finished food") {
                    pickedup = !pickedup;
                    break;
                }

            }

        }


        //the raycast detects an actual object
        if (pickedup_object != null) {
            if (pickedup) {
                pickedup_objectRb.useGravity = false;
                pickedup_objectRb.angularDrag = 5f;
                pickedup_object.transform.position = Vector3.Lerp(pickedup_object.transform.position, transform.position + transform.forward * distanceFromFace, Time.deltaTime * smooth);
                //pickedup_object.transform.LookAt(transform);
                RotateObject(pickedup_object);
            }

            if (pickedup == false && pickedup_objectRb != null) {
                pickedup_objectRb.useGravity = true;
                pickedup_objectRb.angularDrag = 0.05f;

            }
        }
    }

    private void ShootItem(Rigidbody pickupRb) {
        if (Input.GetMouseButtonDown(1)) {
            startTime = Time.fixedTime;
        }

        if (Input.GetMouseButton(1)) {
            chargeUpTime = Mathf.Clamp(Time.fixedTime - startTime, 0, 1);
            //chargeUI.value = chargeUpTime;
        }
        if (Input.GetMouseButtonUp(1)) {
            durationTime = Mathf.Clamp(Time.fixedTime - startTime, 0, 1);
            pickedup = false;
            pickupRb.useGravity = true;
            pickupRb.AddForce(transform.forward * throwStrength * durationTime);
            chargeUpTime = 0;
            durationTime = 0;
            startTime = 0;
        }
    }

    private void RotateObject(GameObject pickup) {
        //enable rotation of the object
        if (Input.GetMouseButton(2)) {
            pickup.transform.Rotate(cam.up, -Mathf.Deg2Rad * Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, Space.World);
            pickup.transform.Rotate(cam.right, Mathf.Deg2Rad * Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.Q)) {
            pickup.transform.Rotate(cam.forward, -Mathf.Deg2Rad * Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, Space.World);
        }
    }

    private void ButtonPress() {
        //press e to buy food
        if (Input.GetKeyDown(KeyCode.E)) {
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance)) {
                GameObject hitInfo = hit.collider.gameObject;
                if (hitInfo.tag == "buy button") {
                    BuyController bController = hitInfo.GetComponent<BuyController>();
                    bController.pressed = true;
                }
            }
        }

    }

}
