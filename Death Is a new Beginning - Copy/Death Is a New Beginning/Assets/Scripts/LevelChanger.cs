using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public GameObject teleporter;
    public GameObject candles;

    private static int levelToLoad;

    #region Singleton

    public static LevelChanger instance;
    private void Awake()
    {
        instance = this;
        //health = player.GetComponent<Health>();
    }

    #endregion

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        if (levelIndex == 2)
        {
            StartCoroutine(FadeAudioOut());
        }
    }

    public void OnFadeComplete()
    {
        Destroy(AudioManager.instance.gameObject);
        SceneManager.LoadScene(levelToLoad);
    }

    public void BeginStory()
    {
        StoryManager.instance.BeginStory();
    }

    public void ActivateTeleport()
    {
        teleporter.SetActive(true);
        AudioManager.instance.Play("Teleport");
    }

    public void ActivateCandles()
    {
        candles.SetActive(true);
    }

    private IEnumerator FadeAudioOut()
    {
        float speed = 0.0005f;
        Sound audioSrc = AudioManager.instance.sounds[0];
        while (audioSrc.volume < 1)
        {
            audioSrc.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
