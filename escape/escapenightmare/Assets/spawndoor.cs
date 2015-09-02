using UnityEngine;
using System.Collections;

public class spawndoor : MonoBehaviour {
	
	public GameObject dnaenemyprefab;
	public Transform locator;
	// Use this for initialization

	
	void Start () {

		for (int i = 0; i<1; i++) {
			Instantiate (dnaenemyprefab, locator.position, locator.rotation);
		}
	
	}
	
	// Update is called once per frame
	void Update () 
		{

	}
}
	

