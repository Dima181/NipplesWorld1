using UnityEngine;

public class CharacterEnterController : MonoBehaviour
{
    [SerializeField] public int audioCountPlay = 0;
    [SerializeField] private CharacterAudioController characterAudioController;

    private void Start()
    {
        characterAudioController.SpawnAudioGameObject(audioCountPlay);
    }

    private void OnTriggerExit(Collider other)
    {
        audioCountPlay = 0;

        if (other.gameObject.tag == "ExitVillage") { audioCountPlay = 1; }
        else if(other.gameObject.tag == "ExitTower") { audioCountPlay = 1;  }
        else if (other.gameObject.tag == "ExitForest") { audioCountPlay = 1;  }
        else if (other.gameObject.tag == "EnterVillage") { audioCountPlay = 2; }
        else if (other.gameObject.tag == "EnterTower") { audioCountPlay = 3; }
        else if (other.gameObject.tag == "EnterForest") { audioCountPlay = 4; }
        else if (other.gameObject.tag == "BossTriger") { audioCountPlay = 5; }
        //else Doesnotchange(audioCountPlay);

        characterAudioController.SpawnAudioGameObject(audioCountPlay);
    }

}
