using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRoidSDK;
using UnityEngine.Networking;

public class ModelSelectManager : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject characterModelPanel;

    List<CharacterModel> charactersmodels;
    List<Texture> textures;

    void Start()
    {
        getCharacters();
    }

    private void Awake()
    {
        //getCharacters();
    }

    void getCharacters()
    {
        HubApi.GetAccountCharacterModels(
            count: 10,
            onSuccess: (List<CharacterModel> cha_) =>
            {
                foreach (var ch_ in cha_)
                {
                    GetSumbnail(ch_);

                }

            },
            onError: (ApiErrorFormat error) =>
            {
                Debug.Log(error.ToString());
            }
        );
    }

    private IEnumerator GetSumbnail(CharacterModel model)
    {
        var url = model.portrait_image.sq300.url;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        Instantiate(characterModelPanel, content.transform);

        yield return www.SendWebRequest();

        Instantiate(characterModelPanel, content.transform);


        if (www.isNetworkError || www.isHttpError)
            Debug.Log(www.error);
        else
        {
            var panel = Instantiate(characterModelPanel, content.transform);
            panel.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(www);
            panel.transform.GetChild(1).gameObject.GetComponent<Text>().text = model.name;
        }

    }
}
