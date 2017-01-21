using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	public float speed;
	public float jumpForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speed*Time.deltaTime, 0, 0);
		if(Input.GetKeyDown("space")){
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce*Time.deltaTime));
		}
	}
}
