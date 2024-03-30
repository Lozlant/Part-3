using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static Vector2[] towerposition { get; private set; } = new Vector2[2];
    public static GameObject SpawnToken { get; private set; }
    public static void setTowerPosition(Type type,Vector2 position)
    {
        towerposition[(int)type] = position;
    }
    public static void setSpawnToken(GameObject prefab)
    {
        SpawnToken = prefab;
    }




}
