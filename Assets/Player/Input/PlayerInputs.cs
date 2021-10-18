// GENERATED AUTOMATICALLY FROM 'Assets/Player/Input/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""631e98be-6ca1-48cb-bf3d-23098436734e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""3ef81e92-f423-49e3-99a1-03576334983f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""07759903-f5b0-4e52-bb93-d108e2d5be4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Open Menu"",
                    ""type"": ""Button"",
                    ""id"": ""11e22ac7-47c0-4d15-826e-5b3e8aff4bf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""68fcfba6-d30e-4d54-a223-98ac38e85e95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0125559d-03c2-464b-83f9-f5ecfb131a98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill 1"",
                    ""type"": ""Button"",
                    ""id"": ""4c05eb46-fb96-43b4-a57b-5f343e4becf8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill 2"",
                    ""type"": ""Button"",
                    ""id"": ""7dfb7337-90fc-48f7-8b2c-beffcdfc6029"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill 3"",
                    ""type"": ""Button"",
                    ""id"": ""32068b8d-7b27-4277-9a99-232dcc86da81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill 4"",
                    ""type"": ""Button"",
                    ""id"": ""0f7e3b90-0cc6-488b-820a-bac559435ad0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill 5"",
                    ""type"": ""Button"",
                    ""id"": ""71645840-1074-4a35-946e-9b26281f91ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Map"",
                    ""type"": ""Button"",
                    ""id"": ""c45a4e9f-bdf8-408b-9680-16fd11d6f84d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenInventory"",
                    ""type"": ""Button"",
                    ""id"": ""91fd9c42-a70d-4b21-9d37-abad6d1760f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""59f752af-cefb-4b0a-a488-0038825062f4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""407469a1-3f41-4877-b6d5-de22c4a4df88"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aee19d0-c754-4e6a-9a8e-1f1920edf58e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7bf6c05-3ec7-4cda-ac0e-faf1cb04bf67"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b76d0e8-4d72-40d9-9480-0c9a5612edc9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd4f5e1e-3548-4861-aeba-89a37a04bbf5"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dc6f90c-4f3d-45e9-be36-6010c84f407e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c627d61b-69e3-4dcd-92c2-b88605c9a2b2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb76c100-aec9-4668-a446-781b0b35b60c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""144ad2c6-59ba-4bf7-8f8d-ac9a24c3a43e"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c0c7e1be-da75-4698-86f7-3b9cf84e7c17"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""749ed357-85b4-4c5b-85b8-9c2baa881007"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0e8cac13-e4c9-433d-8784-da2850d34a3b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6caf36ca-dfbc-4266-83ea-8ab1e535e45e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""02db1575-d87e-4026-ab5e-dbcf6993f8ac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2e02abaf-9cec-420d-a42b-4650117ed4de"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Dodge = m_Player.FindAction("Dodge", throwIfNotFound: true);
        m_Player_OpenMenu = m_Player.FindAction("Open Menu", throwIfNotFound: true);
        m_Player_Primary = m_Player.FindAction("Primary", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Skill1 = m_Player.FindAction("Skill 1", throwIfNotFound: true);
        m_Player_Skill2 = m_Player.FindAction("Skill 2", throwIfNotFound: true);
        m_Player_Skill3 = m_Player.FindAction("Skill 3", throwIfNotFound: true);
        m_Player_Skill4 = m_Player.FindAction("Skill 4", throwIfNotFound: true);
        m_Player_Skill5 = m_Player.FindAction("Skill 5", throwIfNotFound: true);
        m_Player_Map = m_Player.FindAction("Map", throwIfNotFound: true);
        m_Player_OpenInventory = m_Player.FindAction("OpenInventory", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Dodge;
    private readonly InputAction m_Player_OpenMenu;
    private readonly InputAction m_Player_Primary;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Skill1;
    private readonly InputAction m_Player_Skill2;
    private readonly InputAction m_Player_Skill3;
    private readonly InputAction m_Player_Skill4;
    private readonly InputAction m_Player_Skill5;
    private readonly InputAction m_Player_Map;
    private readonly InputAction m_Player_OpenInventory;
    public struct PlayerActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @OpenMenu => m_Wrapper.m_Player_OpenMenu;
        public InputAction @Primary => m_Wrapper.m_Player_Primary;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Skill1 => m_Wrapper.m_Player_Skill1;
        public InputAction @Skill2 => m_Wrapper.m_Player_Skill2;
        public InputAction @Skill3 => m_Wrapper.m_Player_Skill3;
        public InputAction @Skill4 => m_Wrapper.m_Player_Skill4;
        public InputAction @Skill5 => m_Wrapper.m_Player_Skill5;
        public InputAction @Map => m_Wrapper.m_Player_Map;
        public InputAction @OpenInventory => m_Wrapper.m_Player_OpenInventory;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Dodge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @OpenMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
                @Primary.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimary;
                @Primary.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimary;
                @Primary.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimary;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Skill1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill1;
                @Skill1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill1;
                @Skill1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill1;
                @Skill2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill2;
                @Skill2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill2;
                @Skill2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill2;
                @Skill3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill3;
                @Skill3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill3;
                @Skill3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill3;
                @Skill4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill4;
                @Skill4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill4;
                @Skill4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill4;
                @Skill5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill5;
                @Skill5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill5;
                @Skill5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill5;
                @Map.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMap;
                @Map.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMap;
                @Map.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMap;
                @OpenInventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
                @Primary.started += instance.OnPrimary;
                @Primary.performed += instance.OnPrimary;
                @Primary.canceled += instance.OnPrimary;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Skill1.started += instance.OnSkill1;
                @Skill1.performed += instance.OnSkill1;
                @Skill1.canceled += instance.OnSkill1;
                @Skill2.started += instance.OnSkill2;
                @Skill2.performed += instance.OnSkill2;
                @Skill2.canceled += instance.OnSkill2;
                @Skill3.started += instance.OnSkill3;
                @Skill3.performed += instance.OnSkill3;
                @Skill3.canceled += instance.OnSkill3;
                @Skill4.started += instance.OnSkill4;
                @Skill4.performed += instance.OnSkill4;
                @Skill4.canceled += instance.OnSkill4;
                @Skill5.started += instance.OnSkill5;
                @Skill5.performed += instance.OnSkill5;
                @Skill5.canceled += instance.OnSkill5;
                @Map.started += instance.OnMap;
                @Map.performed += instance.OnMap;
                @Map.canceled += instance.OnMap;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
        void OnPrimary(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSkill1(InputAction.CallbackContext context);
        void OnSkill2(InputAction.CallbackContext context);
        void OnSkill3(InputAction.CallbackContext context);
        void OnSkill4(InputAction.CallbackContext context);
        void OnSkill5(InputAction.CallbackContext context);
        void OnMap(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
    }
}
