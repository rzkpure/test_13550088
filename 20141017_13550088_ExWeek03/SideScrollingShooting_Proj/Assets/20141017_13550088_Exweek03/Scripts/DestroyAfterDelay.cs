using UnityEngine;
using System.Collections;

public class DestroyAfterDelay : MonoBehaviour {

	public GameObject target;
	// Use this for initialization
	void Start () {
		Destroy(target,2f); //Destroy Bullet(target) 2vinatee
	}

}
