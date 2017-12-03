using UnityEngine;
using System.Collections;

public class PuttingDown : MonoBehaviour {
	[SerializeField]
	private GameObject ghostCube;
	[SerializeField]
	private bool isInside;
	private GameObject cube;
	private Renderer rendGhostCube;
	public bool activated;
	[SerializeField]
	private Transform target;
	private float originalDistance;
	private float difference;
	private float frac;

	void Start(){
		originalDistance = target.position.sqrMagnitude - ghostCube.transform.position.sqrMagnitude;
		cube = null;
		isInside = false;
		rendGhostCube = ghostCube.GetComponent<Renderer> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "pickup") {
			isInside = true;
			cube = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "pickup") {
			isInside = false;
		}
	}

	void Update(){
		difference += target.position.sqrMagnitude - ghostCube.transform.position.sqrMagnitude;
		frac = difference / originalDistance;

		Activation ();

		if (isInside == true) {
			ghostCube.SetActive (true);
			if (Input.GetMouseButtonDown(0)){
				activated = true;
				Color color = rendGhostCube.material.color;
				color.a = 200;
			    rendGhostCube.material.color = color;
			}

		} else {
			ghostCube.SetActive(false);
		}
	}

	void Activation(){
		if (activated) {
			Destroy(cube);
			//cube = null;
			//rendGhostCube.material.shader =  Shader.Find("Diffuse");
			//Animation();
		}
	}

	void Animation(){
		ghostCube.transform.position = Vector3.Lerp (ghostCube.transform.position, target.position, frac* 0.0001f);
	}

}
