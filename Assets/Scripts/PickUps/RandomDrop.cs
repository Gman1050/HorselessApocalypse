using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour {

    public GameObject[] dropitems;
    float droprate = 0.25f;

    public void DropItem()
    {
        if (Random.Range(0f, 1f) <= droprate)
        {
            int indexToDrop = Random.Range(0, dropitems.Length);
            Instantiate(dropitems[indexToDrop], this.transform.position, this.transform.rotation);
        }
    }
}
