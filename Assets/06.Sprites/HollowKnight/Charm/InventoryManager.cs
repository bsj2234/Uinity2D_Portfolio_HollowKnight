using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class InventoryManager : MonoBehaviour
{
    private UiCharmSelectable[] _selectables;
    private UiCharmEquipped[] _equppeds;
    public GameObject InventoryUi;
    public GameObject HudUi;

    private void Awake()
    {
        //Wow 레전드  FindObjectsOfTypeAll는 생성되지 않은 프리팹도 어디에서 가져온다 신기하다
        //역시 사파의 마구가져오기는 좋지 않다
        _selectables = GetComponentsInChildren<UiCharmSelectable>();
        _equppeds = GetComponentsInChildren<UiCharmEquipped>();

        Assert.IsNotNull( _selectables );
        Assert.IsNotNull( _equppeds );
    }

    public void RefreshAll()
    {
        foreach(UiCharmSelectable selectable in _selectables )
        {
            if( selectable.CharmIndex != -1 )
            {
                selectable.Refrash();
            }
        }
        foreach (UiCharmEquipped equipped in _equppeds )
        {
            if(equipped.EquipIndex != -1)
            {
                equipped.Refresh();

            }
        }
    }

    public void InventoryOn()
    {
        InventoryUi.SetActive(true);
        RefreshAll();
    }
    public void InventoryOff()
    {
        InventoryUi.SetActive(false);
    }
}
