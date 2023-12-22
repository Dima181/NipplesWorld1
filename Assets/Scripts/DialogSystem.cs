using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public TMP_Text dialogText;
    public float letterDelay = 0.05f;

    public List<string> dialogMessages;
    public int currentMessageIndex = 0;
    public Coroutine currentCoroutine;

    [SerializeField] GameObject imageText;
    [SerializeField] GameObject dialogTxt;
    [SerializeField] GameObject buttonE;

    public bool endDialog = false;

    private void Start()
    {
        // ��������� ��������� ������� � ������
        //  dialogMessages.Add("������! ��� ���������� �������.");
        //  dialogMessages.Add("������� ����� ������ ���� ��� �����������.");
        //  dialogMessages.Add("���������� ������� ���������.");

        // ���������� ������ ���������
       ///////// ShowCurrentMessage();
    }

    private void Update()
    {
        // ��������� ������� ����� ������ ����
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.KeypadEnter)) && endDialog == false)
        {
            if (currentCoroutine != null)
            {
                // ���� ����� ��� ��� ���������� �� ������, ���������� ��� ���������
                StopCoroutine(currentCoroutine);
                currentCoroutine = null;
                dialogText.text = dialogMessages[currentMessageIndex];
            }
            else if (currentMessageIndex < dialogMessages.Count - 1)
            {
                // ���� ���� ��� ���������, ��������� ���������
                currentMessageIndex++;
                ShowCurrentMessage();
            }
            else
            {
                // ���� ��������� �����������, ��������� ������
                EndDialog();
            }
        }
    }

    public void ShowCurrentMessage()
    {
        imageText.SetActive(true);
        dialogTxt.SetActive(true);
        buttonE.SetActive(false);
        currentCoroutine = StartCoroutine(ShowText(dialogMessages[currentMessageIndex]));
    }

    private IEnumerator ShowText(string message)
    {
        dialogText.text = "";

        // ���������� ����� �� ������
        for (int i = 0; i < message.Length; i++)
        {
            dialogText.text += message[i];
            yield return new WaitForSeconds(letterDelay);
        }

        currentCoroutine = null;
    }

    public void EndDialog()
    {
        imageText.SetActive(false);
        dialogTxt.SetActive(false);
        currentMessageIndex = 0;
        endDialog = true;
    }
}
