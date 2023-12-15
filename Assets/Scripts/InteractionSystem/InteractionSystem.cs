using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] GameObject interactionUI;
    [SerializeField] TextMeshProUGUI interactionUIText;
    [SerializeField] TextMeshProUGUI feedbackUIText;

    public void SetUIText(string text)
    {
        ToggleUIText(true);
        interactionUIText.text = text;
    }

    public void ToggleUIText(bool toggle)
    {
        interactionUI.SetActive(toggle);
    }

    public void SetFeedbackText(string text)
    {
        feedbackUIText.text = text;
        StartCoroutine(FeedbackText());
    }

    IEnumerator FeedbackText()
    {
        feedbackUIText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        feedbackUIText.gameObject.SetActive(false);
    }
}
