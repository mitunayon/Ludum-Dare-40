using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour {
	[SerializeField]
	private Slider chargeUI;
	private float startTime;
	private float durationTime;
	private RaycastHit hit;
	private GameObject pickedup_object;
	private Rigidbody pickedup_objectRb;
	[SerializeField]
	private float smooth;
	private bool pickedup;
	[SerializeField]
	private float throwStrength;
	private float chargeUpTime; 

	void Update(){
		if (pickedup_object != null) {
			if (pickedup) {
				shootItem (pickedup_objectRb);
			}
		}

	}
	// Update is called once per frame
	void FixedUpdate() {
		pickingUp ();
	}

	public void pickingUp(){
		if (Input.GetMouseButtonDown(0)){
			if (Physics.Raycast(transform.position, transform.forward,out hit, 3.5f)){
				pickedup_object = hit.collider.gameObject;
				pickedup_objectRb = hit.rigidbody;
				if(pickedup_object.tag == "pickup" || pickedup_object.tag == "key"){
					pickedup = !pickedup;
				}
			}
		}
		if (pickedup_object != null) {
			if (pickedup) {
				pickedup_objectRb.useGravity = false;
				pickedup_objectRb.angularDrag = 5f;
				pickedup_object.transform.position = Vector3.Lerp (pickedup_object.transform.position, transform.position + transform.forward * 2, Time.deltaTime * smooth);
				pickedup_object.transform.LookAt(transform);
			}
			if (pickedup == false && pickedup_objectRb != null) {
				pickedup_objectRb.useGravity = true;
				pickedup_objectRb.angularDrag = 0.05f;
			
			}
		}
	}
	void shootItem(Rigidbody pickupRb){
		if (Input.GetMouseButtonDown(1)) {
			startTime = Time.fixedTime;

		}
		if (Input.GetMouseButton(1)) {
			chargeUpTime = Mathf.Clamp(Time.fixedTime - startTime,0,1);
			chargeUI.value = chargeUpTime;
		}
		if(Input.GetMouseButtonUp(1)){
			Debug.Log("this occurs");
			durationTime = Mathf.Clamp(Time.fixedTime - startTime,0,1);
			pickedup = false;
			pickupRb.useGravity = true;
			pickupRb.AddForce(transform.forward * throwStrength * durationTime);
			chargeUpTime = 0;
			durationTime = 0;
			startTime = 0;
		}
	}
	void stopRotation(){
		if (Input.GetKeyDown(KeyCode.E)){
			pickedup_object.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
			pickedup_objectRb.freezeRotation = true;
		}
		if(Input.GetKeyUp(KeyCode.E)){
			pickedup_objectRb.freezeRotation = false;
		}
	}
}
