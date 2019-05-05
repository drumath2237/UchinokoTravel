using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRoidSDK;

public class LoginUser : MonoBehaviour
{
    void Update()
    {
        string t = "new text";
        HubApi.GetAccount(
            (Account acount) =>
            {
                t = acount.user_detail.user.name + "としてログイン中";
                GetComponent<Text>().text = t;
            },
            (ApiErrorFormat error) => {
                t = error.message;
                GetComponent<Text>().text = t;
            }
        );

        
    }
}
