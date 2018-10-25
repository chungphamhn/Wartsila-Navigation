using UnityEngine;
using VRTK;

public class ValveSnap : MonoBehaviour {

    private VRTK_SnapDropZone dropZone;
    [SerializeField] private GameObject rotatableValve;
    
    void Awake ()
    {
        dropZone = GetComponent<VRTK_SnapDropZone>();
        dropZone.ObjectSnappedToDropZone += EnableRotatableValve;
    }

    // disable snapped object and drop zone, enable rotatable valve
    private void EnableRotatableValve(object sender, SnapDropZoneEventArgs e)
    {
	GameObject pickableValve = dropZone.GetCurrentSnappedObject();
	pickableValve.GetComponent<Renderer>().enabled = false;
	pickableValve.GetComponent<Collider>().enabled = false;
	Component[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
            renderer.enabled = false;
	this.GetComponent<Collider>().enabled = false;
        //dropZone.GetCurrentSnappedObject().SetActive(false);
        //this.gameObject.SetActive(false);
        rotatableValve.SetActive(true);
    }
}
