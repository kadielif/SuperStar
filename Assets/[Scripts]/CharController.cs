using UnityEngine;
public class CharController : MonoBehaviour
{
    #region Singleton
    public static CharController instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    SkinnedMeshRenderer meshChar;

    public Material yellow,purple,blue;
    string currentColor;

    void Start()
    {
        meshChar = GetComponent<SkinnedMeshRenderer>();
    }
    private void Update()
    {
        currentColor = meshChar.material.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ender"))
        {
            LevelManager.instance.LevelStart = false;
            LevelManager.instance.Success();
        }
        if (other.CompareTag("point"))
        {
            DataManager.instance.money += 10;
        }
        if (other.CompareTag("color-yellow"))
        {
            ChangeColor(yellow);
        }
        else if (other.CompareTag("color-purple"))
        {
            ChangeColor(purple);
        }
        else if (other.CompareTag("color-blue"))
        {
            ChangeColor(blue); 
        }

        if (currentColor == "sphereYellow (Instance)")
        {
            if (other.CompareTag("obstracle-blue") || other.CompareTag("obstracle-purple"))
            {
                if (PlayerController.instance.transform.localScale.x >= 1)
                {
                    PlayerController.instance.transform.localScale -= new Vector3(0.04f, 0.04f, 0.04f);
                }
                else
                {
                    LevelManager.instance.LevelStart = false;
                    LevelManager.instance.Fail();
                }
            }
            else if(other.CompareTag("obstracle-yellow")) {
                if (PlayerController.instance.transform.localScale.x<2)
                {
                    PlayerController.instance.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                }
                DataManager.instance.money += 2;
                Destroy(other.gameObject);
            }
        }
        else if (currentColor == "spherePurple (Instance)")
        {
            if (other.CompareTag("obstracle-blue") || other.CompareTag("obstracle-yellow"))
            {
                if (PlayerController.instance.transform.localScale.x >= 1)
                {
                    PlayerController.instance.transform.localScale -= new Vector3(0.04f, 0.04f, 0.04f);
                }
                else
                {
                    LevelManager.instance.LevelStart = false;
                    LevelManager.instance.Fail();
                }
            }
            else if (other.CompareTag("obstracle-purple"))
            {
                if (PlayerController.instance.transform.localScale.x < 2)
                {
                    PlayerController.instance.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                }
                DataManager.instance.money += 2;
                Destroy(other.gameObject);
            }
        }
        else if (currentColor == "sphereBlue (Instance)")
        {
            if (other.CompareTag("obstracle-purple") || other.CompareTag("obstracle-yellow"))
            {
                if (PlayerController.instance.transform.localScale.x >= 1)
                {
                    PlayerController.instance.transform.localScale -= new Vector3(0.04f, 0.04f, 0.04f);
                }
                else
                {
                    LevelManager.instance.LevelStart = false;
                    LevelManager.instance.Fail();
                }
            }
            else if (other.CompareTag("obstracle-blue"))
            {
                if (PlayerController.instance.transform.localScale.x < 2)
                {
                    PlayerController.instance.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                }
                DataManager.instance.money += 2;
                Destroy(other.gameObject);
            }
           
        }
    }

    void ChangeColor(Material color)
    {
        meshChar.material = color;    
    }
}
