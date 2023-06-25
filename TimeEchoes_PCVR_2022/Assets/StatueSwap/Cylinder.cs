using System.Collections;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public Material selectedMaterial;
    private Material originalMaterial;
    private bool isSelected = false;
    public Base correctBase;
    public AudioClip swapSFX;
    private AudioSource audioSource;
    private bool inputEnabled = true;

    public float duration = 1.0f; // Animation time in seconds


    private void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        //CheckCorrectBase();
    }

    private void Update()
    {
        if (!inputEnabled)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Create a ray from the mouse click position or touch position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // If this cylinder was hit by the raycast
                if (hit.transform == this.transform)
                {
                    HandleInteraction();
                }
            }
        }
    }

    private void HandleInteraction()
    {
        Cylinder selectedCylinder = null;
        Cylinder[] cylinders = FindObjectsOfType<Cylinder>();

        foreach (Cylinder cylinder in cylinders)
        {
            if (cylinder != this && cylinder.isSelected)
            {
                selectedCylinder = cylinder;
                break;
            }
        }

        if (selectedCylinder != null)
        {
            StartCoroutine(AnimateSwap(selectedCylinder));
        }
        else
        {
            SelectCylinder();
        }
    }

    public void SelectCylinder()
    {
        DeselectAllCylinders();
        GetComponent<Renderer>().material = selectedMaterial;
        isSelected = true;
    }

    private void DeselectAllCylinders()
    {
        Cylinder[] cylinders = FindObjectsOfType<Cylinder>();

        foreach (Cylinder cylinder in cylinders)
        {
            cylinder.GetComponent<Renderer>().material = cylinder.originalMaterial;
            cylinder.isSelected = false;
        }
    }

    private IEnumerator AnimateSwap(Cylinder otherCylinder)
    {
        inputEnabled = false;

        //float duration = 1.0f; // Animation time in seconds
        float elapsed = 0.0f;

        Vector3 startingPosThis = this.transform.position;
        Vector3 startingPosOther = otherCylinder.transform.position;

        audioSource.PlayOneShot(swapSFX);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            this.transform.position = Vector3.Lerp(startingPosThis, startingPosOther, t);
            otherCylinder.transform.position = Vector3.Lerp(startingPosOther, startingPosThis, t);

            yield return null;
        }

        this.transform.position = startingPosOther;
        otherCylinder.transform.position = startingPosThis;

        otherCylinder.CheckCorrectBase();
        this.CheckCorrectBase();

        yield return new WaitForSeconds(0.1f); // Small delay to avoid immediate re-selection

        inputEnabled = true;
        DeselectAllCylinders();
    }

    public void CheckCorrectBase()
    {
        if (correctBase != null)
        {
            Collider baseCollider = correctBase.GetComponent<Collider>();
            Collider cylinderCollider = this.GetComponent<Collider>();

            if (baseCollider.bounds.Intersects(cylinderCollider.bounds))
            {
                Debug.Log("Cylinder is on the correct base");
                correctBase.ChangeToCorrectMaterial();
            }
            else
            {
                Debug.Log("Cylinder is not on the correct base");
                correctBase.RevertToOriginalMaterial();
            }
        }
    }
}
