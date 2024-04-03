using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static Vector2[] towerposition { get; private set; } = new Vector2[2];
    public static GameObject SpawnToken { get; private set; }
    public static Type winner { get; private set; }
    public static int money { get; private set; } = 600;
    
    public TextMeshProUGUI moneyLable;
    private void Start()
    {
        Instance = this;
        setMoney(money);
    }
    public static void setTowerPosition(Type type,Vector2 position)
    {
        towerposition[(int)type] = position;
    }
    public static void setSpawnToken(GameObject prefab)
    {
        SpawnToken = prefab;
    }
    public static void setWinner(Type type)
    {
        winner=type;
    }
    public static void setMoney(int m)
    {
        money = m;
        Instance.moneyLable.text = "Money: $" + money;
    }
}
