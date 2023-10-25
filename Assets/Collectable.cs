using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float jumpIncrease = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            movement move = player.GetComponent<movement>();
            if (move && gameObject.tag == "PowerUp")
            {
                move.jumpForce += jumpIncrease;
            }
            Destroy(gameObject);
            Debug.Log("Collected");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
