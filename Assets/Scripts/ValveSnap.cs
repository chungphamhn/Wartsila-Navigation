using UnityEngine;
using VRTK;

public class ValveSnap : MonoBehaviour {

    private VRTK_SnapDropZone dropZone;
    [SerializeField] private GameObject rotatableValve;
    
    void Start ()
    {
        dropZone = GetComponent<VRTK_SnapDropZone>();
        dropZone.ObjectSnappedToDropZone += EnableRotatableValve;
    }

    // disable snapped object and drop zone, enable rotatable valve
    private void EnableRotatableValve(object sender, SnapDropZoneEventArgs e)
    {
        rotatableValve.SetActive(true);
	dropZone.GetCurrentSnappedObject().SetActive(false);
        this.gameObject.SetActive(false);
    }
}
