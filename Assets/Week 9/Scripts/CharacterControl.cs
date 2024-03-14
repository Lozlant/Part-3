using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI villagerTypeLable;
    public static Villager SelectedVillager { get; private set; }

    private void Update()
    {
        if (SelectedVillager == null)
        {
            villagerTypeLable.text = "No Selection";
            return;
        }
        villagerTypeLable.text = SelectedVillager.GetType().ToString();
    }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
    }
    
}
