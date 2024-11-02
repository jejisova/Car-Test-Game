//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2014 - 2022 BoneCracker Games
// http://www.bonecrackergames.com
// Buğra Özdoğanlar
//----------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// UI input (float) receiver from UI Button. 
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/Mobile/RCC UI Controller Button")]
public class RCC_UIController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    // Getting an Instance of Main Shared RCC Settings.
    #region RCC Settings Instance

    private RCC_Settings RCCSettingsInstance;
    private RCC_Settings RCCSettings {
        get {
            if (RCCSettingsInstance == null) {
                RCCSettingsInstance = RCC_Settings.Instance;
                return RCCSettingsInstance;
            }
            return RCCSettingsInstance;
        }
    }

    #endregion

    private Button button;
    private Slider slider;

    internal float input;
    private float sensitivity { get { return RCCSettings?.UIButtonSensitivity ?? 1f; } }
    private float gravity { get { return RCCSettings?.UIButtonGravity ?? 10f; } }
    public bool pressing;

    void Awake() {
        button = GetComponent<Button>();
        slider = GetComponent<Slider>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        pressing = false;
    }

    void LateUpdate() {
        // Если есть кнопка и она нажата
        if (button && pressing) {
            input += Time.deltaTime * sensitivity;
        }
        // Если есть слайдер и он активен
        else if (slider && slider.interactable) {
            input = pressing ? slider.value : 0f;
            slider.value = input;
        }
        // Если ни кнопка, ни слайдер не активны, уменьшаем input
        else {
            input -= Time.deltaTime * gravity;
        }

        // Ограничиваем input значениями от 0 до 1
        input = Mathf.Clamp(input, 0f, 1f);
    }

    void OnDisable() {
        input = 0f;
        pressing = false;
    }
}