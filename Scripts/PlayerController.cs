using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public Animator anim;

    public static PlayerController instance;
    public string areaTransitionName;

    private Vector3 BottomLeftLimit;
    private Vector3 TopRightLimit;

    void Start()
    {
        //No duplicate
        if(instance==null)        instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        }

        anim.SetFloat("moveX", movementInput.x);
        anim.SetFloat("moveY", movementInput.y);

        if(movementInput.x == 1 || movementInput.x == -1 || movementInput.y == 1 || movementInput.y == -1){
            anim.SetFloat("lastMoveX", movementInput.x);
            anim.SetFloat("lastMoveY", movementInput.y);
        }

        //Keep player inside
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, BottomLeftLimit.x,TopRightLimit.x), Mathf.Clamp(transform.position.y, BottomLeftLimit.y,TopRightLimit.y), transform.position.z);

    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        BottomLeftLimit = botLeft + new Vector3(.5f,1f,0f);
        TopRightLimit = topRight - new Vector3(.5f,1f,0f);
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        print("ayoye");
    }
}
