using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerPosition;
    public float offset = 10f;
    Transform campos;
    void Start()
    {
        campos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerPosition.position.x,
         PlayerPosition.position.y+offset, transform.position.z);
    }
}
