using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text CharmDescName;
    public TMP_Text CharmSlot;
    public TMP_Text CharmBroken;
    public TMP_Text CharmDesc;

    private void Awake()
    {
        //Wow 레전드  FindObjectsOfTypeAll는 생성되지 않은 프리팹도 어디에서 가져온다 신기하다
        // 마구가져오기는 좋지 않다
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

    public void SetDescription(CharmInstance charm)
    {
        CharmDescName.text = charm.CharmType.name;
        CharmSlot.text = $"슬롯: {charm.CharmType.Slot}";
        CharmBroken.text = charm.CharmType.Broken? "파괴됨":"";
        CharmDesc.text = charm.CharmType.Description;
    }
}
