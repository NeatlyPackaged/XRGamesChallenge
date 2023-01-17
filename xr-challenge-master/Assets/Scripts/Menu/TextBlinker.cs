using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBlinker : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    public TextMeshProUGUI flashingText;
    string textToBlink;
    public float BlinkTime;

    // On awake, the text will connect to the string to keep it stored
    void Awake()
    {
        textToBlink = flashingText.text;
    }

    // At any moment, the event to blink the text is called
    void OnEnable()
    {
        StartCoroutine(BlinkText());
    }

    // The Text will display as empty and back to the original text it displayed as
    IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = textToBlink;
            yield return new WaitForSeconds(BlinkTime);
            flashingText.text = string.Empty;
            yield return new WaitForSeconds(BlinkTime);
        }
    }
}
