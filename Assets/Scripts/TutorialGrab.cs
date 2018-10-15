using UnityEngine;
using VRTK;

public class TutorialGrab : MonoBehaviour {
    private VRTK_InteractableObject interactableObject;
    private VRTK_ControllerReference controllerReference;
    [SerializeField] private GameObject door;

    private void OnEnable()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectTouched += OnTutorialObjectTouched;
        interactableObject.InteractableObjectGrabbed += OnTutorialObjectGrabbed;
    }

    private void OnTutorialObjectTouched (object sender, InteractableObjectEventArgs e)
    {
    }

    // allow teleportation to engine room
    private void OnTutorialObjectGrabbed (object sender, InteractableObjectEventArgs e)
    {
        door.SetActive(false);
    }
}
