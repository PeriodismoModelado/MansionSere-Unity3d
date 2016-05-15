using UnityEngine;
using System.Collections;

public class MainUISign : MonoBehaviour {


	public Texture backgroundTexture;
	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		float width = 600;
		float height = 600;
		GUI.DrawTexture(new Rect ((Screen.width / 2) - (width/2), 
		                           (Screen.height / 2) - (height/2), 
		                           width, height), backgroundTexture);
	}

}
