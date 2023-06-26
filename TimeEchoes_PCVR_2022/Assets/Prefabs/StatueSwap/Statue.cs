using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public Base correctBase;

    private void OnCollisionEnter(Collision collision)
    {
        Base baseObject = collision.gameObject.GetComponent<Base>();

        if (baseObject != null && baseObject == correctBase)
        {
            correctBase.ChangeToCorrectMaterial();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Base baseObject = collision.gameObject.GetComponent<Base>();

        if (baseObject != null && baseObject == correctBase)
        {
            correctBase.RevertToOriginalMaterial();
        }
    }
}
