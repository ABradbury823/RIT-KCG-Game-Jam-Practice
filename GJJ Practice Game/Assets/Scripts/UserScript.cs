using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class User
{
    public string name;
    public string occupation;
    [TextArea(5,10)]
    public string comment;
    public User[] connections;
    //UI panel to fill up
    public Sprite profilePic;
    public GameObject userConnectionsPanel;
}

public class UserScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Variables
    public User userInfo;
    [SerializeField] GameObject profilePanel;
    [SerializeField] GameObject commentBubble;
    [SerializeField] Text commentText;
    [SerializeField] Text nameText;

    private void Start()
    {
        commentText.text = userInfo.comment;
        nameText.text = userInfo.name;
    }

    /// <summary>
    /// Activates the Right or Left profilePanel and fills in the propper 
    ///     information about that user's connections
    /// </summary>
    public void enableProfilePanel()
    {
        if(!profilePanel.activeInHierarchy)
            GameManager.SharedInstance.Clicks++;

        profilePanel.SetActive(true);
        ProfilePanel panelInfo = profilePanel.GetComponent<ProfilePanel>();
        panelInfo.NameText = userInfo.name;
        panelInfo.OccupationText = userInfo.occupation;
        panelInfo.CommentText = userInfo.comment;

        // Fills in the connection information if available
        if(userInfo.connections[0] != null)
        {
            panelInfo.Contact1Text = userInfo.connections[0].name + " // " 
                + userInfo.connections[0].occupation + " // \"" + userInfo.connections[0].comment + "\"";
            panelInfo.Contact1Panel = userInfo.userConnectionsPanel;
        }
        if (userInfo.connections[1] != null)
        {
            panelInfo.Contact2Text = userInfo.connections[1].name + " // " 
                + userInfo.connections[1].occupation + " // \"" + userInfo.connections[1].comment + "\"";
            panelInfo.Contact2Panel = userInfo.userConnectionsPanel;
        }
        if (userInfo.connections[2] != null)
        {
            panelInfo.Contact3Text = userInfo.connections[2].name + " // " 
                + userInfo.connections[2].occupation + " // \"" + userInfo.connections[2].comment + "\"";
            panelInfo.Contact3Panel = userInfo.userConnectionsPanel;
        }
    }

    /// <summary>
    /// Pointer information for hoverables
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        commentBubble.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        commentBubble.SetActive(false);
    }
}
