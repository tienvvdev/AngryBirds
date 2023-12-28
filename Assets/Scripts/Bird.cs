using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public Rigidbody2D playerRb;
    public Rigidbody2D hookRb;
    public bool isDragging;
    private float maxDragDistance = 2.2f;

    public SpriteRenderer sr;
    public Sprite[] sprites;

    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform defaultPosition;

    public GameObject nextBirdPrefab;
    public bool lastBird;

    void Start()
    {

        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;


        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);


        SetStrips(defaultPosition.position);
    }


    private void SetStrips(Vector2 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);
    }

    void Update()
    {

        if (isDragging == true)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hookRb.position) > maxDragDistance)
            {
 
                playerRb.position = hookRb.position + (mousePos - hookRb.position).normalized * maxDragDistance;


                SetStrips(hookRb.position + (mousePos - hookRb.position).normalized * 2.6f);
            }
            else
            {

                playerRb.position = mousePos;

                SetStrips(mousePos + (mousePos - hookRb.position).normalized * 0.4f);
            }

        }
        else
        {
            SetStrips(defaultPosition.position);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        playerRb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        playerRb.isKinematic = false;
        StartCoroutine("StartFlying");
    }

    private IEnumerator StartFlying()
    {

        yield return new WaitForSeconds(0.2f);

        GetComponent<SpringJoint2D>().enabled = false;

        playerRb.constraints = RigidbodyConstraints2D.None;


        sr.sprite = sprites[1];

        this.enabled = false;


        yield return new WaitForSeconds(1.5f);


        if (nextBirdPrefab != null)
        {
            nextBirdPrefab.SetActive(true);
        }

        else
        {
            lastBird = true;
        }

        StartCoroutine("DeleteBirds");
    }

    private IEnumerator DeleteBirds()
    {
   
        yield return new WaitForSeconds(3);
        Destroy(gameObject);


        if (lastBird == true)
        {
            GameManager gm = FindObjectOfType<GameManager>();

            if (gm.gameIsOver == false)
            {
                gm.GameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sr.sprite = sprites[2];
    }
}