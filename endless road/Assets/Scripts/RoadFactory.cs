using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFactory : MonoBehaviour
{
    public GameObject Prototype;
    public Transform Spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlockSpawn());
    }

    IEnumerator BlockSpawn()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(Prototype, Spawnpoint.position, Spawnpoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
