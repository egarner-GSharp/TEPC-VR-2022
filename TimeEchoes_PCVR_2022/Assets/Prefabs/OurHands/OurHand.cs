using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OurHand : MonoBehaviour
{
    //public values to set in Unity, private used only in script
    public GameObject ourHandPrefab;
    public InputDeviceCharacteristics ourControllerCharacteristics;
    public GameObject scanBeamSpawn;
    

    private InputDevice ourDevice;
    private Animator ourHandAnimator;


    // Start is called before the first frame update
    void Start()
    {
        InitializeOurHand();

    }


    void InitializeOurHand()
    {
        //check for our controller characteristics
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ourControllerCharacteristics, devices);

        //if Device identified, Instantiate a Hand
        if (devices.Count > 0)
        {
            ourDevice = devices[0];

            GameObject newHand = Instantiate(ourHandPrefab, transform);
            ourHandAnimator = newHand.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Change animate position or re-initialize
        if (ourDevice.isValid)
        {
            UpdateOurHand();
        }
        else
        {
            InitializeOurHand();
        }
    }

    void UpdateOurHand()
    {
        if (ourDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            ourHandAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {

            ourHandAnimator.SetFloat("Trigger", 0);

        }

        if (ourDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            ourHandAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            ourHandAnimator.SetFloat("Grip", 0);
        }

        if (triggerValue > 0.01f)
        {
            scanBeamSpawn.SetActive(true);
        }
        else
        {
            scanBeamSpawn.SetActive(false);
        }
    }
}
