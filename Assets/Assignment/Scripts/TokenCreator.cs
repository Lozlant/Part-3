using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenCreator : MonoBehaviour
{
    public GameObject ScreenCanvas;
    public GameObject EnemyPrefab;

    static Coroutine spawnEnemy;
    public float spawnInterval = 5;
    public void CreateAPreToken(GameObject pre_Token)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(pre_Token,ScreenCanvas.transform,false);
    }

    private void Update()
    {
        if (GameController.SpawnToken != null)
        {
            Instantiate(GameController.SpawnToken, gameObject.transform, true);
            GameController.setSpawnToken(null);
            if (spawnEnemy == null) spawnEnemy=StartCoroutine(SpawnEnemy()); 
        }
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true){ 
        Instantiate(EnemyPrefab);
        yield return new WaitForSeconds(spawnInterval);
        }
    }
}
