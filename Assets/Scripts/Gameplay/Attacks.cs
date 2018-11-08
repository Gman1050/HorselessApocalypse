using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [Header("Basic Attack Settings: ")]
    [Range(0, 5)] public float basicAttackRange = 3.0f;
    [Range(0, 90)] public float basicAttackAngleLimit = 90.0f;

    [Header("Pestilence Attack Settings: ")]
    [Range(0, 5)] public float pestilenceAttackRange = 3.0f;
    [Range(0, 90)] public float pestilenceAttackAngleLimit = 90.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void BasicAttack(GameObject enemy)
    {
        // Create boundaries for Attack range using trigonometry
        Vector3 targetDir = enemy.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        float distance = Vector3.Distance(enemy.transform.position, transform.position);

        // Detect if enemy is within range of boundaries
        if (angle <= basicAttackAngleLimit && distance <= basicAttackRange)
        {
            print("close");
        }

        // Deal damage to enemy and perhaps stun time
    }
}
