using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUFO : MonoBehaviour
{
    [SerializeField] GameObject ufoPrefab;
    GameObject newUFO;
    [SerializeField] float topLimit, bottomLimit, speed;
    [SerializeField] float spawnInterval = 3f;
    Vector3 offset = new Vector3(-1.5f, 0, 0);
    Vector3 spawnerPos, spawnerVel;
    //Quaternion ufoRotation = new Quaternion(45f, 0, 0, 0);
    Rigidbody spawnerRB;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnUFO(spawnInterval, ufoPrefab));
        topLimit = 1.7f;
        bottomLimit = 0.1f;
        speed = 0f;
        spawnerPos = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnerVel = new Vector3(0, speed, 0); 
        transform.position += spawnerVel * Time.deltaTime;
        if (transform.position.y >= topLimit || transform.position.y <=bottomLimit)
        {
            speed *= -1f;
            spawnerVel = new Vector3(0, speed, 0);
        }

    }

    private IEnumerator spawnUFO(float interval, GameObject ufo)
    {
        yield return new WaitForSecondsRealtime(interval);
        newUFO = Instantiate(ufo, transform.position + offset, ufoPrefab.transform.rotation);
        StartCoroutine(spawnUFO(interval, ufo));
    }
}

