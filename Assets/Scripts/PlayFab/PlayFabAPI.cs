using PlayFab.ClientModels;
using PlayFab;
using TMPro;
using UnityEngine;

public class PlayFabAPI : MonoBehaviour
{
    public TMP_InputField emailInput;
    public string Email { get; set; }
    private LoginResult _loginResult;

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Username = "JDA",
            Password = "abc123",
            DisplayName = "IDB"
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("User registration succeeded for " + result.Username);
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.Log("Registration failed: " + error.ErrorMessage);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = "abc123"
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnAPICallFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        _loginResult = result;
        Debug.Log("Congratulations, you logged in successfully!");
    }

    private void OnAPICallFailure(PlayFabError error)
    {
        Debug.Log("API call failed: " + error.ErrorMessage);
    }

    public void GetAccountInfo()
    {
        if (_loginResult == null)
        {
            Debug.Log("Login required before getting account info.");
            return;
        }

        GetAccountInfoRequest request = new GetAccountInfoRequest { AuthenticationContext = _loginResult.AuthenticationContext };
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnAPICallFailure);
    }

    private void OnGetAccountInfoSuccess(GetAccountInfoResult result)
    {
        Debug.Log("GetAccountInfo Success " + result.AccountInfo.Username + result.AccountInfo.TitleInfo.DisplayName);
    }

    public void GetUserInventory()
    {
        if (_loginResult == null)
        {
            Debug.Log("Login required before getting user inventory.");
            return;
        }

        GetUserInventoryRequest request = new GetUserInventoryRequest { AuthenticationContext = _loginResult.AuthenticationContext };
        PlayFabClientAPI.GetUserInventory(request, OnGetUserInventorySuccess, OnAPICallFailure);
    }

    private void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        Debug.Log("Inventory: " + result.VirtualCurrency["GO"] + " gold");
        Debug.Log("Inventory: items ");
        foreach (ItemInstance ii in result.Inventory)
        {
            Debug.Log(ii.DisplayName);
        }
    }

    public void IncreasePlayerFunds()
    {
        if (_loginResult == null)
        {
            Debug.Log("Login required before increasing player funds.");
            return;
        }

        AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest
        {
            AuthenticationContext = _loginResult.AuthenticationContext,
            Amount = 100,
            VirtualCurrency = "GO"
        };

        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddUserVirtualCurrencySuccess, OnAPICallFailure);
    }

    private void OnAddUserVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Add virtual currency succeeded: " + result.Balance);
    }

    public void PurchaseExcalibur()
    {
        if (_loginResult == null)
        {
            Debug.Log("Login required before purchasing Excalibur.");
            return;
        }

        PurchaseItemRequest request = new PurchaseItemRequest
        {
            AuthenticationContext = _loginResult.AuthenticationContext,
            CatalogVersion = "PD4 items",
            ItemId = "PD4.1",
            Price = 100,
            VirtualCurrency = "GO"
        };

        PlayFabClientAPI.PurchaseItem(request, OnBuySuccess, OnAPICallFailure);
    }

    private void OnBuySuccess(PurchaseItemResult result)
    {
        Debug.Log("Purchase succeeded!");
        GetUserInventory();
    }
}
