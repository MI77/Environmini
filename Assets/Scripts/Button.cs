using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

    RectTransform rectangle;
    Image image;

    public UnityEvent eventToTrigger;

    
    // Start is called before the first frame update
    void Start()
    {
        rectangle = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the mouse is within this button's rectangle
        if (RectTransformUtility.RectangleContainsScreenPoint(rectangle, Input.mousePosition))
        {
            //mouseover color
            image.color = Color.grey;

            // clicking
            if (Input.GetButtonDown("Fire1"))
            {
                eventToTrigger.Invoke();
            }
        }
        else
        {
            image.color = Color.black;
        }
    }
}
