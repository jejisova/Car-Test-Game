using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class FinishGame : MonoBehaviour
{
    [SerializeField] GameObject finishMenu;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject star1, star2, star3;
    [SerializeField] float timeTo2Star, timeTo3Star;
    [SerializeField] AudioClip congratulation;
    [SerializeField] AudioClip addStar;

    void Start()
    {
        finishMenu.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        HideRCCMenu();
        ShowFinishMenu();
        StartCoroutine(ShowScore(CalculateScore()));
    }

    private float CalculateScore()
    {
        return Time.time; // Здесь можно изменить логику для подсчета очков
    }

    private IEnumerator ShowScore(float finalScore)
    {
        scoreText.SetActive(true);
        TextMeshProUGUI scoreTextTMP = scoreText.GetComponent<TextMeshProUGUI>();

        float currentScore = 0;
        float duration = 5f;
        float step = finalScore / (duration * 100);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            currentScore += step;
            elapsedTime += Time.deltaTime;
            scoreTextTMP.SetText(currentScore.ToString("F2"));
            yield return null;
        }

        scoreTextTMP.SetText(finalScore.ToString("F2"));


        yield return new WaitForSeconds(1f);

        StartCoroutine(ShowStars(finalScore));
    }

    private IEnumerator ShowStars(float finalScore)
    {
        print(finalScore);
        star1.SetActive(true);
        AudioSource.PlayClipAtPoint(addStar, transform.position);
        yield return new WaitForSeconds(1f);
        if (finalScore < timeTo2Star)
        {
            star2.SetActive(true);
            AudioSource.PlayClipAtPoint(addStar, transform.position);
        }

        yield return new WaitForSeconds(1f);
        if (finalScore < timeTo2Star && finalScore < timeTo3Star)
        {
            AudioSource.PlayClipAtPoint(addStar, transform.position);
            star3.SetActive(true);
        }

    }

    private void HideRCCMenu()
    {
        GameObject rccmenu = GameObject.Find("RCCCanvas");
        if (rccmenu != null)
        {
            rccmenu.SetActive(false);
        }
        RCC_CarControllerV3 rccCar = FindAnyObjectByType<RCC_CarControllerV3>();
        if (rccCar != null)
        {
            rccCar.gameObject.SetActive(false);
        }
    }

    private void ShowFinishMenu()
    {
        finishMenu.SetActive(true);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        scoreText.SetActive(false);
        AudioSource.PlayClipAtPoint(congratulation, transform.position);
    }
}