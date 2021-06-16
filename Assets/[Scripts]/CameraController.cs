using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 rotOffset;

    #region Singleton
    public static CameraController instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    private Transform target { get {
            if (PlayerController.instance== null) return null;
            else return PlayerController.instance.cameraTarget;
     } }

    private void Update()
    {
        if (target == null) return;

        Vector3 pos = target.position + (target.forward * -offset.z) + (target.up * offset.y);
        Vector3 lookDir = target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDir) * Quaternion.Euler(0, 0, target.eulerAngles.z);

        transform.position = Vector3.Slerp(transform.position, pos, Time.deltaTime * 5f);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5f);
    }
}