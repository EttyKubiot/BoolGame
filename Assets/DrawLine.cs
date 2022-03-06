using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DrawLine : MonoBehaviour
{
    private LineRenderer Line;



    public Transform target;
    public Transform target2;

    private bool isTrigger;
    private bool inTrigger;
    private int dot;

    private Vector2 mousePos;
    private Vector2 startMousePos;
    private float distance;

    public Vector2 firstPressPos;
    public Vector2 secondPressPos;
    public Vector2 currentSwipe;

    void Start()
    {
        Line = GetComponent<LineRenderer>();
        Line.positionCount = 2;
        isTrigger = false;
        inTrigger = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("start"))
        {

            Debug.Log("start");
            isTrigger = true;
            //inTrigger = true;

        }
    }
    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    if (other.gameObject.CompareTag("start"))
    //    {

    //        Debug.Log("rrrrrrrrrrrrrrrrrr");
    //        isTrigger = true;
    //        inTrigger = false;
    //    }



    //}


    private void Update()
    {
      
            transform.position = mousePos;

            if (Input.GetMouseButtonDown(0))
            {
                startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }


            if (Input.GetMouseButton(0))
            {

                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                Line.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
                distance = (mousePos - startMousePos).magnitude;
                inTrigger = true;
            }

            Swipe();

       


    }

    public void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("GetMouseButtonUp");
            inTrigger = false;
        }
    }














    public void Swipe()
    {
        if (inTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //save began touch 2d point
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            if (Input.GetMouseButtonUp(0))
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                //create vector from the two points
                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {

                    Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                    Line.SetPosition(1, new Vector3(startMousePos.x, mousePos.y, 0f));
                    transform.position = new Vector3(startMousePos.x, mousePos.y, 0f);

                    Debug.Log("up swipe");
                }
                //swipe down
                else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                    Line.SetPosition(1, new Vector3(startMousePos.x, mousePos.y, 0f));
                    Debug.Log("down swipe");
                }
                //swipe left
                else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                    Line.SetPosition(1, new Vector3(mousePos.x, startMousePos.y, 0f));
                    Debug.Log("left swipe");
                }
                //swipe right
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                    Line.SetPosition(1, new Vector3(mousePos.x, startMousePos.y, 0f));
                    Debug.Log("right swipe");
                }

                else if (currentSwipe.y > 0 && currentSwipe.x < 0)
                {
                    Debug.Log("1");
                    Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                    Line.SetPosition(1, new Vector3(mousePos.x - 2f, mousePos.y - 2f, 0f));
                }
                // Swipe up right
                else if (currentSwipe.y > 0 && currentSwipe.x > 0)
                {
                    Debug.Log("2");
                    Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                    Line.SetPosition(1, new Vector3(mousePos.x + 2f, mousePos.y + 2f, 0f));
                }
                // Swipe down left
                else if (currentSwipe.y < 0 && currentSwipe.x < 0)
                {
                    Debug.Log("3");
                    Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                    Line.SetPosition(1, new Vector3(mousePos.x - 2f, mousePos.y - 2f, 0f));

                    // Swipe down right
                }
                else if (currentSwipe.y < 0 && currentSwipe.x > 0)
                {
                    Debug.Log("4");
                    Line.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
                    Line.SetPosition(1, new Vector3(mousePos.x - 2f, mousePos.y - 2f, 0f));
                }
            }
        }
       
    }

}
