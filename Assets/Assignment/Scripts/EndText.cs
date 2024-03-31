using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndText : MonoBehaviour
{
    public TextMeshProUGUI lable;

    private void Update()
    {
        lable.text = "The Winner is: \r\n" + GameController.winner.ToString();
    }

}
