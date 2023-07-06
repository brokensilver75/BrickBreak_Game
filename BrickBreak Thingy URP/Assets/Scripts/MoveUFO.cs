using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUFO : MonoBehaviour
{
    [Header("UFO Movement Speed")]
    [SerializeField] float ufoSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-ufoSpeed, 0, 0) * Time.deltaTime;
    }
}
