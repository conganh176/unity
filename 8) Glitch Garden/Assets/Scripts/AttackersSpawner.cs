using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackersSpawner : MonoBehaviour
{
    bool isSpawn = true;
    [SerializeField] float minRandomTime = 1f;
    [SerializeField] float maxRandomTime = 5f;
    [SerializeField] Attackers[] attackerPrefab;

    IEnumerator Start()
    {
        while (isSpawn)
        {
            FindObjectOfType<LevelController>().attackerSpawned();
            yield return new WaitForSeconds(Random.Range(minRandomTime, maxRandomTime));
            ChooseSpawner();
        }
    }

    public void StopSpawning()
    {
        isSpawn = false;
    }

    private void ChooseSpawner()
    {
        var attackerIndex = Random.Range(0, attackerPrefab.Length);
        Spawn(attackerPrefab[attackerIndex]);
    }

    private void Spawn(Attackers attacker)
    {
        Attackers newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attackers;
        newAttacker.transform.parent = transform;       //Put in Spawner game object as a child
    }
}
