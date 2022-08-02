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
    public float grenadeThrowForce1 =750f;
    public float grenadeThrowForce2 =1000f;

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
        if (pview.IsMine)
        {
            m_Actions.Player.Grenede.started += Grenede_started;
            mousePos = m_Actions.Player.MouseCursor.ReadValue<Vector2>();
            mouseDir = mousePos - new Vector2(this.gameObject.GetComponent<GrenadeThrower>().grenadeThrowPos.transform.position.x, this.gameObject.GetComponent<GrenadeThrower>().grenadeThrowPos.transform.position.y);
            m_Actions.Player.Fire.started += Fire_started;

        }
       




    }

    private void Fire_started(InputAction.CallbackContext obj)
    {
        if(grenadeSelected && this.numberOfGrenades>0)
        {
            
            //grenadeObj.GetComponent<Rigidbody2D>().AddForce(mouseDir.normalized * grenadeThrowForce, ForceMode2D.Impulse);
            if (this.gameObject.tag == "Player1" )
            {
                
                GameObject grenadeObj = PhotonNetwork.Instantiate(grenadePrefab.name, this.grenadeThrowPos.transform.position,Quaternion.identity);
                grenadeObj.GetComponent<Rigidbody2D>().velocity = mouseDir.normalized * grenadeThrowForce1*Time.deltaTime;
               
                
            }
            if (this.gameObject.tag == "Player2")
            {
                
                GameObject grenadeObj1 = PhotonNetwork.Instantiate(grenadePrefab.name, this.grenadeThrowPos.transform.position, Quaternion.identity);
                grenadeObj1.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f*mouseDir.normalized.x,mouseDir.normalized.y).normalized * grenadeThrowForce2*Time.deltaTime;
               
                

            }

            GrenadeNumber();
        }
    }

    private void Grenede_started(InputAction.CallbackContext obj)
    {
        grenadeSelected = !grenadeSelected;
    }
    public void GrenadeNumber()
    {
        pview.RPC("RPC_GrenadeNumber", RpcTarget.All);
    }
    [PunRPC]
    public void RPC_GrenadeNumber()
    {
        this.numberOfGrenades -= 1;
    }
}
