using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperController : MonoBehaviour
{
    
    private float xLimit = 2.2f;
    public Transform ball;
    public float delay = .5f;
    public float goalKeeperSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        goalKeeperSpeed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        ball = GameObject.Find("Ball").GetComponent<Transform>();
        var newX = ball.transform.position.x;
        newX = Mathf.Clamp(newX, -xLimit, xLimit);

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, newX, goalKeeperSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        
       // transform.position.x = new Vector3(Mathf.Clamp(transform.position.x,-xLimit,xLimit);
    }
}
