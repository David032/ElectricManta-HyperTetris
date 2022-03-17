using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Groups = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject() 
    {
        int i = Random.Range(0, Groups.Capacity);
        Instantiate(Groups[i], transform.position, Quaternion.identity);
    }
}
