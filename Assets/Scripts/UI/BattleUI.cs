using System.Diagnostics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BattleUI : MonoBehaviour
{
    UnityEngine.UIElements.Button attackButton;
    UnityEngine.UIElements.VisualElement mainButtonsContainer;
    UnityEngine.UIElements.VisualElement attackButtonsContainer;

    void OnEnable()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();

        attackButton = uiDoc.rootVisualElement.Q("AttackButton") as UnityEngine.UIElements.Button;
        attackButton.RegisterCallback<ClickEvent>(OpenAttackMenu);

        mainButtonsContainer = uiDoc.rootVisualElement.Q("MainButtons") as UnityEngine.UIElements.VisualElement;
        attackButtonsContainer = uiDoc.rootVisualElement.Q("AttackButtons") as UnityEngine.UIElements.VisualElement;
    }

    void OnDisable()
    {
        attackButton.UnregisterCallback<ClickEvent>(OpenAttackMenu);
    }

    void OpenAttackMenu(ClickEvent evt)
    {
        mainButtonsContainer.style.display = DisplayStyle.None;
        attackButtonsContainer.style.display = DisplayStyle.Flex;
    }
}