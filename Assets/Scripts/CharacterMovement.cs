using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform camTrans;
    [SerializeField] float speed = 5f;
    [SerializeField] float turnSmoothing = 0.1f;

    float turnSmoothVel;

    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

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
}