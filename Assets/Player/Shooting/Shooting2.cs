using UnityEngine;
using System.Collections;

public class Shooting2 : MonoBehaviour {
    public int damage = 1;
    public bool isEnemyShot = false;
    public int killtimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, killtimer);
	}
}
