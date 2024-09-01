//Callandra Ruiter GDD410
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script tracks player clicks on a 2D object (preferrably background) and when spacebar is pressed moves a 2D gameobject/sprite to the clicked positions
//the script should be put on the 2D object that the player will click on

public class ClickToFollowSimple : MonoBehaviour
{
    //the 2D gameobject/sprite that will be moved
    [SerializeField] GameObject movable;

    //is the sprite currently moving?
    private bool moving;

    //next marker that the sprite will move towards
    private Vector2 toMarker;

    //speed at which the gameobject will move
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            //log current x and y positions of gameobject
            float movx = movable.transform.position.x;
            float movy = movable.transform.position.y;
            //check if at mouse click
            if ((-.1 <= toMarker.x - movx && toMarker.x - movx <= .1) && (-.1 <= toMarker.y - movy && toMarker.y - movy <= .1))
            {
                moving = false;
            }
            else //keeps moving
            {
                Vector3 mov = new Vector3(0, 0, 0);
                //check which way the gameobject should move, increment movent
                if (movx > toMarker.x)
                {
                    mov.x = -speed;
                }
                else if (movx < toMarker.x)
                {
                    mov.x = speed;
                }
                if (movy > toMarker.y)
                {
                    mov.y = -speed;
                }
                else if (movy < toMarker.y)
                {
                    mov.y = speed;
                }
                movable.transform.position = new Vector3(movable.transform.position.x + mov.x, movable.transform.position.y + mov.y, movable.transform.position.z);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //add position of mouse click to list of path markers
            Vector3 mouseclick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            toMarker = new Vector2(mouseclick.x, mouseclick.y);
            moving = true;
        }
    }
}
