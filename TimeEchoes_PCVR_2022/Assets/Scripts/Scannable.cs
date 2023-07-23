using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Scannable : MonoBehaviour
{
    private bool isScanned;
    Renderer ren;


    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        ren.material.color = Color.red;

        isScanned = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScanBeam"))
        {
            Scan();
        }
    }

    void Scan()
    {
        ren.material.color = Color.green;

        isScanned = true;
    }
}
