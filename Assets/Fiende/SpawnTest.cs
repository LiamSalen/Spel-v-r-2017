using UnityEngine;
using System.Collections;

public class SpawnTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 dir = Random.insideUnitCircle;
        Vector3 position = Vector3.zero;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {//make it appear on the side
            position = new Vector3(Mathf.Sign(dir.x) * Camera.main.orthographicSize * Camera.main.aspect,
                                    0,
                                    dir.y * Camera.main.orthographicSize);
        }
        else
        {//make it appear on the top/bottom
            position = new Vector3(dir.x * Camera.main.orthographicSize * Camera.main.aspect,
                                    0,
                                    Mathf.Sign(dir.y) * Camera.main.orthographicSize);
        }
    }
}
