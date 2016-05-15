using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOutLevel : MonoBehaviour {

	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	
	public RawImage FadeCanvas;
	public RawImage PlayImage;
	public RawImage PauseImage;
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	public Canvas CurrentCanvas;
	public Text descripcionText;
	// Use this for initialization
	void Start () {

		FadeCanvas.uvRect = new Rect(0, 0, Screen.width, Screen.height);
		OnPause ();
	}
	
	// Update is called once per frame
	void Update () {
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
	}


	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		FadeCanvas.color = Color.Lerp(FadeCanvas.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		FadeCanvas.color = Color.Lerp(FadeCanvas.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(FadeCanvas.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			FadeCanvas.color = Color.clear;
			FadeCanvas.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene()
	{
		// Make sure the texture is enabled.
		FadeCanvas.enabled = true;
		fadeSpeed = 0.08f;
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if (FadeCanvas.color.a >= 0.95f) {
			// ... reload the level.
			Application.LoadLevel (2);
		}
	}

	public void OnPlaying(){
		PauseImage.gameObject.SetActive(false);
		PlayImage.gameObject.SetActive(true);
	}
	public void OnPause(){
		PauseImage.gameObject.SetActive(true);
		PlayImage.gameObject.SetActive(false);
	}

	public void ShowCopy(string text){
		descripcionText.text = text;

	}

}


