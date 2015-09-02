using UnityEngine;
using System.Collections;

public class Enemymoon : MonoBehaviour {

	public GameObject dnaEnemyPrefab;
	
	public Transform []locator_moon;
	//Time Random
	private float timePos = 0f;
	private float duration = 1f;
	public void SpawnEnemy(){
		int randKey = Random.Range (0,locator_moon.Length);
		Transform spawnPoint = locator_moon[randKey];
		
		
		
		Instantiate(dnaEnemyPrefab,
		            spawnPoint.position,
		            spawnPoint.rotation);
		
		
		
	}
	
	
	
	void Update () {
		timePos += Time.deltaTime;
		if(timePos >= duration){
			timePos = 0f;
			duration = Random.Range(0.5f,2f);
			SpawnEnemy();  //1s hav SpawnEnemy 1 tao
		}
	}
}
