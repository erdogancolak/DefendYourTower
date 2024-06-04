using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject DFTL_enemy,RGND_enemy,ARMR_enemy;
    [SerializeField] private Button waveStartButtonGo;
    [SerializeField] private Text WaveText;
    [SerializeField] private GameObject secondSpawner;
    [Header("Values")]
    public Color green, red;
    private int randomNumber;
    private int currentWave = 1;
    [SerializeField] private float waitSecond;

    void Start()
    {
        waveStartButtonGo.GetComponent<Image>().color = green;
    }

    void Update()
    {
        
    }
    #region spawner
    IEnumerator spawner(int spawnCount,int Wave)
    {
        switch (Wave)
        {
            case 1:
            case 2:
                for(int i = 0; i < spawnCount; i++)
                {
                    Instantiate(DFTL_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);                   
                }              
                break;
            case 3:
                for (int i = 0; i < spawnCount; i++)
                {
                    Instantiate(DFTL_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);
                }
                Instantiate(RGND_enemy, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(waitSecond);
                Instantiate(RGND_enemy, transform.position, Quaternion.identity);
                break;
            case 4:
                for (int i = 0; i < spawnCount; i++)
                {
                    Instantiate(DFTL_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);
                }
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(RGND_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);
                }
                break;
            case 5:
                for (int i = 0; i < spawnCount; i++)
                {
                    Instantiate(DFTL_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);
                }
                break;
            case 6:
                for (int i = 0; i < spawnCount; i++)
                {
                    Instantiate(DFTL_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);
                }
                for(int i = 0; i < 15;i++)
                {
                    Instantiate(RGND_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);
                }
                break;
            case 7:
                for (int i = 0; i < spawnCount; i++)
                {
                    Instantiate(DFTL_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);
                }
                for (int i = 0; i < 20; i++)
                {
                    Instantiate(RGND_enemy, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(waitSecond);
                }
                break;
            case 8:
                for (int i = 0; i < spawnCount; i++)
                {
                    randomNumber = Random.Range(0, 4);
                    if(randomNumber == 0)
                    {
                        Instantiate(DFTL_enemy, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(RGND_enemy, transform.position, Quaternion.identity);
                    }
                    yield return new WaitForSeconds(waitSecond);
                }
                break;
            case 9:
                for (int i = 0; i < spawnCount; i++)
                {
                    randomNumber = Random.Range(0,3);
                    if (randomNumber == 0)
                    {
                        Instantiate(DFTL_enemy, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(RGND_enemy, transform.position, Quaternion.identity);
                    }
                    yield return new WaitForSeconds(waitSecond);
                }
                yield return new WaitForSeconds(4);
                CameraController.isSecondRoadGateOpen = true;
                break;
            case 10:               
                for (int i = 0;i < spawnCount;i++)
                    {
                        Instantiate(ARMR_enemy, secondSpawner.transform.position, Quaternion.identity);
                        yield return new WaitForSeconds(waitSecond + 1);
                    }
                yield return new WaitForSeconds(4);
                Application.Quit();
                break;

        }
        yield return new WaitForSeconds(4);
        waveStartButtonGo.GetComponent<Image>().color = green;
    }
    #endregion
    #region WaveSpawner
    private void WaveSpawner(int WaveCount)
    {
        switch (WaveCount)
        {
            case 1:
                StartCoroutine(spawner(10, 1));
                break;
            case 2:
                StartCoroutine(spawner(15, 2));
                break;
            case 3:
                StartCoroutine(spawner(15, 3));
                break;
            case 4:
                StartCoroutine(spawner(25, 4));
                break;
            case 5:
                StartCoroutine(spawner(40, 5));
                break;
            case 6:
                StartCoroutine(spawner(15, 6));
                break;
            case 7:
                StartCoroutine(spawner(25, 7));
                break;
            case 8:
                StartCoroutine(spawner(35, 8));
                break;
            case 9:
                StartCoroutine(spawner(25, 9));
                break;
            case 10:
                StartCoroutine(spawner(5, 10));
                break;

        }
    }
    #endregion WaveSpawner

    public void WaveStartButton()
    {
        if(waveStartButtonGo.GetComponent<Image>().color == green)
        {
            WaveText.text = ("Wave = " + currentWave.ToString());
            WaveSpawner(currentWave);
            currentWave++;
            waveStartButtonGo.GetComponent<Image>().color = red;
        }
    }
}
