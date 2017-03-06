using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public float movementspeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.left * movementspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * movementspeed * Time.deltaTime);
        }
    }
}
