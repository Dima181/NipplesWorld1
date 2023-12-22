using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GunInstaller : MonoInstaller
{
    [SerializeField] private GameObject parentObject = null;
    [SerializeField] private GunConfig AutomaticGun = null;
    [SerializeField] private GunConfig SniperGun = null;
    [SerializeField] private Transform GunSpawnPoint;
    [SerializeField] private string tagGun;

    public override void InstallBindings()
    {
        Container.Bind<GunSwitcher>().FromInstance(new GunSwitcher(parentObject, AutomaticGun, SniperGun, GunSpawnPoint, tagGun));
    }
}
