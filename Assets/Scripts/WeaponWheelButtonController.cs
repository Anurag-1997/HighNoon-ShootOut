using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponWheelButtonController : MonoBehaviour
{
    public int ID;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Sprite icon;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selected)
        {
            selectedItem.sprite = icon;
            itemText.name = itemName;
        }    
       
    }
    public void Selected()
    {
        selected = true;
        WeaponWheelController.weaponID = ID;
    }
    public void Deselected()
    {
        selected = false;
        WeaponWheelController.weaponID = 0;
    }
    public void HoverEnter()
    {
        anim.SetBool("Hovered", true);
        itemText.text = itemName;
    }
    public void HoverExit()
    {
        anim.SetBool("Hovered", false);
        itemText.text = "";
    }
}
