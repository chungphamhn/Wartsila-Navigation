namespace VRTK.Examples
{
    using UnityEngine;

    public class SnapDropZoneGroup_Switcher : MonoBehaviour
    {
        private GameObject cubeZone;
        private GameObject sphereZone;
        private GameObject intakeZone;
        private GameObject valveZone;

        private void Start()
        {
            cubeZone = transform.Find("Cube_SnapDropZone").gameObject;
            sphereZone = transform.Find("Sphere_SnapDropZone").gameObject;
            intakeZone = transform.Find("intake_snap").gameObject;
            valveZone = transform.Find("valve_cover_snap").gameObject;

            cubeZone.GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(DoCubeZoneSnapped);
            cubeZone.GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += new SnapDropZoneEventHandler(DoCubeZoneSnapped);
            cubeZone.GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += new SnapDropZoneEventHandler(DoCubeZoneUnsnapped);
            cubeZone.GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(DoCubeZoneUnsnapped);

            sphereZone.GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(DoSphereZoneSnapped);
            sphereZone.GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += new SnapDropZoneEventHandler(DoSphereZoneSnapped);
            sphereZone.GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += new SnapDropZoneEventHandler(DoSphereZoneUnsnapped);
            sphereZone.GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(DoSphereZoneUnsnapped);

            intakeZone.GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(DoIntakeZoneSnapped);
            intakeZone.GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += new SnapDropZoneEventHandler(DoIntakeZoneSnapped);
            intakeZone.GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += new SnapDropZoneEventHandler(DoIntakeZoneUnsnapped);
            intakeZone.GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(DoIntakeZoneUnsnapped);

            valveZone.GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(DoValveZoneSnapped);
            valveZone.GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += new SnapDropZoneEventHandler(DoValveZoneSnapped);
            valveZone.GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += new SnapDropZoneEventHandler(DoValveZoneUnsnapped);
            valveZone.GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += new SnapDropZoneEventHandler(DoValveZoneUnsnapped);
        }

        private void DoCubeZoneSnapped(object sender, SnapDropZoneEventArgs e)
        {
            sphereZone.SetActive(false);
        }

        private void DoCubeZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
        {
            sphereZone.SetActive(true);
        }

        private void DoSphereZoneSnapped(object sender, SnapDropZoneEventArgs e)
        {
            cubeZone.SetActive(false);
        }

        private void DoSphereZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
        {
            cubeZone.SetActive(true);
        }

        private void DoIntakeZoneSnapped(object sender, SnapDropZoneEventArgs e)
        {
            cubeZone.SetActive(false);
        }

        private void DoIntakeZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
        {
            cubeZone.SetActive(true);
        }

        private void DoValveZoneSnapped(object sender, SnapDropZoneEventArgs e)
        {
            cubeZone.SetActive(false);
        }

        private void DoValveZoneUnsnapped(object sender, SnapDropZoneEventArgs e)
        {
            cubeZone.SetActive(true);
        }
    }
}