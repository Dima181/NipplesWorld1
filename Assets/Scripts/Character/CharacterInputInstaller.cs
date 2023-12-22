using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CharacterInputController>().FromInstance(new CharacterInputController());
    }
}
