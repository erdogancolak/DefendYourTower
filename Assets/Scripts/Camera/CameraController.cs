using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button rightButtonGo;
    [SerializeField] private Button leftButtonGo;
    private Image rightButtonIm;
    private Image leftButtonIm;
    private Animator animator;
    [SerializeField] private GameObject secondRoadGate;
    [Header("Values")]
    public static bool isSecondRoadGateOpen;
    void Start()
    {
        isSecondRoadGateOpen = false;
        rightButtonIm = rightButtonGo.GetComponent<Image>();
        leftButtonIm = leftButtonGo.GetComponent<Image>();
        animator = GetComponent<Animator>();
        StartCoroutine(gameStartAnim());     
    }

    void Update()
    {
        if(isSecondRoadGateOpen)
        {
            animator.enabled = true;
            StartCoroutine(secondGateAnim());
            isSecondRoadGateOpen = false;
        }
    }

    public void rightButton()
    {
        if(gameObject.transform.position.x < 15)
        {
            gameObject.transform.position = new Vector3(15,0,-10);
        }
    }
    public void leftButton()
    {
        if (GetComponent<Camera>().transform.position.x > -3)
        {
            GetComponent<Camera>().transform.position = new Vector3(-3, 0,-10);
        }
    }

    public void buttonVisible()
    {
        var alphacolor = rightButtonIm.color;
        alphacolor.a = 255;
        rightButtonIm.color = alphacolor;
        leftButtonIm.color = alphacolor;
    }

    public void buttonInvisible()
    {
        var alphacolor = rightButtonIm.color;
        alphacolor.a = 0;
        rightButtonIm.color = alphacolor;
        leftButtonIm.color = alphacolor;
    }

    IEnumerator gameStartAnim()
    {
        animator.SetBool("isGameStart", true);
        yield return new WaitForSeconds(1.7f);
        animator.SetBool("isGameStart", false);
        yield return new WaitForSeconds(1f);
        animator.enabled = false;
    }

    public IEnumerator secondGateAnim()
    {
        animator.SetBool("isSecondRoadGateOpen", true);
        yield return new WaitForSeconds(2.3f);
        Destroy(secondRoadGate);
        yield return new WaitForSeconds(1.4f);
        animator.SetBool("isSecondRoadGateOpen", false);
        yield return new WaitForSeconds(1f);
        animator.enabled = false;
    }
}
