using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

//��ư�� Ŭ���� �÷��̾� �κ��˻� �� 
//����/���� ����
//������ ĭ�� ������Ʈ �Ǿ����.
//�̺�Ʈ �����
public class UiCharmSelectable : MonoBehaviour
{
    public InventoryUi inventory;

    public int CharmIndex = -1;
    public Sprite DefaultSprite;
    private Button _button;
    private CharmInstance currentCharm;

    private void Awake()
    {
        _button = GetComponent<Button>();
        Assert.IsNotNull( _button );
        _button.onClick.AddListener(DoEquip);
        Assert.IsTrue(CharmIndex != -1, "EquipIndexNotSet");
        Assert.IsNotNull( DefaultSprite );



    }
    //��ư�� �������� ������ ������ ������ �����Ѵ�
    public void DoEquip()
    {
        //������ ���� ������ null��
        GameManager.Instance.GetPlayer().TryEquipCharm(CharmIndex);
        inventory.RefreshAll();
    }
    public void Refrash()
    {
        currentCharm = GameManager.Instance.GetPlayer().CharmAt(CharmIndex);
        bool isEquipped = GameManager.Instance.GetPlayer().IsItemEquipped(currentCharm);
        _button.image.sprite = (currentCharm != null && !isEquipped) ? currentCharm.CharmType.Icon : DefaultSprite;
    }

    public void OnMouseEnter()
    {
        currentCharm = GameManager.Instance.GetPlayer().CharmAt(CharmIndex);
        if(currentCharm != null )
        {
            UiManager.Instance.inventoryUi.SetDescription(currentCharm);
        }
    }
}
