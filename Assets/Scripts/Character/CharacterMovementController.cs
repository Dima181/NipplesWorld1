using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float smoothTime;

    private float smoothVelocity;

    [SerializeField] private Transform firstCamera;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3 (horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + firstCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 move = Quaternion.Euler(0, rotationAngle, 0) * Vector3.forward;

            gameObject.transform.Translate(move.normalized * force * Time.deltaTime);
        }
    }
}
