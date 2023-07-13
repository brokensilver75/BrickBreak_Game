using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 100f;
    Material shieldMaterial;
    Shader shieldShader; 
    void Start()
    {
        shieldMaterial = GetComponent<MeshRenderer>().sharedMaterial;
        shieldShader = GetComponent<Shader>();

        Debug.Log (shieldMaterial.GetColor("_Base"));
        
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
            shieldMaterial.SetColor("_Base", Color.red);
                    
        }
    }
}
