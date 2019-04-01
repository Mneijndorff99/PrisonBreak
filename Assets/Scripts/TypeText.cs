using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeText : MonoBehaviour
{
    public static TypeText instance;
    public float delay = 0.02f;
    private string currentText = "";
    public TextMeshProUGUI dialogBox;
    private void Awake()
    {
        instance = this;
    }

    public IEnumerator ShowDialogText(string fullText)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i +1 );
            dialogBox.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        StartCoroutine(EmptyTextBox());
    }

    IEnumerator EmptyTextBox()
    {
        yield return new WaitForSeconds(3);
        dialogBox.text = "";
    }
}
