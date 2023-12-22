using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBehavior : MonoBehaviour
{
    [SerializeField] private List<string> dialogNpsMessages;
    public DialogSystem dialogSystem;
    public void StartDialog()
    {
        dialogSystem.currentMessageIndex = 0;
        dialogSystem.endDialog = false;
        dialogSystem.dialogMessages = dialogNpsMessages;
    }

    public void DialogGo()
    {
        dialogSystem.ShowCurrentMessage();
    }
}