using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 100f;
    [Header("Intensity of shield")]
    [SerializeField] float intensity = 3.2f;
    Material shieldMaterial;
    BoxCollider shieldCollider;
    MeshRenderer shieldRenderer;
    Shader shieldShader; 
    Color[] shieldColor = {new Color(0.1098f, 1.4980f, 1.4274f, 1f),
                           new Color(1.3200f, 1.4980f, 0.1098f, 1f),
                           new Color(1.4980f, 0.6240f, 0.1098f, 1f),
                           new Color(1.4980f, 0.1098f, 0.1362f, 1f)};

    void Start()
    {
        shieldMaterial = GetComponent<MeshRenderer>().sharedMaterial;
        shieldShader = GetComponent<Shader>();
        shieldCollider = GetComponent<BoxCollider>();
        shieldRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 100 && health >= 75)
            shieldMaterial.SetColor("_Base", shieldColor[0] * intensity);
            
        if (health < 75 && health >= 50)
            shieldMaterial.SetColor("_Base", shieldColor[1] * intensity);
            
        if (health < 50 && health >= 25)
            shieldMaterial.SetColor("_Base", shieldColor[2] * intensity);
            
        if (health < 25)
            shieldMaterial.SetColor("_Base", shieldColor[3] * intensity);
            
        if (health <= 0)
        {
            //Destroy (gameObject);
            shieldRenderer.enabled = false;
            shieldCollider.enabled = false;
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

    public float GetHealth()
    {
        return health; 
    }
}
