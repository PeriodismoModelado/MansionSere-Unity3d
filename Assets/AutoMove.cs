using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {

	public GameObject character;
	AudioSource activeAudio;
	public GameObject[] targets;
	public float[] durations;
	public float[] delays;
	public bool[] playing;
	public AudioSource[] sources;
	public string[] AudioDescription;
	public GameObject faderInOut ;
	private Vector3 endPoint;
	public int Current = 0;

	private float freezedTime = 0;
	private float toWait =0;
	
	private Vector3 startPoint;
	private float startTime;

	private bool pleaseStop = false;

	void Start() {
		playing = new bool[durations.Length];
		startPoint = character.transform.position;
		startTime = Time.time;
		for (int i = 0; i < durations.Length; i++) {
			playing[i] = false;
		}
	}
	
	
	void Update(){

		var endPoint = targets[Current].transform.position;
		var duration = durations[Current];
		var delayMore = delays[Current];
		var audioNow = sources[Current];

		var descripcion = AudioDescription[Current];
		if (Time.time < startTime + duration + delayMore && !pleaseStop) {

			character.transform.position = 
				Vector3.Lerp (startPoint, endPoint, (Time.time - startTime) / duration);
			if (audioNow != null) {
				if (!audioNow.isPlaying && !playing[Current] ) {
					audioNow.Play();
					playing[Current]= true;
					activeAudio = audioNow;
					faderInOut.GetComponent<FadeOutLevel>().OnPlaying();
					faderInOut.GetComponent<FadeOutLevel>().ShowCopy(descripcion);
					activeAudio.loop = false;
				}else {

					Debug.Log(activeAudio.isPlaying);
					Debug.Log(activeAudio.name);
					activeAudio.loop = false;
				}

			}
			if (activeAudio != null){
				if (!activeAudio.isPlaying) {
					activeAudio.loop = false;
					faderInOut.GetComponent<FadeOutLevel>().OnPause();
					faderInOut.GetComponent<FadeOutLevel>().ShowCopy("");
				}else {
					activeAudio.loop = false;

					Debug.Log(activeAudio.isPlaying);
					Debug.Log(activeAudio.name);
				}


			}
		} else if (pleaseStop) {

			faderInOut.GetComponent<FadeOutLevel>().EndScene();
		}

		else {

			if (Current + 1 < targets.Length) {
				startTime = Time.time;
				startPoint = endPoint;
				Current++;

			} else {
				pleaseStop = true;
			}
		}


	}
}