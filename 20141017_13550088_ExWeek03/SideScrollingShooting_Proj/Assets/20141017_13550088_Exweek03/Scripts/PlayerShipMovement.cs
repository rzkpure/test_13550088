using UnityEngine;
using System.Collections;

public class PlayerShipMovement : MonoBehaviour {

	public float moveSpeed = 1f;
	public Transform shipTran;

	void Start () {
	
	}

	void Update () {
		//Get Input from Keyboard
		float h = Input.GetAxis("Horizontal");

		Vector3 moveVector  = new Vector3(h*moveSpeed,0f,0f);
		shipTran.position += (moveVector*Time.deltaTime);
	}
}
