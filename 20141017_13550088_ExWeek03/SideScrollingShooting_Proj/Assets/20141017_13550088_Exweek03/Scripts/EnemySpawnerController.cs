using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour {
	public GameObject dnaEnemyPrefab;

	public Transform []locators;
	//Time Random
	private float timePos = 0f;
	private float duration = 1f;
	public void SpawnEnemy(){
		int randKey = Random.Range (0,locators.Length);
		Transform spawnPoint = locators[randKey];



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
