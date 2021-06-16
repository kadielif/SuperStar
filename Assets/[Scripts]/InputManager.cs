using UnityEngine;
using UnityEngine.EventSystems;
public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    PointerEventData _eventData;
    Vector2 startedPos;
    Vector2 delta;
    public Vector2 input;

    #region Singleton
    public static InputManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void OnPointerDown(PointerEventData eventData)
    {
        _eventData = eventData;
        startedPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _eventData = null;
        input = Vector2.zero;
    }

    public float maxDistance = 100f;
    void Update()
    {
        if (_eventData == null) return;
        delta = _eventData.position - startedPos;
        startedPos = _eventData.position;
        input = new Vector2(Mathf.Clamp(delta.x*maxDistance, -0.75f, 0.75f), 0);
        //input = new Vector2(Mathf.Clamp(delta.x, -20f, 20f), );
      
    }
}
