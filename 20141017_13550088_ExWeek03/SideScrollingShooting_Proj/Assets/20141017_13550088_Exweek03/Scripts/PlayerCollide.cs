using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {
	public GameObject playerShip;
	public GameObject dnaExplosionParticle;
	public GameStateController gameState;

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Enemy")){


			//Create explosion particle
			Instantiate(dnaExplosionParticle,
			            playerShip.transform.position,
			            playerShip.transform.rotation);

			//Destroy player's Ship
			    //Destroy(playerShip);


			playerShip.SetActive(false);

			//Destroy Enemy
			Destroy(other.gameObject);		
			gameState.ChangeStateToEndGame();
			}

	}
}
