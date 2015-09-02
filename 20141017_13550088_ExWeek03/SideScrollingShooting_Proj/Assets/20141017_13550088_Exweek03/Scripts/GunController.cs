using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public GameObject dnaBulletPrefab;
	public Transform gunTran;

	public void Fire(){
		Vector3 spawnPosition = gunTran.position;
		Instantiate(dnaBulletPrefab,
		            spawnPosition,
		            gunTran.rotation);
	}

	void Update () {
		if(Input.GetKeyDown("space")){
			Fire();
		}
	}
}
