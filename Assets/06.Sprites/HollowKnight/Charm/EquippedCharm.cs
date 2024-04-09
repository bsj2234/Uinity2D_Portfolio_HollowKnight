using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

//��ư�� Ŭ���� �÷��̾� �κ��˻� �� 
//����/���� ����
public class EquippedCharm : MonoBehaviour
{
    public int EquipIndex = -1;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        Assert.IsNotNull( _button );
        _button.onClick.AddListener(DoEquipUnequip);
        Assert.IsTrue(EquipIndex != -1, "EquipIndexNotSet");
    }
    //��ư�� �������� ������ ������ ������ �����Ѵ�
    public void DoEquipUnequip()
    {
        CharmInstance unequippedItem = GameManager.Instance.GetPlayer().EquipUnequipCharm(EquipIndex);
        _button.image.sprite = unequippedItem?.CharmType.icon;
    }

}
