using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner2 : MonoBehaviour {

    public GameObject enemy;
    public Vector2 position;
    public float timer;
    public int score;
    private float startTimer;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start()
    {
        startTimer = timer;

    }

    // Update is called once per frame
    void Update()
    {

        if (ScoreManager.score >= score)
        {
            if (timer <= 0)
            {
                position.y = Random.Range(4.5f, -4.5f);
                Instantiate(enemy, position, Quaternion.identity);
                timer = startTimer;
            }
            timer -= Time.deltaTime;
        }
    }
}
