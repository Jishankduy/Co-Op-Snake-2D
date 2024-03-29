﻿using System.Collections.Generic;
using UnityEngine;
using TMPro;



[RequireComponent(typeof(BoxCollider2D))]
public class Snake2 : MonoBehaviour
{
    public Snake snake;
    private int count;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public Vector2 direction = Vector2.right;  //Find direction
    public int initialSize = 4;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    GameObject shield;


    private void Start()
    {
        shield = transform.Find("ShieldSprite").gameObject;
        DeactivateShield();
        ResetState();
    }

    private void Update()
    {
        // Only allow turning up or down while moving in the x-axis
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                direction = Vector2.up;
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                direction = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                direction = Vector2.right;
            } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                direction = Vector2.left;
            }
        }
    }

    private void FixedUpdate()
    {
        // Set each segment's position to be the same as the one it follows. We
        // must do this in reverse order so the position is set to the previous
        // position, otherwise they will all be stacked on top of each other.
        for (int i = segments.Count - 1; i > 0; i--) {
            segments[i].position = segments[i - 1].position;
        }

        // Move the snake in the direction it is facing
        // Round the values to ensure it aligns to the grid
        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void LossGrow()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(transform);
    }

    public void ResetState()
    {
        direction = Vector2.right;
        transform.position = Vector3.zero;

        // Start at 1 to skip destroying the head
        for (int i = 1; i < segments.Count; i++) {
            Destroy(segments[i].gameObject);
        }

        // Clear the list but add back this as the head
        segments.Clear();
        segments.Add(transform);

        // -1 since the head is already in the list
        for (int i = 0; i < initialSize - 1; i++) {
            Grow();
        }
    }
    bool HasShield()
    {
        return shield.activeSelf;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food")) {
            Grow();
            count = count + 1;
            SetCountText();

        }
        else if (other.gameObject.CompareTag("Obstacle")) {
            ResetState();
        }

        if (other.gameObject.CompareTag("PoisonFood"))
        {
            LossGrow();
            if (HasShield())
            {
                DeactivateShield();
                Debug.Log("appun hai");
            }
            else
            {
                if (count - 1 > 0)
                {
                    count = count - 1;
                }
                else
                    count = 0;
                SetCountText();
            }
        }

        if (other.gameObject.CompareTag("ExtraFood"))
        {
            Grow();
            count = count + 3;
            SetCountText();

        }
        if (other.gameObject.CompareTag("Speed"))
        {
            SpeedUp();
        }
        if (other.gameObject.CompareTag("Shield"))
        {
            ActivateShield();
        }
    }

    void SetCountText()
    {
        countText.text = " " + count.ToString();

        if (count >= 12)
        {
            //Set the text value of your 'winText'
            winTextObject.SetActive(true);
            //this.enabled=false;
            StopControl();
            snake.StopControl();
            //this.GetComponent<Snake>().enabled=false;
        }
    }

    public void StopControl(){
        this.enabled=false;
    }

    public void StartControl() {
        this.enabled=true;
        
    }

    void SpeedUp()
    {
        direction *= 2.0f;
        Debug.Log("SpeedUp");
    }

    void ActivateShield()
    {
        shield.SetActive(true);
        Invoke(nameof(DeactivateShield), 7.0f);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
    }

}
