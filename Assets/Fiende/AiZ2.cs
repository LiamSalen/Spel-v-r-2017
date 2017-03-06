using UnityEngine;
using System.Collections;

public class AiZ2 : MonoBehaviour
{

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;


    void Start()
    {

    }

    void Update()
    {
        //Targets the player
        target = GameObject.FindWithTag("Player").transform;

        if(transform.position.x > target.position.x)//Changes rotation to look at the player
        {
            transform.localScale = new Vector3(-0.22f, 0.22f, 0.22f);
        }
        else
        {
            transform.localScale = new Vector3(0.22f, 0.22f, 0.22f);
        }

        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }

}