using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {
	public Transform playerTransform;
	public GameObject sandPrefab;
	private int indexGround;
	// Use this for initialization
	void Start () {
		indexGround = 0;
		//playerTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.x > 2 + indexGround * 20) {
			sandPrefab.Spawn (new Vector3(12+indexGround*20,-4, 0));
			indexGround++;
		}
		foreach (GameObject sand in GameObject.FindGameObjectsWithTag("ground")) {
			if ((playerTransform.position - sand.transform.position).x > 40) {
				sand.Recycle ();
			}
		}
	}
}
