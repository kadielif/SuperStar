using UnityEngine;
using Dreamteck.Splines;

public class PlayerController : MonoBehaviour
{
    public SplineComputer spline;


    public float speed = 5f;
    public float rotationFactor = 10f;
    [Range(-2.6f, 2.6f)] public float offsetX = 0f;

    [HideInInspector] public Transform cameraTarget;
    private Transform mesh;

    public float precision = 7.5f;
    public float leftRange;
    public float rightRange;
    private float distance = 0f;
    bool change = false;

  
   

    #region Singleton
    public static PlayerController instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        spline = GameObject.FindGameObjectWithTag("spline").GetComponent<SplineComputer>();
        cameraTarget = new GameObject("camera-target").transform;
        mesh = transform.GetChild(0);
        
    }

    private void Update()
    {
        SplineSample ss = spline.Evaluate(spline.Travel(0, distance));
        if (LevelManager.instance.LevelStart)
        {
            if (spline == null) return;

            distance += speed * Time.deltaTime * 2;
            transform.position = ss.position + (ss.right * offsetX);
            transform.rotation = ss.rotation;
            if (!change)
            {
                float targetPosX = offsetX + InputManager.instance.input.x * precision;
                offsetX = Mathf.Lerp(offsetX, targetPosX, Time.deltaTime * 5f);
                offsetX = Mathf.Clamp(offsetX, leftRange, rightRange);
                transform.position = ss.position + (ss.right * offsetX);
            }
            cameraTarget.position = ss.position;
            cameraTarget.rotation = ss.rotation;

            mesh.localRotation *= Quaternion.Euler(speed * rotationFactor * Time.deltaTime, 0f, 0f);
        }
        else{
            offsetX = 0;
        }
    
    }
}
