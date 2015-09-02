using UnityEngine;
using System.Collections;

public class Connector :MonoBehaviour{

	public float progress;

	public delegate void CallbackEventHandler (WWW www);
	public static event CallbackEventHandler Callback;

	static Connector instance;

	static void  CreateInstance(){

		if (instance == null) {
			GameObject g = new GameObject ("Connector");

			instance = g.AddComponent<Connector>();

		}
	
	}



	public static void GET(string url,CallbackEventHandler callback){

		CreateInstance ();

		instance.StartCoroutine (StartSend (url));

		if(Callback == null)
		Callback += callback;
		
	}

	public static void POST(string url,WWWForm form,CallbackEventHandler callback){
		
		CreateInstance ();
		
		instance.StartCoroutine (StartSend (url,form));

		if(Callback == null)
		Callback += callback;
		
	}
	static IEnumerator StartSend(string url,WWWForm form = null){
		WWW www;

		if(form!= null)
		www = new WWW (url,form);
		else
		www = new WWW (url);


		while(!www.isDone){
			instance.progress = Mathf.Round(www.progress*100);
			
			yield return null;
		}
		instance.progress = 100;
		
		if (string.IsNullOrEmpty (www.error)) {

			if(Callback != null){
				
				Callback(www);
			}
			www.Dispose();
			
		} else {
			Debug.Log(www.error);
			
			
		}
		
		
		DestroyObject (instance.gameObject);
	}



//	public class Result{
//
//		string text;
//		string error;
//		Texture2D texture;
//
//
//	}

}
