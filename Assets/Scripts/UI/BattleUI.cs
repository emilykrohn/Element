using UnityEngine;
using UnityEngine.UIElements;

public class BattleUI : MonoBehaviour
{
    PlayerMonster playerMonster;
    EnemyMonster enemyMonster;
    UnityEngine.UIElements.Button attackButton;
    UnityEngine.UIElements.VisualElement mainButtonsContainer;
    UnityEngine.UIElements.VisualElement attackButtonsContainer;
    UnityEngine.UIElements.Button firstAttackButton;
    UnityEngine.UIElements.Button secondAttackButton;
    UnityEngine.UIElements.Button thirdAttackButton;
    UnityEngine.UIElements.Button fourthAttackButton;

    void Start()
    {
        playerMonster = GetComponent<PlayerMonster>();
        enemyMonster = GetComponent<EnemyMonster>();
    }

    void OnEnable()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();

        attackButton = uiDoc.rootVisualElement.Q("AttackButton") as UnityEngine.UIElements.Button;
        attackButton.RegisterCallback<ClickEvent>(OpenAttackMenu);

        mainButtonsContainer = uiDoc.rootVisualElement.Q("MainButtons") as UnityEngine.UIElements.VisualElement;
        attackButtonsContainer = uiDoc.rootVisualElement.Q("AttackButtons") as UnityEngine.UIElements.VisualElement;

        firstAttackButton = uiDoc.rootVisualElement.Q("FirstAttack") as UnityEngine.UIElements.Button;
        secondAttackButton = uiDoc.rootVisualElement.Q("SecondAttack") as UnityEngine.UIElements.Button;
        thirdAttackButton = uiDoc.rootVisualElement.Q("ThirdAttack") as UnityEngine.UIElements.Button;
        fourthAttackButton = uiDoc.rootVisualElement.Q("FourthAttack") as UnityEngine.UIElements.Button;

        firstAttackButton.RegisterCallback<ClickEvent>(FirstAttackAction);
        secondAttackButton.RegisterCallback<ClickEvent>(SecondAttackAction);
        thirdAttackButton.RegisterCallback<ClickEvent>(ThirdAttackAction);
        fourthAttackButton.RegisterCallback<ClickEvent>(FourthAttackAction);
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

    void FirstAttackAction(ClickEvent evt)
    {
        playerMonster.FirstAttack();
    }
    void SecondAttackAction(ClickEvent evt)
    {
        Debug.Log("Second Attack");
    }
    void ThirdAttackAction(ClickEvent evt)
    {
        Debug.Log("Third Attack");
    }
    void FourthAttackAction(ClickEvent evt)
    {
        Debug.Log("Fourth Attack");
    }
}