using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPoint1,spawnPoint2;
    public float delay1=0.11f, delay2 = 0.23f;
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
    protected override void Attack()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.Attack();
        Invoke("SpawnDagger1", delay1);
        Invoke("SpawnDagger2", delay2);
    }

    void SpawnDagger1()
    {
        Instantiate(daggerPrefab, spawnPoint1.position, spawnPoint1.rotation);
    }
    void SpawnDagger2()
    {
        Instantiate(daggerPrefab, spawnPoint2.position, spawnPoint2.rotation);
    }
}
