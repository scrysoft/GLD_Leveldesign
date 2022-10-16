using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    GameObject player;
    [SerializeField] Transform leftDoor = null;
    [SerializeField] Transform rightDoor = null;
    bool isOpened = false;
    bool isTriggered = false;
    MoveTo[] list;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        list = FindObjectsOfType<MoveTo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (leftDoor.position.x >= 2f) return;

        if (!isOpened && isTriggered)
        {

            leftDoor.position = Vector3.Lerp(leftDoor.position, new Vector3(leftDoor.position.x + 1f, leftDoor.position.y, leftDoor.position.z), 2f * Time.deltaTime);
            rightDoor.position = Vector3.Lerp(rightDoor.position, new Vector3(rightDoor.position.x - 1f, rightDoor.position.y, rightDoor.position.z), 2f * Time.deltaTime);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;

        foreach(MoveTo listItem in list)
        {
            listItem.isTriggered = true;
        }
    }

}
