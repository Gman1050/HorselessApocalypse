using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGate : MonoBehaviour
{
    public List<RepawnEnemy> spawnPoints;

    private int count = 0;
    private int totalSpawnPoints = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        totalSpawnPoints = spawnPoints.Count;    
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < spawnPoints.Count; i++)
        {
            if (!spawnPoints[i].gameObject.activeSelf)
            {
                spawnPoints.Remove(spawnPoints[i]);
                count++;
            }
        }

        if (count >= totalSpawnPoints)
            gameObject.SetActive(false);
    }
}
