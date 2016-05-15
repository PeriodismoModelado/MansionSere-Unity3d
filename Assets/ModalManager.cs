using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalManager : MonoBehaviour {

	public GameObject[] positions;
	public float[] durations;
	public float[] delays;

	public float fadeSpeed = 0.5f;
	public RawImage mFader;
	bool toClear = true;
	bool toBlack = false;
	GameObject previous;
	int Current = 0 ;
	private float startTime = 0;
	bool pleaseStop = false;
	bool moveNext = false;
	public bool EndApp = false;
	void Start(){
		toClear = true;
		startTime = Time.time;
		
	}
	void Update(){

	

		var currentPanel = positions [Current];

		var duration = durations[Current];
		var delayMore = delays[Current];
		if (Time.time < startTime + duration + delayMore && !pleaseStop && !moveNext ) {


			if (toBlack){
				FadeToBlack();
				Debug.Log ("black");
			}
			else if (toClear) {
				FadeToClear();
				if(previous){
					previous.gameObject.SetActive(false);
				}
				currentPanel.gameObject.SetActive(true);
				Debug.Log ("clear");
			}

		} else if(pleaseStop){
			Debug.Log ("pleaseStop");
			if (toBlack){
				FadeToBlack();
				Debug.Log ("black");
			}
			else if (EndApp){
				Application.Quit();
				Debug.Log ("Quit");
			}
			else{
				Application.LoadLevel("Sere3D");
				Debug.Log ("LoadLevel");
			}
		}else {
			if (moveNext){
				moveNext = false;
			}
			FadeToBlack();
			toBlack =true;

			Debug.Log ("black");
			if (Current + 1 < positions.Length) {
				startTime = Time.time;
				previous = currentPanel;
				Current++;
				Debug.Log ("Next:" + Current);

			} else {
				pleaseStop = true;
				toBlack = true;
				Debug.Log ("SetOnStop");
			}

		}
	}



	void FadeToClear()
	{
		
		// Lerp the colour of the texture between itself and black.
		mFader.color = Color.Lerp(mFader.color, Color.clear, fadeSpeed * Time.deltaTime);

		if(mFader.color.a <= 0.01f) {

			toClear = false;
			mFader.gameObject.SetActive(false);

		
		}

	}
	
	void FadeToBlack ()
	{
		mFader.gameObject.SetActive(true);
		// Lerp the colour of the texture between itself and black.
		mFader.color = Color.Lerp(mFader.color, Color.black, fadeSpeed * Time.deltaTime);
				if(mFader.color.a >= 0.99f) {
					toBlack = false;
					toClear = true;
					Debug.Log ("moving_- >clear");
				}
	}

	public void ForceNext(){
		moveNext = true;
	}

}
