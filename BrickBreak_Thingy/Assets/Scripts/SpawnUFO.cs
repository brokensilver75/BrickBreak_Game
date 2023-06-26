using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUFO : MonoBehaviour
{
    [SerializeField] GameObject ufo;
    bool ufoInField;

    // Start is called before the first frame update
    void Start()
    {
        ufoInField = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("UFO") == null)
        {
            ufoInField = false;
        }

        if (!ufoInField)
        {
            Instantiate(ufo, transform.position, Quaternion.identity);
            ufoInField = true;
        }
    }
}

