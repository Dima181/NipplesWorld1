using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogController : MonoBehaviour
{
    [SerializeField] GameObject buttonE;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nps")
        {
            buttonE.SetActive(true);

            other.gameObject.GetComponent<DialogBehavior>().StartDialog();

            if (Input.GetKeyDown(KeyCode.F))
            {
                other.gameObject.GetComponent<DialogBehavior>().DialogGo();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Nps")
        {
            buttonE?.SetActive(false);
        }
    }
}
