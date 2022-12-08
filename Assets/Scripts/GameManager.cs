using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            int index = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[index]);
        }
    }
}
