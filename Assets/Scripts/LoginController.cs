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

    [SerializeField] string registercode;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            browserAuthorize.RegisterCode(registercode);
            //Login();
            AfterAuth(true);
        }
    }

    void AfterAuth(bool isRegistered)
    {
        SceneManager.LoadScene("Home");
    }

}
