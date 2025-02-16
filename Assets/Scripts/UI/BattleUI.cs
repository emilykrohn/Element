using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BattleUI : MonoBehaviour
{
    PlayerMonster playerMonster;
    EnemyMonster enemyMonster;
    UnityEngine.UIElements.Button attackButton;
    UnityEngine.UIElements.VisualElement mainButtonsContainer;
    UnityEngine.UIElements.VisualElement attackButtonsContainer;
    UnityEngine.UIElements.VisualElement textboxContainer;
    UnityEngine.UIElements.Button firstAttackButton;
    UnityEngine.UIElements.Button secondAttackButton;
    UnityEngine.UIElements.Button thirdAttackButton;
    UnityEngine.UIElements.Button fourthAttackButton;
    bool isDefeated;
    bool pressedNext;
    public InputSystem_Actions playerControls;
    private InputAction interact;

    private void Awake()
    {
        playerControls = new InputSystem_Actions();
    }

    void Start()
    {
        playerMonster = GetComponent<PlayerMonster>();
        enemyMonster = GetComponent<EnemyMonster>();
        isDefeated = false;
        pressedNext = false;
    }

    void OnEnable()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();

        attackButton = uiDoc.rootVisualElement.Q("AttackButton") as UnityEngine.UIElements.Button;
        attackButton.RegisterCallback<ClickEvent>(OpenAttackMenu);

        mainButtonsContainer = uiDoc.rootVisualElement.Q("MainButtons") as UnityEngine.UIElements.VisualElement;
        attackButtonsContainer = uiDoc.rootVisualElement.Q("AttackButtons") as UnityEngine.UIElements.VisualElement;
        textboxContainer = uiDoc.rootVisualElement.Q("TextboxContainer") as UnityEngine.UIElements.VisualElement;

        firstAttackButton = uiDoc.rootVisualElement.Q("FirstAttack") as UnityEngine.UIElements.Button;
        secondAttackButton = uiDoc.rootVisualElement.Q("SecondAttack") as UnityEngine.UIElements.Button;
        thirdAttackButton = uiDoc.rootVisualElement.Q("ThirdAttack") as UnityEngine.UIElements.Button;
        fourthAttackButton = uiDoc.rootVisualElement.Q("FourthAttack") as UnityEngine.UIElements.Button;

        firstAttackButton.RegisterCallback<ClickEvent>(FirstAttackAction);
        secondAttackButton.RegisterCallback<ClickEvent>(SecondAttackAction);
        thirdAttackButton.RegisterCallback<ClickEvent>(ThirdAttackAction);
        fourthAttackButton.RegisterCallback<ClickEvent>(FourthAttackAction);

        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }

    void OnDisable()
    {
        attackButton.UnregisterCallback<ClickEvent>(OpenAttackMenu);
        interact.Disable();
    }

    void OpenAttackMenu(ClickEvent evt)
    {
        mainButtonsContainer.style.display = DisplayStyle.None;
        attackButtonsContainer.style.display = DisplayStyle.Flex;
    }

    void FirstAttackAction(ClickEvent evt)
    {
        if (!playerMonster.FirstAttack())
        {
            attackButtonsContainer.style.display = DisplayStyle.None;
            textboxContainer.style.display = DisplayStyle.Flex;
            pressedNext = false;
            isDefeated = true;
        }
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

    void Interact(InputAction.CallbackContext context)
    {
        pressedNext = true;
    }

    void Update()
    {
        if (isDefeated && pressedNext)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}