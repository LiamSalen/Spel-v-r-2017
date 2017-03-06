using UnityEngine;
using System.Collections;

public class SpawnAroundCameraBorder : MonoBehaviour
{
    public GameObject someGameObject;
    public float timer;
    private float startTimer;
    // Use this for initialization
    void Start()
    {
        startTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            SpawnRandom();
            timer = startTimer;
        }
        timer -= Time.deltaTime;
    }

    public void SpawnRandom()
    {
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane+5)); //will get the middle of the screen

        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        Instantiate(someGameObject, screenPosition, Quaternion.identity);
    }
}