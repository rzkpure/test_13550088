using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float moveSpeed = 30f;
	public Transform bulletTran;
	void Start () {
	
	}

	void Update () {
		Vector3 moveVector = new Vector3(0f,0f,moveSpeed);
		bulletTran.position += (moveVector*Time.deltaTime);
	}
}
