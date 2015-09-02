using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class example : MonoBehaviour {
	//Variables
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F; 
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public static int itemcount;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationX = 0F;
	float rotationY = 0F;
	string url_pickup = "http://192.168.100.26/game/pickitem";
	public GameObject doorgate;
	Quaternion originalRotation;


	void Update() {


		if (axes == RotationAxes.MouseXAndY)
		{
			// Read the mouse input axis
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
			
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}
		else if (axes == RotationAxes.MouseX)
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
		}


		CharacterController controller = GetComponent<CharacterController>();
		// is the controller on the ground?
		if (controller.isGrounded) {
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);
	}

	void Start ()
	{
		itemcount = 0;
		Debug.Log (itemcount+"Gate");

		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
		originalRotation = transform.localRotation;
	}

	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}


	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Key") {	
			itemcount++;
			if(itemcount==6)
			{
				doorgate.SetActive(true);
			}
			//Debug.Log(login_database.id_acc);
			Destroy(other.gameObject);
			Debug.Log("Key");

		}

		if (other.gameObject.tag == "door") {	
			{
				Debug.Log("Door");
				Destroy(other.gameObject);
				Application.LoadLevel("scene2");
				
				//Debug.Log(login_database.id_acc);
				
				
			}
			
		}







}






}