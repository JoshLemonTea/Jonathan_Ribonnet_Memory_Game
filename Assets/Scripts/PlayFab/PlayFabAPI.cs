using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayFabAPI : MonoBehaviour
{
    public string Email { get; set; } //bound to ifEmail

    #region register

    public void Register() //bound to btnRegister
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = Email.Trim(),
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

    #endregion

    #region login

    private LoginResult _loginResult;

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = Email.Trim(),
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

    #endregion

    #region accountinfo


    private void GetAccountInfo()
    {
        GetAccountInfoRequest request = new GetAccountInfoRequest { AuthenticationContext = _loginResult.AuthenticationContext };
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnAPICallFailure);
    }



    private void OnGetAccountInfoSuccess(GetAccountInfoResult result)
    {
        Debug.Log("GetAccountInfo Success " + result.AccountInfo.Username + result.AccountInfo.TitleInfo.DisplayName);
    }

    #endregion

    #region user inventory



    private void GetUserInventory()

    {
        GetUserInventoryRequest request = new GetUserInventoryRequest { AuthenticationContext = _loginResult.AuthenticationContext };
        PlayFabClientAPI.GetUserInventory(request, OnGetUserInventorySuccess, OnAPICallFailure);
    }



    private void OnGetUserInventorySuccess(GetUserInventoryResult result)

    {
        Debug.Log("inventory: " + result.VirtualCurrency["GO"] + " gold");

        Debug.Log("inventory: items ");

        foreach (ItemInstance ii in result.Inventory)
        {
            Debug.Log(ii.DisplayName);
        }
    }

    #endregion

    #region sponsor

    public void IncreasePlayerFunds()

    {

        AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest

        { AuthenticationContext = _loginResult.AuthenticationContext, Amount = 100, VirtualCurrency = "GO" };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddUserVirtualCurrencySuccess, OnAPICallFailure);
    }



    private void OnAddUserVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)

    {

        Debug.Log("Add virtual currency succeeded:" + result.Balance);

    }

    #endregion

    public void PurchaseExcalibur()

    {

        PurchaseItemRequest request = new PurchaseItemRequest
        {
            AuthenticationContext = _loginResult.AuthenticationContext,
            CatalogVersion = "PD4",
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
