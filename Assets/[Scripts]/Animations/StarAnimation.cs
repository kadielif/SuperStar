using UnityEngine;
using DG.Tweening;

public class StarAnimation : MonoBehaviour
{
    public Transform armL;
    public Transform armR;

    public Transform legL;
    public Transform legR;

    public Transform head;

    public float animRange = 10f;
    public float animDuration = 1f;
    public float speed = 5f;

    private Quaternion armLRot;
    private Quaternion armRRot;
    private Quaternion legLRot;
    private Quaternion legRRot;
    private Quaternion headRot;

    private void Start()
    {
        armLRot = armL.localRotation;
        armRRot = armR.localRotation;
        legLRot = legL.localRotation;
        legRRot = legR.localRotation;
        headRot = head.localRotation;
    }

    private void Update() => Animate();

    private float currentRot;

    private void Animate()
    {
        currentRot = Mathf.PingPong(Time.time * speed*3f, animRange * 2f) - animRange;
        
        armL.localRotation = armLRot * Quaternion.Euler(currentRot,0,0); 
        armR.localRotation = armRRot * Quaternion.Euler(-currentRot,0,0);

        legL.localRotation = legLRot * Quaternion.Euler(-currentRot, 0, 0);
        legR.localRotation = legRRot * Quaternion.Euler(currentRot, 0, 0);

        head.localRotation = headRot * Quaternion.Euler(-currentRot * 0.5f, 0, currentRot * 0.5f);
    }
}
//private void Animate2()
//{
//    Quaternion armLRot = armL.localRotation;
//    armL.localRotation = armLRot * Quaternion.Euler(-animRange, 0, 0);
//    armL.DOLocalRotateQuaternion(armLRot * Quaternion.Euler(animRange, 0,0), animDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

//    Quaternion armRRot = armR.localRotation;
//    armR.localRotation = armRRot * Quaternion.Euler(animRange, 0, 0);
//    armR.DOLocalRotateQuaternion(armRRot * Quaternion.Euler(-animRange, 0, 0), animDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

//    Quaternion legLRot = legL.localRotation;
//    legL.localRotation = legLRot * Quaternion.Euler(animRange, 0, 0);
//    legL.DOLocalRotateQuaternion(legLRot * Quaternion.Euler(-animRange, 0, 0), animDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

//    Quaternion legRRot = legR.localRotation;
//    legR.localRotation = legRRot * Quaternion.Euler(-animRange, 0, 0);
//    legR.DOLocalRotateQuaternion(legRRot * Quaternion.Euler(animRange, 0, 0), animDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

//    Quaternion headRot = head.localRotation;
//    head.localRotation = headRot * Quaternion.Euler(0, -animRange * 0.5f, animRange * 0.5f);
//    head.DOLocalRotateQuaternion(headRot * Quaternion.Euler(0, animRange * 0.5f, -animRange * 0.5f), animDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
//}