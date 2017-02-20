using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject enemy;
    public Vector2 position;
    public float timer;
    private float startTimer;
	// Use this for initialization
	void Start () {
        startTimer = timer;
	}
	
	// Update is called once per frame
	void Update () {
	if (timer <= 0)
        {
            Instantiate(enemy, position, Quaternion.identity);
            timer = startTimer;
        }
        timer -= Time.deltaTime;
	}
}
