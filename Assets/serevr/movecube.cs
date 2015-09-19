using UnityEngine;
using System.Collections;

public class movecube : MonoBehaviour {

	public GameObject charaacter;

	public float speed = 1.5f;
	public float spacing = 1.0f;
	private Vector3 pos  ;
	
	void Start(){
		pos = transform.position;
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.W))
			pos.y += spacing;
		if (Input.GetKeyDown(KeyCode.S))
			pos.y -= spacing;
		if (Input.GetKeyDown(KeyCode.A))
			pos.x -= spacing;
		if (Input.GetKeyDown(KeyCode.D))
			pos.x += spacing;
		if (Input.GetKeyDown(KeyCode.Q))
			pos.z += spacing;
		if (Input.GetKeyDown(KeyCode.E))
			pos.z += spacing;
//		
		charaacter.transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
//		charaacter.transform.transform.Translate(Vector3.forward * Time.deltaTime*100);
	}
}
