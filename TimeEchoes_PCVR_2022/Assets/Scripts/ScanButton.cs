using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ScanButton : MonoBehaviour
{
    public GameObject scanBeamSpawn;

    public void ScanPressed()
    {
        {
            scanBeamSpawn.SetActive(true);
            StartCoroutine(ScanLength());
        }
 
    }

    IEnumerator ScanLength()
    {
        yield return new WaitForSeconds(2);
        scanBeamSpawn.SetActive(false);
        
    }
    //public void ScanReleased()
   // {
    //    {
    //        scanBeamSpawn.SetActive(false);
    //    }
   // }
}
