using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public Material correctMaterial;
    private Material originalMaterial;

    private void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void ChangeToCorrectMaterial()
    {
        GetComponent<Renderer>().material = correctMaterial;
    }

    public void RevertToOriginalMaterial()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }
}
