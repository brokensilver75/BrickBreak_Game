using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    float horizontalMovement;
    Vector3 player1Position, player2Position;
    [SerializeField] float leftExtreme, rightExtreme;
    [SerializeField] GameObject P1, P2;
    // Start is called before the first frame update
    void Start()
    {
        //Set Boundaries
        leftExtreme = -1.57f;
        rightExtreme = 1.57f;
        //Use variable for player position
        player1Position = P1.transform.position;
        player2Position = P2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayers();
    }

    private void MovePlayers()
    {
        //player1Position.x = Mathf.Clamp(P1.transform.position.x, leftExtreme, rightExtreme);
        //player2Position.x = Mathf.Clamp(P2.transform.position.x, leftExtreme, rightExtreme);
        //Move Player1
        if (Input.GetKey(KeyCode.A))
        {
            player1Position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player1Position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        P1.transform.position = player1Position;

        //Move Player2
         if (Input.GetKey(KeyCode.LeftArrow))
        {
            player2Position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player2Position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        P2.transform.position = player2Position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "LeftWall" )
        {
            leftBound = true;
        }
        if (collision.gameObject.tag == "RightWall")
        {
            rightBound = true;
        }*/
    }
}
