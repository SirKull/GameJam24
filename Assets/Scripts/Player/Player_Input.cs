using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    //References
    public PlayerInputActions playerControls;
    public PlayerObject[] playerObjects;
    public Player_Weapon[] playerWeapons;
    public GameObject aimObject;
    public Transform playerBody;
    public Transform firePoint;
    public Camera mainCam;

    //Inputs
    private InputAction move;
    private InputAction shoot;
    private InputAction pickup;
    private InputAction aim;

    //Events
    public delegate void InteractAction();
    public static event InteractAction OnInteract;
    public delegate void ShootAction();
    public static event ShootAction OnShoot;

    //Movement
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    //Pickup & Drop
    public bool canPickup;
    public bool canDrop;
    public bool holdingObject;
    public bool holdingWeapon;
    public int objectValue;

    //Move & Aim
    public Vector2 moveDirection = Vector2.zero;
    public Vector2 aimDirection = Vector2.zero;
    public Vector3 mousePos;
    public float degrees;
    public Vector2 playerPosition;

    //Weapons
    public bool hasFry;
    public bool hasSoda;
    public bool hasBurger;
    public bool hasSalad;
    [SerializeField] private float weaponDistance = 1.5f;

    private void OnEnable()
    {
        playerControls = new PlayerInputActions();

        move = playerControls.Player.Move;
        move.Enable();
        
        pickup = playerControls.Player.Pickup;
        pickup.Enable();
        pickup.performed += Interact;

        shoot = playerControls.Player.Shoot;
        shoot.Enable();
        shoot.performed += Shoot;

        aim = playerControls.Player.Look;
        aim.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        pickup.Disable();
        aim.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        canDrop = false;
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
        SetItems();
        SetWeapons();
        CurrentItem(0);
        CurrentWeapon(0);
    }

    // Update is called once per frame
    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        aimDirection = aim.ReadValue<Vector2>();

        playerPosition = transform.position;
        if (holdingWeapon)
        {
            Aim();
        }
        if (!holdingObject)
        {
            if (hasFry)
            {
                CurrentWeapon(1);
                holdingWeapon = true;
            }
            if (hasSalad)
            {
                CurrentWeapon(2);
                holdingWeapon = true;
            }
            if (hasBurger)
            {
                CurrentWeapon(3);
                holdingWeapon = true;
            }
            if (hasSoda)
            {
                CurrentWeapon(4);
                holdingWeapon = true;
            }
        }
        if (rb.velocity.x >= 0.01f)
        {
            playerBody.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
        else if (rb.velocity.x <= -0.1f)
        {
            playerBody.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void SetItems()
    {
        playerObjects = GetComponentsInChildren<PlayerObject>();
    }
    private void SetWeapons()
    {
        playerWeapons = GetComponentsInChildren<Player_Weapon>();
    }

    public void CurrentItem(int itemIndex)
    {
        for (int i = 0; i < playerObjects.Length; i++)
        {
            playerObjects[i].gameObject.SetActive(i == itemIndex);
        }

        objectValue = itemIndex;
    }
    public void CurrentWeapon(int weaponIndex)
    {
        for(int i = 0; i < playerWeapons.Length; i++)
        {
            playerWeapons[i].gameObject.SetActive(i == weaponIndex);
        }
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if(OnInteract != null)
        {
            OnInteract();
        }
    }
    private void Shoot(InputAction.CallbackContext context)
    {
        if(OnShoot != null)
        {
            OnShoot();
        }
    }
    private void Aim()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        aimObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        aimObject.transform.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(weaponDistance, 0, 0);
    }
}
