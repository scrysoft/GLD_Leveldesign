using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3 targetRotation;

    [SerializeField] float positionSpeed;
    [SerializeField] float rotationSpeed;

    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTriggered) return;
        transform.position = Vector3.Lerp(transform.position, targetPosition, positionSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed * Time.deltaTime);
    }
}
