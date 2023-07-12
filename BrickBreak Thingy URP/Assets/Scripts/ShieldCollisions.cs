using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "UFO")
        {
            Destroy(other.gameObject);  
            health -= 10f;            
        }
    }
}
