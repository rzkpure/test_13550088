using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public static int sceneNumber = 0;
	void Start () {
		Debug.Log (sceneNumber);
		sceneNumber++;
		StartCoroutine (NextScene());
	}
	public float time =60;
	public int timeR;
	void Update(){
		time -= Time.deltaTime;
		timeR = (int)time;
	}
	IEnumerator NextScene(){
		yield return new WaitForSeconds (3);
		Application.LoadLevel (sceneNumber);
	}

}
