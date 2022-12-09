using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class SwitchColor : MonoBehaviour
{
    public bool updateColorNSize;
    public Material materialGreen;
    public Material materialRed;

    public Color greenOpaque;
    public Color greenTranparant;
    private Color setGreenColor;

    public Color redOpaque;
    public Color redTranparant;
    private Color setRedColor;


    private GameObject[] greenTagArray;
    private GameObject[] redTagArray;

    private bool greenCollisionActive = true;

    void Start()
    {
        // Store all objects taged with in arrays:
        greenTagArray = GameObject.FindGameObjectsWithTag("greenTag");
        redTagArray = GameObject.FindGameObjectsWithTag("redTag");

        // Set the correct material based on the tags: 
        foreach (GameObject objGreen in greenTagArray)
        {
            objGreen.GetComponent<MeshRenderer>().material = materialGreen;
        }
        foreach (GameObject objRed in redTagArray)
        {
            objRed.GetComponent<MeshRenderer>().material = materialRed;
        }



    }


   

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Pressed Space");
            // Switch which color is active:
            greenCollisionActive = !greenCollisionActive;

            if (greenCollisionActive == true)
            {
                setGreenColor = greenOpaque;
                setRedColor = redTranparant;
            }
            if (greenCollisionActive == false)
            {
                setGreenColor = greenTranparant;
                setRedColor = redOpaque;
            }
            
            foreach (GameObject objX in greenTagArray)
            {
                objX.GetComponent<MeshRenderer>().material.color = setGreenColor;
                Debug.Log("loop");
            }
            foreach (GameObject objX in redTagArray)
            {
                objX.GetComponent<MeshRenderer>().material.color = setRedColor;
                Debug.Log("loop");
            }
            
        }
    }

    void OnValidate()
    {
        Debug.Log("Controller - Inspector updated");

        // Store all objects taged with in arrays:
        greenTagArray = GameObject.FindGameObjectsWithTag("greenTag");
        redTagArray = GameObject.FindGameObjectsWithTag("redTag");

        // Set the correct material based on the tag:
        foreach (GameObject objGreen in greenTagArray)
        {
            objGreen.GetComponent<MeshRenderer>().material = materialGreen;
        }
        foreach (GameObject objRed in redTagArray)
        {
            objRed.GetComponent<MeshRenderer>().material = materialRed;
        }

    }
}
