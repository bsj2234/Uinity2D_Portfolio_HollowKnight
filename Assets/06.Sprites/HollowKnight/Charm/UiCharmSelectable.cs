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
    public int CharmIndex = -1;
    public Sprite DefaultSprite;
    private Button _button;

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
        UiManager.Instance.RefreshAll();
    }
    public void Refrash()
    {
        CharmInstance currentCharm = GameManager.Instance.GetPlayer().CharmAt(CharmIndex);
        bool isEquipped = GameManager.Instance.GetPlayer().IsItemEquipped(currentCharm);
        _button.image.sprite = (currentCharm != null && !isEquipped) ? currentCharm.CharmType.Icon : DefaultSprite;
    }

}
