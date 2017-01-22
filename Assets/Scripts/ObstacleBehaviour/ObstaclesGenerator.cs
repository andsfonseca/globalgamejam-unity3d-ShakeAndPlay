using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour {
	
	public GameObject boxPrefab;
	public float timeRate;
	private float lastSpawn;
	//private Vector3 offset;
	public Transform playerTransform;
    private float speed;
    // Use this for initialization
    void Start () {
		//offset = transform.position - playerTransform.position;
		lastSpawn = 0;
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>().speed;
    }

	// Update is called once per frame
	void Update () {
        if (GameLogic.Instance.gameStateManager.current.Equals(EGameState.GAME)) {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (Time.time - lastSpawn > timeRate) {
                boxPrefab.Spawn(transform.position);
                lastSpawn = Time.time;
            }
            foreach (GameObject box in GameObject.FindGameObjectsWithTag("box")) {
                if ((playerTransform.position - box.transform.position).x > 40) {
                    box.Recycle();
                }
            }
        }
	}
}
