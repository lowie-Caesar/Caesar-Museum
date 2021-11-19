using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignController : MonoBehaviour
{
    MeshRenderer meshRenderer;
    PlayerMovement movementScript;

    [SerializeField] GameObject signGlow, canvas;
    [SerializeField] TextMeshProUGUI titleTextField, infoTextField;
    [SerializeField] TextMeshPro worldTitleTextField;
    [SerializeField] string signTitle;
    [SerializeField] [TextArea(10, 14)] string signText;

    private void Start()
    {
        movementScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        meshRenderer = signGlow.GetComponent<MeshRenderer>();

        movementScript.isMovementDisabled = true;

        canvas.SetActive(true);
        titleTextField.text = "Het Julius Caesar Musuem";
        infoTextField.text = 
            "Welkom in het Julius Caesar Musuem. " +
            "Je zal hier zo veel interresante informatie over Ceasar vinden, dat je niet meer weet hoe je zo lang zonder die kennis geleefd hebt. " +
            "Hoe moet je dit museum bezoeken? Het gaat als volgt: Je gebruikt de ZQSD of pijltjes toetsen om rond te wandelen en de muis om rond te kijken. " +
            "Als je dicht genoeg gaat staan bij een stuk, en er naar het bordje kijkt, zal hierrond een gloed onstaan. " +
            "Als je deze gloed ziet, dan kan je met je muis klikken om over dit onderwerp meer informatie te krijgen. " +
            "Je kan daarna op \"Escape\" klikken om dit scherm terug te sluiten, dit is ook hoe je dit scherm sluit. " +
            "Tenslotte kan je het museum afsluiten, door tegelijk op \"CTRL\" en \"Q\" te tikken. " +
            "Geniet van Bezoek!";
        worldTitleTextField.text = signTitle;
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
        movementScript.isMovementDisabled = true;
        canvas.SetActive(true);
        Debug.Log("Title: " + signTitle + " Info: " + signText);
        titleTextField.text = signTitle;
        infoTextField.text = signText;
    }
    public void HideSignText()
    {
        movementScript.isMovementDisabled = false;
        canvas.SetActive(false);
    }
}