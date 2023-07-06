using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool ballStartMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetBallMovingStatus()
    {
        return ballStartMoving;
    }

    public void SetBallMovingStatus(bool value)
    {
        ballStartMoving = value;
    }
}
