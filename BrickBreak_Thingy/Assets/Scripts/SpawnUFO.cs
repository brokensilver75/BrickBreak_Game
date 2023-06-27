using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUFO : MonoBehaviour
{
    [SerializeField] GameObject ufoPrefab;
    GameObject newUFO;
    [SerializeField] float spawnInterval = 3f;
    Vector3 offset = new Vector3(-3f, 0, 0);
    Quaternion ufoRotation = new Quaternion(45f, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnUFO(spawnInterval, ufoPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnUFO(float interval, GameObject ufo)
    {
        yield return new WaitForSeconds(interval);
        newUFO = Instantiate(ufo, transform.position + offset, ufoPrefab.transform.rotation);
        StartCoroutine(spawnUFO(interval, ufo));
    }
}

