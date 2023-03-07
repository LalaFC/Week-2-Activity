using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class userCtrl : MonoBehaviour
{
    public float Speed = 4;
    public bool isRunning;
    public int runMultiplier = 3;
    Rigidbody2D PlayerRB;
    bool Right = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent < Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = Speed;

    //Check for Shift Button
        if (Input.GetKey(KeyCode.LeftShift))
            isRunning = true; 
        else isRunning = false;

    //Normal to Run Speed
        if (isRunning == true)
            moveSpeed = Speed * runMultiplier;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

    //Switching Avatar Direction
        if (horizontal < 0 && Right == false)
            Flip();
        if (horizontal > 0 && Right == true)
            Flip();

        Vector2 Movement = new Vector2(horizontal, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(Movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            UnityEngine.Debug.Log("Congratulations you've won.");
            SceneManager.LoadScene(0);

        }
    }

    void Flip()
    {
        Vector3 ObjectDir = gameObject.transform.localScale;
        ObjectDir.x *= -1;
        gameObject.transform.localScale = ObjectDir;
        Right = !Right;
    }
}