using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    private UiCharmSelectable[] _selectables;
    private UiCharmEquipped[] _equppeds;
    public GameObject _InventoryUiGameObject;
    public GameObject HudUi;

    private void Awake()
    {
        //Wow ������  FindObjectsOfTypeAll�� �������� ���� �����յ� ��𿡼� �����´� �ű��ϴ�
        // ������������� ���� �ʴ�
        _selectables = GetComponentsInChildren<UiCharmSelectable>();
        _equppeds = GetComponentsInChildren<UiCharmEquipped>();

        Assert.IsNotNull( _selectables );
        Assert.IsNotNull( _equppeds );
    }

    public void RefreshAll()
    {
        foreach(UiCharmSelectable selectable in _selectables )
        {
            if(selectable == null)
            {
                continue;
            }
            if( selectable.CharmIndex != -1 )
            {
                selectable.Refrash();
            }
        }
        foreach (UiCharmEquipped equipped in _equppeds )
        {
            if (equipped == null)
            {
                continue;
            }
            if (equipped.EquipIndex != -1)
            {
                equipped.Refresh();

            }
        }
    }

    public void InventoryOn()
    {
        _InventoryUiGameObject.SetActive(true);
        RefreshAll();
    }
    public void InventoryOff()
    {
        _InventoryUiGameObject.SetActive(false);
    }

    public void SetActive(bool v)
    {
        _InventoryUiGameObject.SetActive(v);
    }
}
