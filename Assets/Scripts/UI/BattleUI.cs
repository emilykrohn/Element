using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BattleUI : MonoBehaviour
{
    UnityEngine.UIElements.Button attackButton;

    void OnEnable()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();

        attackButton = uiDoc.rootVisualElement.Q("AttackButton") as UnityEngine.UIElements.Button;
        attackButton.RegisterCallback<ClickEvent>(OpenAttackMenu);
    }

    void OnDisable()
    {
        attackButton.UnregisterCallback<ClickEvent>(OpenAttackMenu);
    }

    void OpenAttackMenu(ClickEvent evt)
    {
        Debug.Log("AttackMenu");
    }
}