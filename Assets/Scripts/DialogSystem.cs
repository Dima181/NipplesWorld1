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
        // Добавляем сообщения диалога в список
        //  dialogMessages.Add("Привет! Это диалоговая система.");
        //  dialogMessages.Add("Нажмите левую кнопку мыши для продолжения.");
        //  dialogMessages.Add("Диалоговая система завершена.");

        // Отображаем первое сообщение
       ///////// ShowCurrentMessage();
    }

    private void Update()
    {
        // Проверяем нажатие левой кнопки мыши
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.KeypadEnter)) && endDialog == false)
        {
            if (currentCoroutine != null)
            {
                // Если текст все еще появляется по буквам, отображаем его полностью
                StopCoroutine(currentCoroutine);
                currentCoroutine = null;
                dialogText.text = dialogMessages[currentMessageIndex];
            }
            else if (currentMessageIndex < dialogMessages.Count - 1)
            {
                // Если есть еще сообщения, открываем следующее
                currentMessageIndex++;
                ShowCurrentMessage();
            }
            else
            {
                // Если сообщения закончились, завершаем диалог
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

        // Отображаем текст по буквам
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
