using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class CustomKeyBindings : MonoBehaviour
{
    private CameraInputAction inputs;
    private TMP_InputField[] newKeyInputs;
    private Dictionary<string, Key> keyMappings = new Dictionary<string, Key>();

    private readonly string[] actionNames = { "Up", "Down", "Left", "Right", "Forward", "Backward" };

    void OnEnable()
    {
        inputs = new CameraInputAction();
        inputs.Enable();
        LoadKeyBindings();
    }

    void Start()
    {
        newKeyInputs = GetComponentsInChildren<TMP_InputField>();
    }

    public void Submit()
    {
        for (int i = 0; i < newKeyInputs.Length && i < actionNames.Length; i++)
        {
            string keyInput = newKeyInputs[i].text.ToUpper();

            if (!IsValidKey(keyInput))
            {
                Debug.LogWarning($"Invalid key: {keyInput}");
                continue;
            }

            Key newKey = (Key)System.Enum.Parse(typeof(Key), keyInput);

            if (IsDuplicateKey(newKey))
            {
                Debug.LogWarning($"Duplicate key: {keyInput}");
                continue;
            }

            RebindKey(actionNames[i], newKey);
        }
    }

    private bool IsValidKey(string keyInput)
    {
        return System.Enum.TryParse(keyInput, out Key _);
    }

    private bool IsDuplicateKey(Key newKey)
    {
        return keyMappings.ContainsValue(newKey);
    }

    private void RebindKey(string actionName, Key newKey)
    {
        InputAction action = GetActionByName(actionName);

        if (action != null)
        {
            int bindingIndex = GetBindingIndex(action, actionName);
            if (bindingIndex != -1)
            {
                action.ApplyBindingOverride(bindingIndex, $"<Keyboard>/{newKey}");
                Debug.Log($"{actionName} is now bound to {newKey}");

                keyMappings[actionName] = newKey;
                PlayerPrefs.SetString($"Rebind_{actionName}", newKey.ToString());
                PlayerPrefs.Save();
            }
        }
        else
        {
            Debug.LogWarning($"Action '{actionName}' not found in Input Actions!");
        }
    }

    private InputAction GetActionByName(string actionName)
    {
        if (inputs.Camera.Movement != null)
        {
            if (actionName == "Up") return inputs.Camera.Up;
            if (actionName == "Down") return inputs.Camera.Down;
        }
        return inputs.Camera.Movement;
    }

    private int GetBindingIndex(InputAction action, string keyName)
    {
        for (int i = 0; i < action.bindings.Count; i++)
        {
            if (action.bindings[i].path.Contains("<Keyboard>"))
            {
                if (action.bindings[i].name.Equals(keyName, System.StringComparison.OrdinalIgnoreCase))
                    return i;
            }
        }
        return -1;
    }

    private void LoadKeyBindings()
    {
        foreach (string action in actionNames)
        {
            if (PlayerPrefs.HasKey($"Rebind_{action}"))
            {
                string savedKey = PlayerPrefs.GetString($"Rebind_{action}");
                if (System.Enum.TryParse(savedKey, out Key loadedKey))
                {
                    keyMappings[action] = loadedKey;
                    RebindKey(action, loadedKey);
                }
            }
        }
    }
}
