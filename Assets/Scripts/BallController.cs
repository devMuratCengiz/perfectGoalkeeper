using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    private float xLimit = 2.62f;

    BallSpawner ballSpawner;
    GameManager gameManager;
    GoalKeeperController goalKeeperController;

    public float moveSpeed = 50f;
    public float sideForce = 50f;
    // Start is called before the first frame update
    void Start()
    {
        goalKeeperController = GameObject.Find("GoalKeeper").GetComponent<GoalKeeperController>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        rb.AddForce(Vector2.down * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xLimit, xLimit), transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float a = player.position.x - transform.position.x;
        if (collision.gameObject.tag=="Player")
        {
            rb.AddForce(Vector2.up * moveSpeed);
            rb.AddForce(Vector2.left * sideForce * a);
        }
        if (collision.gameObject.tag=="GoalKeeper")
        {
            rb.AddForce(Vector2.down * moveSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="GoalAi")
        {
            gameManager.UpdateScore();
            Start();
            goalKeeperController.goalKeeperSpeed += .5f;
        }
        if (collision.gameObject.tag=="GoalPlayer")
        {
            gameManager.GameOver();
        }
    }
}
