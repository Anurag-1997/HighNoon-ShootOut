using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Photon.Pun;

public class WeaponWheelController : MonoBehaviour
{
    public Animator weaponWheelAnim;
    public Animator animator;
    public GameObject player;
    PlayerCombat playerCombat;
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public  static int weaponID;
    private string currentState;
   

    const string PLAYER_IDLE_MELEE = "Idle_Melee";

    //MyInputActions myInputActions;

    //private void OnEnable()
    //{
    //    myInputActions.Enable();
    //}
    //private void OnDisable()
    //{
    //    myInputActions.Disable();
    //}
    private void Start()
    {
        playerCombat = player.GetComponent<PlayerCombat>();
        animator = player.GetComponent<Animator>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            weaponWheelSelected = !weaponWheelSelected;
        }
        if(weaponWheelSelected)
        {
            weaponWheelAnim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            weaponWheelAnim.SetBool("OpenWeaponWheel", false);
        }

        
        
    }
   

    //private void WeaponWheelButton_started(InputAction.CallbackContext obj)
    //{
    //    weaponWheelSelected = !weaponWheelSelected;
    //}
}
