using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public interface IDestructible
{
    public void Hit();
    public void Destruct();
}

//�±� �˻��� �浹�� �����ð� ��� �־��ְ� ���������� 
public class Destructable : MonoBehaviour, IDestructible
{
    private int _currentHit = 0;
    public int destructHit = 3;
    private float HitTime = 0f;
    public Animator _animator;
    public bool isDestructed = false;
    public string[] _damagableTag;
    public int CoinSpawn = 0;
    public GameObject[] Effects;

    public void Hit()
    {
        //�����ð�, ����Ʈ, �ִϸ��̼�
        HitTime = Time.time;
        if (_animator != null )
        {
            _animator.SetTrigger("Hit");
        }
        _currentHit++;
    }
    public void Destruct()
    {
        ObjectSpawnManager.Instance.SpawnMoney(transform.position + Vector3.up * .4f, CoinSpawn);
        if (_animator != null)
        {
            _animator.SetTrigger("Dead");
        }
        else
        {
            gameObject.SetActive(false);
        }
        isDestructed = true;
    }



    private void Awake()
    {
        foreach (string tag in _damagableTag)
        {
            Assert.IsTrue(tag != "");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ı�
        if (isDestructed)
        { return; }
        //����������
        //damagableTag�� ������ IDamageable �����ؾ���
        foreach (string tag in _damagableTag)
        {
            //�浹ü�� �±װ� �´°� �ִٸ�
            if (collision.CompareTag(tag))
            {
                //�� ó��
                if (Time.time - HitTime < .1f)
                {
                    return;
                }
                else
                {
                    Hit();
                }
                //�ı� ó��
                if (_currentHit >= destructHit)
                {
                    Destruct();
                }
                //����Ʈ ����
                foreach (GameObject effect in Effects)
                {
                    ObjectSpawnManager.Instance.SpawnBetween(effect ,collision.transform.position, transform.position, 3f);
                }
            }
        }
    }

}
