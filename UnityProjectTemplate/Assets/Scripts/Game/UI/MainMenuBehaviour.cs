using Core;
using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuBehaviour : MonoBehaviour
{
    CoreManager coreManager;

    public Button PlayButton;

    [Inject]
    public void Init(CoreManager core)
    {
        coreManager = core;
    }

    void Start()
    {
        PlayButton.onClick.RemoveAllListeners();
        PlayButton.onClick.AddListener(OnPlayButton);
    }

    public void OnPlayButton()
    {
        coreManager.EventAgreggator.Trigger(new AppStateManager.OnMainManuPlayPressedEvent());
    }
}
