using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FollowLigand : MonoBehaviour
{
    public Vector3 offset = new Vector3(0.0F, 0.0F, 0.0F);
    public GameObject ligand;

    public float doubleClickTime = 0.5F;
    private float ButtonCooler; // Half a second before reset 
    private int ButtonCount = 0;
    public Camera bird;
    public Camera pov;

    public void Start() {
        ButtonCooler = doubleClickTime;
        bird.enabled = true;
        pov.enabled = false;
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Main Scene")
        transform.position = ligand.transform.position + offset;

        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
            {
                if (pov.enabled) {
                    pov.enabled = false;
                    bird.enabled = true;
                }
                else
                {
                    pov.enabled = true;
                    bird.enabled = false;
                }
                ButtonCount = 0;
            }
            else
            {
                ButtonCooler = doubleClickTime;
                ButtonCount += 1;
            }
        }

        //Debug.Log(ButtonCooler);
        if (ButtonCooler > 0)
        {

            ButtonCooler -= 1 * Time.deltaTime;

        }
        else
        {
            ButtonCount = 0;
        }
       // Debug.Log(ButtonCooler);
    }

    void setFollow(GameObject lig)
    {
        ligand = lig;
    }


}