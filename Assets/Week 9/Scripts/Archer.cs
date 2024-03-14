using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Villager
{
    public GameObject ArrowPrefab;
    public Transform SpawnPoint;
    public float delay = 0.25f;

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Invoke("SpawnArrow", delay);
    }
    void SpawnArrow()
    {
        Instantiate(ArrowPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Archer;
    }
}
