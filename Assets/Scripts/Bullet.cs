using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public BulletEvent OnShoot;
    public BulletEvent OnDestroy;

    public BulletState currentBulletState = BulletState.inPool;

    private void OnCollisionEnter(Collision collision)
    {
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
    }

    #endregion

    #region Type declarations

    public delegate void BulletEvent(Bullet bullet);

    public enum BulletState { inPool, inUse };
    
    #endregion

}
