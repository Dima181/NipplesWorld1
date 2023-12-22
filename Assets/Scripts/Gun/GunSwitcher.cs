using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher
{
    private GameObject parentPoint = null;

    private GunConfig AutomaticGun = null;
    private GunConfig SniperGun = null;

    private Transform GunSpawnPoint = null;

    private string tagGun = null;
    public GunSwitcher(GameObject parentPoint, GunConfig automaticGun, GunConfig sniperGun, Transform gunSpawnPoint, string tagGun)
    {
        this.parentPoint = parentPoint;
        AutomaticGun = automaticGun;
        SniperGun = sniperGun;
        GunSpawnPoint = gunSpawnPoint;
        this.tagGun = tagGun;
    }

    public GameObject SpawnGun(int spawned)
    {
        var spawnedGun = spawned switch
        {
            1 => SpawnAutomaticGun(),
            2 => SpawnSniperGun(),
            _ => null,
        };
        return spawnedGun;
    }

    private GameObject SpawnAutomaticGun()
    {
        var oblect = SpawnGun(AutomaticGun.GunPrefab);

        var gun = oblect.GetComponent<Gun>();
        gun.pauseBetweenShots = 0.1f;
        gun.bulletCount = AutomaticGun.BulletCount;
        gun.pauseBetweenReload = AutomaticGun.PauseBetweenReload;
        return oblect;
    }

    private GameObject SpawnSniperGun()
    {
        var oblect = SpawnGun(SniperGun.GunPrefab);
       
        var gun = oblect.GetComponent<Gun>();
        gun.pauseBetweenShots = 2;
        gun.bulletCount = SniperGun.BulletCount;
        gun.pauseBetweenReload = SniperGun.PauseBetweenReload;
        return oblect;
    }

    private GameObject SpawnGun(GameObject prefab)
    {
        GameObject obj = GameObject.FindGameObjectWithTag(this.tagGun);
        if (obj != null)
        {
            GameObject.Destroy(obj);
        }

        var currentGunObject = GameObject.Instantiate(prefab, GunSpawnPoint.position, GunSpawnPoint.rotation);
        currentGunObject.transform.SetParent(parentPoint.transform);  
        return currentGunObject;
    }
    
}
