using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    public GameObject Lip1;
    public GameObject Lip2;
    public GameObject Lip3;
    public GameObject Lip4;

    public GameObject Panel;
    public GameObject Shop;
    public GameObject Return_Button;

    private bool HasChosenSkin=false;
    private string NowMyLipLooksLikeThis = "Teef";

    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false);
        Panel.SetActive(false);
        Return_Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLips(string name)
    {
        Panel.SetActive(true);
        HasChosenSkin = true;
        NowMyLipLooksLikeThis = name;
    }

    public void SetPanelInvisible()
    {
        Panel.SetActive(false);
        HasChosenSkin = false;
    }

    public void Confirm()
    {
        Panel.SetActive(false);
        Shop.SetActive(false);
        Return_Button.SetActive(false);
        change_skin();
    }
    
    public void Return()
    {
        if (HasChosenSkin)
        {
            change_skin();
        }
        Panel.SetActive(false);
        Shop.SetActive(false);
        Return_Button.SetActive(false);
    }

    private void change_skin()
    {
        Image lip_image1 = Lip1.GetComponent<Image>();
        Image lip_image2 = Lip2.GetComponent<Image>();
        Image lip_image3 = Lip3.GetComponent<Image>();
        Image lip_image4 = Lip4.GetComponent<Image>();

        lip_image1.sprite = Instantiate(Resources.Load(NowMyLipLooksLikeThis + "/" + NowMyLipLooksLikeThis + "1", typeof(Sprite)) as Sprite);
        lip_image2.sprite = Instantiate(Resources.Load(NowMyLipLooksLikeThis + "/" + NowMyLipLooksLikeThis + "2", typeof(Sprite)) as Sprite);
        lip_image3.sprite = Instantiate(Resources.Load(NowMyLipLooksLikeThis + "/" + NowMyLipLooksLikeThis + "3", typeof(Sprite)) as Sprite);
        lip_image4.sprite = Instantiate(Resources.Load(NowMyLipLooksLikeThis + "/" + NowMyLipLooksLikeThis + "4", typeof(Sprite)) as Sprite);
    }

    public void Show_Shop()
    {
        Shop.SetActive(true);
        Return_Button.SetActive(true);
    }
}
