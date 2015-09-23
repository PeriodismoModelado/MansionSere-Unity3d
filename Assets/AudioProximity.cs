using UnityEngine;
using System.Collections;

public class AudioProximity : MonoBehaviour {


	public GameObject player;
	public float playerDistance;
	public GameObject target;
	public AudioSource gameAudio;
	public bool canPlayAudio = true;
	
	void Update() {
		
		playerDistance = Vector3.Distance(player.transform.position, 
		                 new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
		if (playerDistance < 4) {
			if (canPlayAudio) {
//				gameAudio.clip = gameAudio;
				gameAudio.volume = 0.5f; // adjust the volume to whatever you want
				gameAudio.Play();
				canPlayAudio = false;  // you can reset this in your code elsewhere... I did this just to make sure the audio only plays once.
			}
		}
	}
//	
//	IEnumerator AdjustVolume () {
//		
//		while(true) {
//			
//			if(audio.isPlaying) { // do this only if some audio is being played in this gameObject's AudioSource
//				
//				float distanceToTarget = Vector3.Distance(transform.position, target.position); // Assuming that the target is the player or the audio listener
//				
//				if(distanceToTarget < 1) { distanceToTarget = 1; }
//				
//				audio.volume = 1/distanceToTarget; // this works as a linear function, while the 3D sound works like a logarithmic function, so the effect will be a little different (correct me if I'm wrong)
//				
//				yield return new WaitForSeconds(1); // this will adjust the volume based on distance every 1 second (Obviously, You can reduce this to a lower value if you want more updates per second)
//				
//			}
//		}
//		
//	}

}

