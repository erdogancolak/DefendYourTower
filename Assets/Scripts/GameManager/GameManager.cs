using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Text hpText;
    [SerializeField] private Text coinText;
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject turretPrefab, cannonPrefab, rocketPrefab;
    [Header("Values")]
    public LayerMask layerMask;
    private GameObject selectedWeapon;
    private bool canBuild;
    public static int coin;

    private void Start()
    {
        coin = 150;
    }
    void Update()
    {
        MouseRaycast();
        coinText.text = coin.ToString();
    }

    private void MouseRaycast()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f,layerMask);
        if(hit.collider != null)
        {
            if (hit.collider.name != "BackgroundTilemap2" && hit.collider.name != "WeaponChild")
            {
                if (canBuild == true && Input.GetMouseButtonDown(0) && selectedWeapon != null)
                {
                    Vector2 spawnedLocate = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                    Instantiate(selectedWeapon, spawnedLocate, Quaternion.identity);
                    canBuild = false;
                }
            }
            if(hit.collider.gameObject.CompareTag("Enemy")) 
            {               
                    hpText.text = hit.collider.GetComponent<EnemyController>().hp.ToString();            
            }
            else
            {
                hpText.text = " ";
            }
        }
    }
    public void shopButton()
    {
        shopCanvas.SetActive(true);
    }

    public void crossButton()
    {
        shopCanvas.SetActive(false);
    }

    public void turretSelect()
    {
        if(GameManager.coin >= 100)
        {
            selectedWeapon = turretPrefab;
            canBuild = true;
            GameManager.coin -= 100;
            shopCanvas.SetActive(false);
        }
    }
    public void cannonSelect()
    {
        if (GameManager.coin >= 250)
        {
            selectedWeapon = cannonPrefab;
            canBuild = true;
            GameManager.coin -= 250;
            shopCanvas.SetActive(false);
        }
    }
    public void rocketSelect()
    {
        if (GameManager.coin >= 400)
        {
            selectedWeapon = rocketPrefab;
            canBuild = true;
            GameManager.coin -= 400;
            shopCanvas.SetActive(false);
        }
    }

}
