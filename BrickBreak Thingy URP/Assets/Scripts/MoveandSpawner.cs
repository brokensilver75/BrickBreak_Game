using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveandSpawner : MonoBehaviour
{
    [Header("Spawner Movement")]
    [SerializeField] float topLimit = 4f, bottomLimit = -1f, speed = 100f;
    [Header("Spawn Stuff")]
    [SerializeField] GameObject ufo;
    [Header("Spawn Stuff")]
    [SerializeField] float spawnInterval;

    bool startedRunning = false;
    
    GameObject newUFO;
    Vector3 spawnerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spawnerSpeed = new Vector3(0, speed, 0);
        StartCoroutine(spawnUFO(spawnInterval, ufo));
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpawner();
        
    }

    private void MoveSpawner()
    {
        transform.position += spawnerSpeed * Time.deltaTime;
        Mathf.Clamp(transform.position.y, topLimit, bottomLimit);
        if (transform.position.y >= topLimit || transform.position.y <= bottomLimit)
        {
            speed *= -1f;
            spawnerSpeed = new Vector3(0, speed, 0);
        }
    }

    IEnumerator spawnUFO(float interval, GameObject ufo)
    {
        yield return new WaitForSecondsRealtime(interval);
        newUFO = Instantiate(ufo, transform.position, ufo.transform.rotation);
        StartCoroutine(spawnUFO(interval, ufo));
    }
}
