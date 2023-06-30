using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] otherUI;
    [SerializeField] private string[] messages;

    [SerializeField] private Text messageField;

    private int counter = 0;

    private void Start()
    {
        if (PlayerPrefs.GetInt(gameObject.name + "Closed", 0) != 1)
        {
            foreach (var obj in otherUI)
            {
                obj.SetActive(false);
            }

            StartCoroutine(TextCoroutine(messages[counter]));
        }
        else
        {
            GlobalEventManager.SendDialogueClosed();
            gameObject.SetActive(false);
        }
    }

    IEnumerator TextCoroutine(string text)
    {
        messageField.text = "";

        foreach (char sym in text)
        {
            messageField.text += sym;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void SetNextMsg()
    {

        StopAllCoroutines();

        counter += 1;

        if (counter > messages.Length - 1)
        {
            foreach (var obj in otherUI)
            {
                obj.SetActive(true);
            }
            GlobalEventManager.SendDialogueClosed();

            gameObject.SetActive(false);

            PlayerPrefs.SetInt(gameObject.name + "Closed", 1);
        }
        else
        {
            GlobalEventManager.SendUIClcked();
            StartCoroutine(TextCoroutine(messages[counter]));
        }
    }
}
