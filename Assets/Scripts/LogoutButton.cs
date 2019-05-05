using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRoidSDK;
using UnityEngine.SceneManagement;

public class LogoutButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Authentication.Instance.Logout();
        SceneManager.LoadScene("Login");
    }
}
