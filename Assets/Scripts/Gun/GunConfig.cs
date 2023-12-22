using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunTypes", menuName = "Game/Gun Config")]
public class GunConfig : ScriptableObject
{
    [SerializeField] private GameObject gunPrefab = null;
    [SerializeField] private int bulletCount = 0;
    [SerializeField] private int pauseBetweenReload = 0;

    public GameObject GunPrefab => gunPrefab;
    public int BulletCount => bulletCount;
    public int PauseBetweenReload => pauseBetweenReload;
}
