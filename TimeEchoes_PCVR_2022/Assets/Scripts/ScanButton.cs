using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ScanButton : MonoBehaviour
{
    public GameObject scanBeamSpawn;
    public AudioSource scanSound;


    public void ScanPressed()
    {
        {
            scanSound.Play();
            scanBeamSpawn.SetActive(true);
            StartCoroutine(ScanLength());
        }
    }

    IEnumerator ScanLength()
    {
        yield return new WaitForSeconds(3);
        scanBeamSpawn.SetActive(false);
        
    }
 
}
