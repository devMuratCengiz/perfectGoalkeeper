using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float xLimit = 2.25f;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xLimit, xLimit), transform.position.y, transform.position.z);

    }
}
