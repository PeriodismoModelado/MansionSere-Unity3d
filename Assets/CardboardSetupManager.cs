using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardboardSetupManager : MonoBehaviour {


	public GameObject YesButton;
	public GameObject NoButton;
	public Text QuestionText;
	public GameObject PanelManager;
	public string Confirmation;
	bool CardboardIsOn = false;
	float start = 0;
	public float waiting = 10f;
	bool  first = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CardboardIsOn) {
			if (!first){
				start = Time.time;
				first = true;
				Debug.Log("First");
			}
			else {
				Debug.Log("waiting");
				if (Time.time - start > waiting){
					Cardboard.SDK.VRModeEnabled = true;
					Debug.Log("moving");
					PanelManager.GetComponent<ModalManager>().ForceNext();
				}
			}


		}
	
	}
	public void EnableCardboard(){
		CardboardIsOn = true;
		QuestionText.text = Confirmation;
		PlayerPrefs.SetInt ("VrMode", 1);
		YesButton.gameObject.SetActive (false);
		NoButton.gameObject.SetActive (false);
	}
	public void DisableCardboard(){
		PlayerPrefs.SetInt ("VrMode", 0);
		YesButton.gameObject.SetActive(false);
		NoButton.gameObject.SetActive(false);
		Cardboard.SDK.VRModeEnabled = false;
		PanelManager.GetComponent<ModalManager>().ForceNext();

	}
}
