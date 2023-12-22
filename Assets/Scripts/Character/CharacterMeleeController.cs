using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterMeleeController : MeleeAttack
{
    [Inject] private CharacterInputController characterInputController { get; set; }

    [SerializeField] private bool isPlayer;

    private void Update()
    {
        if (!isPlayer)
        {
            var controllerInput = characterInputController.InputButtonCheckMelee();
            Attack();
        }   
    }
}
