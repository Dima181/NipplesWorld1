using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterGunController : MonoBehaviour
{
    [Inject] private GunSwitcher gunSwitcher { get; set; }
    [Inject] private CharacterInputController characterInputController { get; set; }

    private void Update()
    {
        var controllerInput = characterInputController.InputButtonCheckGun();
        gunSwitcher.SpawnGun(controllerInput);

    }
}
