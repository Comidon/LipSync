using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatTextController : MonoBehaviour
{
    private Text myText;

    [SerializeField]
    private float moveAmt;
    [SerializeField]
    private float moveSpeed;

    private Vector3[] moveDirs;
    private Vector3 myMoveDir;

    private bool canMove = false;

    private void Start()
    {
        moveDirs = new Vector3[]
        {
            transform.up,
            (transform.up + transform.right),
            (transform.up + -transform.right)
        };

        myMoveDir = moveDirs[Random.Range(0, moveDirs.Length)];
    }
    private void Update()
    {
        if(canMove ==true)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + myMoveDir, moveAmt * (moveSpeed * Time.deltaTime));
        }
    }
    public void SetTextAndMove(string TextStr, Color TextColor)
    {
        myText = GetComponentInChildren<Text>();
        myText.color = TextColor;
        myText.text = TextStr;
        canMove = true;
    }
}
