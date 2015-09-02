using UnityEngine;
using System.Collections;

public class NukeLauncherController : MonoBehaviour {

	public NukeLauncherController otherLuancher;
	public GameObject dnaExplosionParticle;
	public void LaunchNuke(){
		GameObject []enemies = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i=0; i< enemies.Length; ++i ){
			Instantiate(dnaExplosionParticle,
			            enemies[i].transform.position,
			            enemies[i].transform.rotation);
			Destroy ( enemies[i] );
		}
	}
	void Update(){
		if(Input.GetKeyDown("q")){
			LaunchNuke();
		}
	}
}