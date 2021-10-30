using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignHighlighter : MonoBehaviour
{
    Transform headTransform;
    RaycastHit hit;
    int layerMask = 1 << 8;
    GameObject hitObject;
    bool lastCastWasHit = false;
    [SerializeField] GameObject cameraObject;
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
            hitObject.GetComponent<SignGlowController>().ActivateSignGlow();
            lastCastWasHit = true;
        }
        else
        {
            Debug.DrawRay(headTransform.position, headTransform.TransformDirection(Vector3.forward) * detectionRange, Color.white);
            if (lastCastWasHit) { hitObject.GetComponent<SignGlowController>().DeActivateSignGlow(); }
        }
    }
}
