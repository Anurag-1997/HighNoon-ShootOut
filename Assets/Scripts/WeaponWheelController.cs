using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class WeaponWheelController : MonoBehaviour
{
    public Animator anim;
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponID;

    //MyInputActions myInputActions;

    //private void OnEnable()
    //{
    //    myInputActions.Enable();
    //}
    //private void OnDisable()
    //{
    //    myInputActions.Disable();
    //}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            weaponWheelSelected = !weaponWheelSelected;
        }
        if(weaponWheelSelected)
        {
            anim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
        }

        switch (weaponID)
        {
            case 0: //nothing is selected
                selectedItem.sprite = noImage;
                break;
            case 1: //Melee Weapon
                Debug.Log("Melee Weapon");
                break;
            case 2: //Pistol
                Debug.Log("Pistol");
                break;
            case 3: //SMG 1
                Debug.Log("SMG 1");
                break;
            case 4: //SMG 2
                Debug.Log("SMG 2");
                break;
            case 5: //ShotGun
                Debug.Log("ShotGun");
                break;
            case 6: //Rocket Launcher
                Debug.Log("Rocket Launcher");
                break;
            case 7: //Grenede
                Debug.Log("Grenede");
                break;
        }
    }

    //private void WeaponWheelButton_started(InputAction.CallbackContext obj)
    //{
    //    weaponWheelSelected = !weaponWheelSelected;
    //}
}
