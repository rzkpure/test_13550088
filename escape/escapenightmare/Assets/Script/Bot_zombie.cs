using UnityEngine;
using System.Collections;

public class Bot_zombie : MonoBehaviour {

	public Transform target;
	public float moveSpeed = 4f;
	public int rotationSpeed;
	public float  duration = 1f;
	void Start() 

	{Animator ani = GetComponent<Animator>();
		ani.SetBool ("attack", false);

		target = GameObject.Find("Player").transform;

	}
	
	void Update() 
	{    

		if (target != null) 
		{
			Vector3 dir = target.position - transform.position;
			// Only needed if objects don't share 'z' value.
			transform.LookAt(target);

			dir.z = 0.0f;
			if (dir != Vector3.zero) 
				transform.rotation = Quaternion.Slerp ( transform.rotation, 
				                                       Quaternion.FromToRotation (Vector3.right, dir), 
				                                       rotationSpeed * Time.deltaTime);
			
			//Move Towards Target
			transform.position += (target.position - transform.position).normalized 
				* moveSpeed * Time.deltaTime;
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {	
			for(int i = 0 ; i<=10 ;i++) 
			{
				Animator ani = GetComponent<Animator> ();
				ani.SetBool ("attack", true);
				Debug.Log ("Hit");
			} 
			Destroy(gameObject);

		}
	}

}
