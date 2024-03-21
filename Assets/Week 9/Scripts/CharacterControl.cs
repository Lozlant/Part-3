using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public TMP_Dropdown dropdown;
    public Villager[] villagers=new Villager[3];
    public Slider slider;

    private void Start()
    {
        Instance = this;
        StartCoroutine(startchoose());
    }
    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }
    public void ChooseVillager(int value)
    {
        SetSelectedVillager(villagers[value]);
        slider.value = SelectedVillager.transform.localScale.x;
    }

    IEnumerator startchoose()
    {
        yield return 0;
        ChooseVillager(0);
    }

    public void ChangeScale(float value)
    {
        SelectedVillager.transform.localScale = Vector3.one*value;
    }
    /*private void Update()
    {
        if(SelectedVillager != null)
        {
            currentSelection.text = SelectedVillager.GetType().ToString();
        }
    }*/
}
