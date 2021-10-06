using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform camTrans;
    [SerializeField] float walkSpeed = 10f;
    [SerializeField] float sprintSpeed = 15f;

    float turnSmoothing = 0.1f;
    float turnSmoothVel;
    float speed;

    int coinCount = 0;

    bool isWalking;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            isWalking = true;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTrans.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothing);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            isWalking = false;
        }

        if (!isWalking)
        {
            GetComponent<Animator>().SetInteger("AnimatorState", 0);
        }
        else
        {
            GetComponent<Animator>().SetInteger("AnimatorState", 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinCount++;
        }
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
