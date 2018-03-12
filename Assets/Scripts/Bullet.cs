using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public BulletEvent OnShoot;
    public BulletEvent OnDestroy;

    public BulletState currentBulletState = BulletState.inPool;

    float timer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("TakeDamage", 1);
        }

        if (currentBulletState == BulletState.inUse)
        {
            DestroyBullet();
        }


    }

    private void Update()
    {
        if (currentBulletState == BulletState.inUse)
        {
            transform.position += direction * force;
            timer += Time.deltaTime;
            if (timer >= 2f && currentBulletState == BulletState.inUse)
            {
                DestroyBullet();
                
            }
        }

       
    }
    





    #region API

    #region Shoot

    Vector3 direction;
    float force;

    public void Shoot(Vector3 _direction, float _force)
    {
        currentBulletState = BulletState.inUse;
        if (OnShoot != null)
        {
            OnShoot(this);
        }
        direction = _direction;
        force = _force;
    }

    #endregion
    public void DestroyBullet()
    {
        currentBulletState = BulletState.inPool;
        if (OnDestroy != null)
        {
            OnDestroy(this);
        }
        timer = 0f;
    }

    #endregion

    #region Type declarations

    public delegate void BulletEvent(Bullet bullet);

    public enum BulletState { inPool, inUse };
    
    #endregion

}
