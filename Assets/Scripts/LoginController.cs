using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRoidSDK;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    [SerializeField] SDKConfiguration sdkConfiguration;
    BrowserAuthorize browserAuthorize;

    [SerializeField] Text errMessageBox;
    public void Login()
    {
        Authentication.Instance.Init(sdkConfiguration.AuthenticateMetaData);
        Authentication.Instance.AuthorizeWithExistAccount((bool isAuthSuccess) =>
        {
            if (!isAuthSuccess)
            {
                browserAuthorize = BrowserAuthorize.GenerateInstance(sdkConfiguration);
                browserAuthorize.OpenBrowser(AfterAuth);
            }
            else
            {
                AfterAuth(true);
            }
        },
        (System.Exception error) => {
            errMessageBox.gameObject.SetActive(true);
            errMessageBox.text = "error:\n" + error.ToString();
        });
    }

    void AfterAuth(bool isRegistered)
    {
        SceneManager.LoadScene("Home");
    }

}
