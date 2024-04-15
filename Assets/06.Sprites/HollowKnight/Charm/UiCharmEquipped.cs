using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

//��ư�� Ŭ���� �÷��̾� �κ��˻� �� 
//����/���� ����
public class UiCharmEquipped : MonoBehaviour
{
    public InventoryManager inventory;

    public int EquipIndex = -1;
    public Sprite DefaultSprite;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        Assert.IsNotNull( _button );
        _button.onClick.AddListener(DoEquipUnequip);
        Assert.IsTrue(EquipIndex != -1, "EquipIndexNotSet");
        Assert.IsNotNull( DefaultSprite );
    }
    //��ư�� �������� ������ ������ ������ �����Ѵ�
    public void DoEquipUnequip()
    {
        CharmInstance unequippedItem = GameManager.Instance.GetPlayer().EquipUnequipCharm(EquipIndex);
        _button.image.sprite = (unequippedItem != null) ? unequippedItem.CharmType.Icon : DefaultSprite;
        inventory.RefreshAll();
    }

    public void Refresh()
    {
        CharmInstance unequippedItem = GameManager.Instance.GetPlayer().EquppedCharmAt(EquipIndex);
        _button.image.sprite = (unequippedItem != null) ? unequippedItem.CharmType.Icon : DefaultSprite;

    }

}
