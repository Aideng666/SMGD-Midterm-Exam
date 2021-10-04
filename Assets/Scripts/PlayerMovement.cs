using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    bool isWalking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (!isWalking)
        {
            GetComponent<Animator>().SetInteger("AnimatorState", 0);
        }
        else
        {
            GetComponent<Animator>().SetInteger("AnimatorState", 1);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime / 1.5f, 0, moveSpeed * Time.deltaTime / 1.5f);
            transform.rotation = Quaternion.Euler(0, 45, 0);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime / 1.5f, 0, -moveSpeed * Time.deltaTime / 1.5f);
            transform.rotation = Quaternion.Euler(0, 135, 0);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime / 1.5f, 0, moveSpeed * Time.deltaTime / 1.5f);
            transform.rotation = Quaternion.Euler(0, 315, 0);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime / 1.5f, 0, -moveSpeed * Time.deltaTime / 1.5f);
            transform.rotation = Quaternion.Euler(0, 225, 0);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}
