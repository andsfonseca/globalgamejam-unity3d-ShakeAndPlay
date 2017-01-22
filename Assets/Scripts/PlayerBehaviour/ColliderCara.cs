using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCara : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("box")) {
			Debug.Log ("bateu");
			GetComponentInParent<MovePlayer> ().bateu = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll){	
		if (coll.gameObject.CompareTag ("box")) {	
			GetComponentInParent<MovePlayer> ().bateu = false;
		}
	}

}
