using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public interface IDestructible
{
    public void Hit();
    public void Destruct();
}

//태그 검사후 충돌시 무적시간 잠시 넣어주고 맞을떄마다 
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
        //무적시간, 이펙트, 애니메이션
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
        //파괴
        if (isDestructed)
        { return; }
        //공격했을때
        //damagableTag는 무조건 IDamageable 보장해야함
        foreach (string tag in _damagableTag)
        {
            //충돌체중 태그가 맞는게 있다면
            if (collision.CompareTag(tag))
            {
                //힛 처리
                if (Time.time - HitTime < .1f)
                {
                    return;
                }
                else
                {
                    Hit();
                }
                //파괴 처리
                if (_currentHit >= destructHit)
                {
                    Destruct();
                }
                //이펙트 스폰
                foreach (GameObject effect in Effects)
                {
                    ObjectSpawnManager.Instance.SpawnBetween(effect ,collision.transform.position, transform.position, 3f);
                }
            }
        }
    }

}
