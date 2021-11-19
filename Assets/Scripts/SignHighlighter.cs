using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignHighlighter : MonoBehaviour
{
    Transform headTransform;
    RaycastHit hit;
    int layerMask = 1 << 8;
    GameObject hitObject;
    bool lastCastWasHit, signIsShown = true;
    [SerializeField] GameObject cameraObject;
    [SerializeField] GameObject canvas;
    [SerializeField] float detectionRange = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        headTransform = cameraObject.transform;
        if (Physics.Raycast(headTransform.position, headTransform.TransformDirection(Vector3.forward), out hit, detectionRange, layerMask))
        {
            Debug.DrawRay(headTransform.position, headTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            hitObject = hit.collider.gameObject;
            hitObject.GetComponent<SignController>().ActivateSignGlow();
            lastCastWasHit = true;
        }
        else
        {
            Debug.DrawRay(headTransform.position, headTransform.TransformDirection(Vector3.forward) * detectionRange, Color.white);
            if (lastCastWasHit) { hitObject.GetComponent<SignController>().DeActivateSignGlow(); }

            lastCastWasHit = false;

            if (signIsShown && Input.GetKeyDown(KeyCode.Escape))
            {
                canvas.SetActive(false);
                GetComponent<PlayerMovement>().isMovementDisabled = false;
                signIsShown = false;
            }
        }
        if (!lastCastWasHit) { return; }

        if (Input.GetAxis("Fire1") > 0.5 && !signIsShown)
        {
            hitObject.GetComponent<SignController>().ShowSignText();
            signIsShown = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && signIsShown)
        {
            hitObject.GetComponent<SignController>().HideSignText();
            signIsShown = false;
        }
    }
}
