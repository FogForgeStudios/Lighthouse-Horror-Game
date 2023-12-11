using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text chatText;

    // Start is called before the first frame update
    void Start()
    {
        // If you have any other initialization logic, you can place it here
    }

    // Call this method to update the chat with a new message
    public void UpdateChat(string message)
    {
        chatText.text += "\n" + message; // Add a new line for each message
    }

    // Method to clear the chat text
    public void ClearChat()
    {
        chatText.text = string.Empty;
    }

    // Method to display a single message in the chat
    public void DisplayMessage(string message)
    {
        ClearChat(); // Clear previous messages
        UpdateChat(message);
    }

    // Method to display a series of messages in the chat
    public void DisplayMessages(string[] messages)
    {
        ClearChat(); // Clear previous messages

        foreach (var message in messages)
        {
            UpdateChat(message);
        }
    }

    // Method to display a welcome message
    public void DisplayWelcomeMessage()
    {
        string[] welcomeMessages = {
            "Hello there! Welcome to the lighthouse.",
            "We've been having some strange occurrences, and we need you to watch over the lighthouse for a while. " +
            "Please look around and familiarize yourself with the lighthouse and home provided for your stay."
        };

        DisplayMessages(welcomeMessages);
    }
}
