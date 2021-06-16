using UnityEngine;
using DG.Tweening;
public class SuccessFinishAnimation : MonoBehaviour
{
    public Transform armL;
    public Transform armR;
    public Transform legL;
    public Transform legR;
    public Transform body;
    public SkinnedMeshRenderer mouth;

    public float animRange = 10f;
    public float animDuration = 1f;
    public float speed = 5f;
   


    private Quaternion armLRot;
    private Quaternion armRRot;
    private Quaternion legLRot;
    private Quaternion legRRot;
    private Quaternion bodyRot;

    private float currentRot;
    void Start()
    {
        bodyRot = body.localRotation;
        Animate();
    }
    private void Animate()
    {
        

        DOTween.To(() => mouth.GetBlendShapeWeight(1), x => mouth.SetBlendShapeWeight(1, 100), 0f, 2f).SetEase(Ease.Linear);


        body.rotation = Quaternion.Euler(0, 0, 0);
        body.DOLocalRotateQuaternion(bodyRot * Quaternion.Euler(0, 180f, 0), animDuration).SetEase(Ease.Linear);

        PlayerController.instance.cameraTarget.position = new Vector3(PlayerController.instance.cameraTarget.position.x, PlayerController.instance.cameraTarget.position.y + 2.5f, PlayerController.instance.cameraTarget.position.z);
        body.DOMoveX(PlayerController.instance.cameraTarget.position.x, 1f);
        body.DOMoveY(PlayerController.instance.cameraTarget.position.y, 1f);

        CameraController.instance.offset.z -= 5f;
        CameraController.instance.offset.y = 3f;

        //mouth.SetBlendShapeWeight(1, 100);
    }
}
