using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {

	public GameObject character;

	public GameObject[] targets;
	public float[] durations;
	public float[] delays;
	public AudioSource[] sources;

	private Vector3 endPoint;
	public int Current = 0;

	private float freezedTime = 0;
	private float toWait =0;
	
	private Vector3 startPoint;
	private float startTime;

	private bool pleaseStop = false;
	
	void Start() {
		startPoint = character.transform.position;
		startTime = Time.time;
	}
	
	
	void Update(){

		var endPoint = targets[Current].transform.position;
		var duration = durations[Current];
		var delayMore = delays[Current];
		var audioNow = sources[Current];
		if (Time.time < startTime + duration + delayMore && !pleaseStop) {

			character.transform.position = 
				Vector3.Lerp (startPoint, endPoint, (Time.time - startTime) / duration);
			if (audioNow != null){
				if (!audioNow.isPlaying){
					audioNow.Play();
				}
			}
		} else {

			if (Current + 1 < targets.Length) {
				startTime = Time.time;
				startPoint = endPoint;
				Current++;
				Debug.Log(Current);
			} else {
				pleaseStop = true;
			}
		}


	}
}