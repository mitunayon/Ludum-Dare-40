using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    GameController gameCtrl;
    CharacterController charCtrl;
    GameObject cam;
    Vector3 moveDirection = Vector3.zero;
    Vector3 camOffset = Vector3.zero;

    public float jumpSpd = 0f;
    public float moveSpd = 8f;
    public float gravity = 20f;

    float h, v;
	// Use this for initialization
	void Start () {
        gameCtrl = GameObject.Find("GameController").GetComponent<GameController>();
        charCtrl = GetComponent<CharacterController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        camOffset = cam.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        switch (gameCtrl.gameState)
        {
            case "live":

                h = Input.GetAxis("Horizontal");
                v = Input.GetAxis("Vertical");

                // Check Gravity
                if (charCtrl.isGrounded == true)
                {
                    moveDirection = new Vector3(h, 0, v);
                    if (Input.GetButton("Jump"))
                    {
                        moveDirection.y = jumpSpd;
                    }
                }
                else
                {
                    moveDirection.x = h;
                    moveDirection.z = v;
                    moveDirection.y -= gravity * Time.deltaTime;
                }

                //  Apply movement
                moveDirection.x *= moveSpd;
                moveDirection.z *= moveSpd;
                moveDirection = transform.TransformDirection(moveDirection);
                charCtrl.Move(moveDirection * Time.deltaTime);

                //check for fire button
                if (Input.GetButton("Fire1"))
                {
                }
                else
                {
                }
                break;
            default:
                break;
        }
    }
    void SetCameraOffset()
    {
        cam.transform.position = transform.position + camOffset;
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "money":
                gameCtrl.money += Random.Range(1, 10);
                Destroy(other.gameObject);
                break;
        }
    }
}
