using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private FlashLightScript flashligh;
    private PlayerShooting playerShooting;

    public float MovementSpeed = 5f;
    public float RotationSpeed = 100f;

    private Animator playerAnimator;
    private GamePause gamePause;
    private Rigidbody playerRigidbody;
    private Vector3 playerMovementVector;
    private LayerMask groundLayerMask;

    private void Awake()
    {
        //attached script
        groundLayerMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
        playerShooting = GetComponent<PlayerShooting>();
        playerAnimator = GetComponent<Animator>();

        if (groundLayerMask == default(int))
        {
            Debug.LogError("Can't find mask: Floor");
        }

        //external gameObject refereces
        flashligh = GameObject.Find("FlashLight").GetComponentInChildren<FlashLightScript>();
        gamePause = GameObject.Find("GlobalScriptsObject").GetComponent<GamePause>();
    }

    void Update()
    {
        if (!gamePause._pause)
        {
            Shooting();
            FlashLightControl();
            GunReload();
        }
    }

    void FixedUpdate()
    {
        playerMovementVector = GetUserRawInputNormalized() * Time.deltaTime * MovementSpeed;
        playerRigidbody.MovePosition(this.transform.position + playerMovementVector);
        playerRigidbody.MoveRotation(GetPlayerRotationByMousePoint());
    }

    private void LateUpdate()
    {
        if (playerMovementVector != default(Vector3))
        {
            playerAnimator.SetBool("moving", true);
        }
        else playerAnimator.SetBool("moving", false);
    }

    private Vector3 GetUserRawInputNormalized()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        playerMovementVector.Set(horizontalInput, 0f, verticalInput);
        return playerMovementVector.normalized;
    }

    private Quaternion GetPlayerRotationByMousePoint()
    {
        Ray rayFromCam = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;

        if (Physics.Raycast(rayFromCam, out rayHit, Camera.main.farClipPlane, groundLayerMask))
        {
            Vector3 rotationVector = rayHit.point - transform.position;
            rotationVector.y = default(float);
            return Quaternion.LookRotation(rotationVector);
        }

        return this.transform.rotation;
    }

    private void GunReload()
    {
        if (Input.GetKeyUp("r"))
        {
            playerShooting.Reload();
        }
    }

    private void Shooting()
    {
        if (Input.GetAxisRaw("Fire1") != default(float))
        {
            playerShooting.Shoot();
        }
    }

    private void FlashLightControl()
    {
        if (Input.GetKeyUp("e"))
        {
            flashligh.SwitchLight();
        }
    }
}