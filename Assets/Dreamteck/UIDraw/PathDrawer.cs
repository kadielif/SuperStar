using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;

public class PathDrawer : MonoBehaviour
{
    public float AIHeightFactor=500;
    public float minLenghtsqr,width,xTreshold;
    public Image lineImage;
    public List<Vector3> positions;

    Vector2 lastPos;
    RectTransform rectTransform;

    bool began = false;

    public void Start()
    {
        rectTransform = transform.GetComponent<RectTransform>();
    }
    public void Update()
    {
        if (Application.isEditor)
            MouseInput();
        else
            TouchInput();
    }

    void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (rectTransform.rect.Contains(touch.position -(Vector2) rectTransform.position))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    began = true;
                    positions.Clear();
                    clearImages();

                    lastPos =touch.position;
                    positions.Add(lastPos);

                }
                else if ((touch.position- lastPos).sqrMagnitude > minLenghtsqr && touch.position.x > lastPos.x+ xTreshold)
                {
                    positions.Add(touch.position);
                    Connectimage(Instantiate(lineImage.gameObject, transform).GetComponent<Image>(), lastPos, Input.mousePosition,width);
                    lastPos = touch.position;
                }
            }
        }
        else if (began)
        {
            began = false;
        }
    }
    void MouseInput()
    {
        if (rectTransform.rect.Contains(Input.mousePosition-rectTransform.position))
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    positions.Clear();
                    clearImages();
                     
                    lastPos = Input.mousePosition;
                    positions.Add(lastPos);
                }
                else if (Input.GetMouseButton(0))
                {
                    if (((Vector2)Input.mousePosition - lastPos).sqrMagnitude > minLenghtsqr && Input.mousePosition.x > lastPos.x+ xTreshold)
                    {
                        positions.Add(Input.mousePosition);
                        Connectimage(Instantiate(lineImage.gameObject, transform).GetComponent<Image>(), lastPos, Input.mousePosition, width);
                        lastPos = Input.mousePosition;

                    }
                }
            }
        }
    }
    void clearImages()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public Vector3[] MakeRandomPath()
    {
        positions.Clear();
        clearImages();

        positions.Add(Vector3.zero);

        int length = Random.Range(10, 15);
        float minRatio = Random.Range(0.4f, 0.6f);
        float minHeight = Random.Range(-1f, 0f)*AIHeightFactor/2f;
        float endHeight = minHeight + Random.Range(0f, 1f)*AIHeightFactor;

        for (int i = 1; i < length; i++)
        {
            float x = i * 50f;
            float y;
            if ((float)i / length < minRatio)
                y = Mathf.Lerp(0f, minHeight,Mathf.Pow( (((float)i / length) / minRatio),2));
            else
                y = Mathf.Lerp( minHeight, endHeight,Mathf.Pow( ((float)i/length-minRatio)/(1f-minRatio) ,2));

            positions.Add(new Vector2(x, y));
        }

        return (positions.ToArray());
    }

    static void Connectimage(Image Line, Vector2 PosA, Vector2 PosB,float width)
    {
        Vector2 position = (PosA + PosB) / 2f;
        Line.rectTransform.position = position;

        Vector2 Direction = PosB - PosA;
        Line.rectTransform.sizeDelta = new Vector2(Direction.magnitude+10, width);

        Line.rectTransform.localRotation = Quaternion.FromToRotation(Vector3.right, Direction);// Quaternion.Euler(0, 0, angle);
    }
}
