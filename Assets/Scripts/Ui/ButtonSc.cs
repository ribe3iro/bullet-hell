using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonSc : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string originalText;

    void OnEnable()
    {
        text.text = originalText;
    }
    private void Start()
    {
        text = GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        originalText = text.text;
    }
    public void OnPointerEnterEvent()
    {
        text.text = "- " + originalText + " -";
    }
    public void OnPointerExitEvent()
    {
        text.text = originalText;
    }
}