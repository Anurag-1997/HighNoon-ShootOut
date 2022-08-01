using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using UnityEngine.UI;



public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform grenadeThrowPos;
    MyInputActions m_Actions;
    public Vector2 mousePos;
    public float grenadeThrowForce = 1f;
    public bool grenadeSelected = false;
    Vector2 mouseDir;
    public PhotonView pview;
    public int numberOfGrenades = 3;
    
 
    private void Awake()
    {
        m_Actions = new MyInputActions();
        pview = this.gameObject.GetPhotonView();
    }
    private void OnEnable()
    {
        m_Actions.Enable();
    }
    private void OnDisable()
    {
        m_Actions.Disable();
    }
    private void Update()
    {
        if(pview.IsMine)
        {
            m_Actions.Player.Grenede.started += Grenede_started;
            mousePos = m_Actions.Player.MouseCursor.ReadValue<Vector2>();
            mouseDir = mousePos - new Vector2(this.grenadeThrowPos.transform.position.x, this.grenadeThrowPos.transform.position.y);
            m_Actions.Player.Fire.started += Fire_started;
        }
        




    }

    private void Fire_started(InputAction.CallbackContext obj)
    {
        if(grenadeSelected && this.numberOfGrenades>0)
        {
            GameObject grenadeObj = Instantiate(grenadePrefab, this.grenadeThrowPos.transform.position, transform.rotation);
            //grenadeObj.GetComponent<Rigidbody2D>().AddForce(mouseDir.normalized * grenadeThrowForce, ForceMode2D.Impulse);
            if(PhotonNetwork.LocalPlayer.ActorNumber ==1 )
            {
                grenadeObj.GetComponent<Rigidbody2D>().velocity = mouseDir.normalized * grenadeThrowForce*Time.deltaTime;
            }
            if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                grenadeObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-mouseDir.x,mouseDir.y).normalized * grenadeThrowForce*Time.deltaTime;

            }
            this.numberOfGrenades -= 1;
        }
    }

    private void Grenede_started(InputAction.CallbackContext obj)
    {
        grenadeSelected = !grenadeSelected;
    }
}
