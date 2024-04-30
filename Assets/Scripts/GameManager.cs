using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class GameManager : MonoBehaviour
{
    [SerializeField] Slider sliderMaster, sliderSfx, sliderMusic;
    [SerializeField] bool isDebug, isMainMenu;
    [SerializeField] GameObject menuOnLevel, menuPartOnlyLevel, menuBack;

    public static GameManager gm;
    public static Action Upd, FxUpd;
    public AudioMixer mixer;
    public bool isContinue;

    public Dictionary<string, KeyCode> input = new Dictionary<string, KeyCode>() 
    {
        {"forward", KeyCode.W},
        {"backward", KeyCode.S},
        {"left", KeyCode.A},
        {"right", KeyCode.D},
        {"interact", KeyCode.E},
        {"menu", KeyCode.Escape},
    };

    private void Awake()
    {
        gm = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (isDebug)
        {
            PlayerPrefs.SetFloat("masterV", 0);
            PlayerPrefs.SetFloat("sfxV", 0);
            PlayerPrefs.SetFloat("musicV", 0);


        }
        else
        {
            PlayerPrefs.SetFloat("masterV", 0);
            PlayerPrefs.SetFloat("sfxV", 0);
            PlayerPrefs.SetFloat("musicV", 0);
        }

        sliderMaster.SetValueWithoutNotify(PlayerPrefs.GetFloat("masterV"));
        sliderSfx.SetValueWithoutNotify(PlayerPrefs.GetFloat("sfxV"));
        sliderMusic.SetValueWithoutNotify(PlayerPrefs.GetFloat("musicV"));
    }

    public void SetContinue(bool c)
    {
        isContinue = c;
    }

    public void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat("masterV", volume);
        mixer.SetFloat("master", volume);
    }

    public void SetSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat("sfxV", volume);
        mixer.SetFloat("sfx", volume);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicV", volume);
        mixer.SetFloat("music", volume);
    }

    public void Update()
    {
        Upd?.Invoke();

        if (Input.GetKeyDown(input["menu"])) ShowMenu(!menuBack.activeInHierarchy);
    }
    public void FixedUpdate()
    {
        FxUpd?.Invoke();
    }

    public void SceneLoaded()
    {
        isMainMenu = false;
    }

    public void ShowMenu(bool s)
    {
        if (isMainMenu) return;

        menuPartOnlyLevel.SetActive(s);
        if (!s) menuOnLevel.SetActive(s);
        menuBack.SetActive(s);
    }

    public void ShowSetting(bool s)
    {
        if (isMainMenu) return;

        menuOnLevel.SetActive(s);
        menuPartOnlyLevel.SetActive(!s);
    }

    public void Exit()
    {
        PlayerPrefs.SetInt("task", TaskManager.Instant.currentTaskIndex-1);

        Application.Quit();
    }
}
