using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour, IShootGun
{
    [SerializeField] private Transform positionFire = null;
    [SerializeField] private GameObject bulletPrefab = null;

    public float pauseBetweenShots = 0;
    public int bulletCount = 0;
    public float pauseBetweenReload = 0;

    private int maxBulletCount = 0;
    private bool isFire = true;
    private bool isReload = false;

    private void Start()
    {
        maxBulletCount = bulletCount;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Fire();
        }
    }
    
    public void Fire()
    {
        if (isReload == false && isFire == true)
        {
            Instantiate(bulletPrefab, positionFire.position, positionFire.rotation);
            if (bulletCount > 0)
            {
                bulletCount--;
            }
            else
            {
                //yield return MissingReferenceException(bulletCount); дописать
                bulletCount = 0;
            }

            isFire = false;

            if (bulletCount == 0)
            {
                isReload = true;
                StartCoroutine(Reload());
            }
            else
            {
                StartCoroutine(Delay());
            }
        }
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(pauseBetweenReload);
        bulletCount = maxBulletCount;
        isReload = false;
        isFire = true;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(pauseBetweenShots);
        isFire = true;
    }
}

public interface IShootGun
{
    void Fire();

    IEnumerator Reload();
}

public interface IMeleeSword
{
    void Hit();
}