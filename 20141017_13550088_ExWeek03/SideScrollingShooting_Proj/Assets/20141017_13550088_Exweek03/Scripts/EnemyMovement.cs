using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


	public float moveSpeed = 5f;
	public Transform enemyTran;

	void Start () {
		moveSpeed = Random.Range(1f,10f);
	}
	

	void Update () {
		Vector3 moveVecter = new Vector3(0f,0f,-moveSpeed);
		enemyTran.position += (moveVecter*Time.deltaTime);
	}
}
