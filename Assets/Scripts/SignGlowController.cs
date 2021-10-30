using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignGlowController : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField] GameObject signGlow;

    private void Start()
    {
        meshRenderer = signGlow.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    public void DeActivateSignGlow()
    {
        meshRenderer.enabled = false;
    }
    public void ActivateSignGlow()
    {
        meshRenderer.enabled = true;
    }
}