using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public int movementspeed = 10;
    public float jumpPower = 10;
    public bool grounded = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * movementspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * movementspeed * Time.deltaTime);
        }
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //transform.Translate(Vector2.up * jumpPower);
        //}
        if (!grounded && GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            grounded = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
                grounded = false;
            }

    }
}

