using UnityEngine;
using System.Collections;

public class BulletCollide : MonoBehaviour {


	public GameObject bombParticle;
	public AudioClip explosionSFX; 

	void OnTriggerEnter(Collider otherCollider){

		if( otherCollider.CompareTag("Enemy") ){
			Destroy( otherCollider.gameObject );

			Destroy(gameObject);
			Instantiate(bombParticle,
			            otherCollider.transform.position,
			            otherCollider.transform.rotation);
			if(explosionSFX != null ){
			AudioSource.PlayClipAtPoint(explosionSFX,
				                         otherCollider.transform.position);
			}
			GameScoreController.controller.AddScore(1);
		}



	}

}
