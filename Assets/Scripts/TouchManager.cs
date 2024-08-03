using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;

    private GameObject globe;

    public float speed = 10f;

    public bool allowMovement = true;

    void Start()
    {
        globe = GameObject.FindGameObjectWithTag("Globe");
        dragDistance = Screen.height * 15 / 100;
    }

    void Update()
    {
        if (Input.touchCount == 1 && allowMovement)
        {
            Touch touch = Input.GetTouch(0); // get the touch

            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;

                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        if ((lp.x > fp.x))
                        {
                            globe.transform.Rotate(Vector3.up, -speed);
                        }
                        else
                        {
                            globe.transform.Rotate(Vector3.up, speed);
                        }
                    }
                    //else
                    //{
                    //    if (lp.y > fp.y)
                    //    {
                    //        globe.transform.Rotate(Vector3.right, -speed);
                    //    }
                    //    else
                    //    {
                    //        globe.transform.Rotate(Vector3.right, speed);
                    //    }
                    //}
                }
               
            }
            else if (touch.phase == TouchPhase.Ended)
            {
            }
        }
    }
}
