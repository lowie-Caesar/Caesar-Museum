using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignController : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField] GameObject signGlow, canvas;
    [SerializeField] TextMeshProUGUI titleTextField, infoTextField;
    [SerializeField] string signTitle;
    [SerializeField] [TextArea(10, 14)] string signText;

    private void Start()
    {
        meshRenderer = signGlow.GetComponent<MeshRenderer>();
        canvas.SetActive(false);
        DeActivateSignGlow();
        //Debug.Log("Title: " + signTitle + " Info: " + signText);
    }
    private void Update()
    {

    }
    public void DeActivateSignGlow()
    {
        meshRenderer.enabled = false;
    }
    public void ActivateSignGlow()
    {
        meshRenderer.enabled = true;
    }

    public void ShowSignText()
    {
        canvas.SetActive(true);
        Debug.Log("Title: " + signTitle + " Info: " + signText);
        titleTextField.text = signTitle;
        infoTextField.text = signText;
    }
    public void HideSignText()
    {
        canvas.SetActive(false);
    }
}