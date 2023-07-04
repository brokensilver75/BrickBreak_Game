using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_P1 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    Vector3 playerPosition, movement;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerPosition += -1 * movement; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPosition += movement;
        }
        transform.position = playerPosition;
    }
}
