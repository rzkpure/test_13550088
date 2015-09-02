using UnityEngine;
using System.Collections;

public class spawnkey : MonoBehaviour {
	
	public GameObject dnaenemyprefab;
	public Transform[]locator;
	public float timePos = 0f;
	public float  duration = 1f;
	// Use this for initialization
	public void spwanen()
	{
		int randkey = Random.Range (0, locator.Length);
		Transform spwan = locator [randkey];
		Instantiate (dnaenemyprefab, spwan.position, spwan.rotation);
		
		
		
	}
	
	void Start () {
		spwanen ();
	}
	
	// Update is called once per frame
	void Update () {
		timePos += Time.deltaTime;
		if (timePos >= duration) {
			timePos = 1f;
			duration = Random.Range(10f,20f);
			spwanen();

		}
		
	}
}
