using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public PressurePlate plate1;
    public PressurePlate plate2;
    public GameObject door; // drag your door here in Inspector
    private bool plate1Activated = false;
    private bool plate2Activated = false;
    private bool doorOpened = false;
    private AudioSource doorAudio;
    
    void Start()
    {
        doorAudio = GetComponent<AudioSource>();
    }
    
   

    void Update()
    {
        if (!plate1Activated && plate1.isPressed)
        {
            plate1Activated = true;
            Debug.Log("Plate 1 activated");
        }

        if (!plate2Activated && plate2.isPressed)
        {
            plate2Activated = true;
            Debug.Log("Plate 2 activated");
        }
        //if both plates are activated and door is not opened, open the door
        if (plate1Activated && plate2Activated && !doorOpened)
        {
            doorOpened = true;

            // Play the sound *before* disabling
            if (doorAudio != null)
                doorAudio.Play();

            // Wait and then disable
            StartCoroutine(DisableAfterSound());
          
            Debug.Log("Door opened");
        }
    }
    // Coroutine to disable the door after the sound has played
    IEnumerator DisableAfterSound()
    {
        yield return new WaitForSeconds(doorAudio.clip.length);
        door.SetActive(false);
    }
}
