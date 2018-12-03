using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepawnEnemy : MonoBehaviour {

    public GameObject entity;
    public float time;
    public WaitForSeconds spawnTime;
    public Coroutine routine;
    public int numberofRespawns;

    

    // Use this for initialization
    void Start()
    {
        spawnTime = new WaitForSeconds(time);
        
    }

    public void Respawn()
    {
        if (numberofRespawns > 0)
        {
            StartCoroutine(SpawnEntity());
            numberofRespawns -= 1;
        }
        

    }

    public IEnumerator SpawnEntity()
    {
        entity.transform.position = gameObject.transform.position;

        entity.SetActive(false);

        entity.GetComponent<EnemyStats>().currentHealth = entity.GetComponent<EnemyStats>().maxHealth;

        yield return spawnTime;

        entity.SetActive(true);
        //Instantiate(entity, gameObject.transform.position, gameObject.transform.rotation);


    }
}
