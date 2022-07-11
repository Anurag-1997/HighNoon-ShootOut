using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform grenadeThrowPos;
    MyInputActions m_Actions;
    public Vector2 mousePos;
    public float grenadeThrowForce = 1f;
    public bool grenadeSelected = false;
    Vector2 mouseDir;
    private void Awake()
    {
        m_Actions = new MyInputActions();
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
        m_Actions.Player.Grenede.started += Grenede_started;
        mousePos = m_Actions.Player.MouseCursor.ReadValue<Vector2>();
        mouseDir = mousePos - new Vector2(transform.position.x, transform.position.y);
        m_Actions.Player.Fire.started += Fire_started;



    }

    private void Fire_started(InputAction.CallbackContext obj)
    {
        if(grenadeSelected)
        {
            GameObject grenadeObj = Instantiate(grenadePrefab, grenadeThrowPos.transform.position, transform.rotation);
            //grenadeObj.GetComponent<Rigidbody2D>().AddForce(mouseDir.normalized * grenadeThrowForce, ForceMode2D.Impulse);
            grenadeObj.GetComponent<Rigidbody2D>().velocity = mouseDir.normalized * grenadeThrowForce;
        }
    }

    private void Grenede_started(InputAction.CallbackContext obj)
    {
        grenadeSelected = !grenadeSelected;
    }
}
