using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float CountdownTime = 60f;

    private float m_CurrCountdownValue;
    private bool m_Countdown = false;

    public void Start()
    {
        
    }

    private void Update()
    {
        if (!m_Countdown && GameManager_script.gameReallyStarted)
        {
            StartCoroutine(StartCountdown());
        }
    }

    public IEnumerator StartCountdown()
    {
        m_Countdown = true;
        m_CurrCountdownValue = CountdownTime;
        while (m_CurrCountdownValue > 0)
        {
            Debug.Log("Countdown: " + m_CurrCountdownValue);
            yield return new WaitForSeconds(1.0f);
            m_CurrCountdownValue--;
            //SceneManager.LoadScene("MainGame");
            //GameObject.setActive(true); remplacer gameobject par panel menu
        }
        GameManager_script.gameOver = true;
        m_Countdown = false;
    }

}