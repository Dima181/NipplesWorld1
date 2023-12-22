using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class BGAudioControllerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
         Container.Bind<BGAudioConfig>().FromInstance(new BGAudioConfig());
    }
}
