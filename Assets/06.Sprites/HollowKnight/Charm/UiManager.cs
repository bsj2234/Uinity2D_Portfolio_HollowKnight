using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class UiManager : Singleton<UiManager>
{
    private UiCharmSelectable[] _selectables;
    private UiCharmEquipped[] _equppeds;
    public GameObject InventoryUi;

    private void Awake()
    {
        //Wow ������ �����յ� ��𿡼� �����´� �ű��ϴ�
        //���� ������ ������������� ���� �ʴ�
        _selectables = FindObjectsOfTypeAll(typeof(UiCharmSelectable)) as UiCharmSelectable[];
        _equppeds = FindObjectsOfTypeAll(typeof(UiCharmEquipped)) as UiCharmEquipped[];

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
