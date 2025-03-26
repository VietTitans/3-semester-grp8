using AuctionServiceClientDesktop.ControlLayer;
using AuctionServiceClientDesktop.ModelLayer;

namespace AuctionServiceClientDesktop
{
    public partial class Form1 : Form
    {

        private readonly UserLogic _userLogic;

        public Form1()
        {
            InitializeComponent();

            _userLogic = new UserLogic();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void ButtonGetUsers_Click(object sender, EventArgs e)
        {
            string processText;
            List<User>? fetchedUsers = await _userLogic.GetAllUsers();
            if (fetchedUsers != null)
            {
                if (fetchedUsers.Count >= 1)
                {
                    processText = "Ok";
                }
                else
                {
                    processText = "No users found";
                }
            }
            else
            {
                processText = "Failure: An error occurred";
            }
            labelProcessText.Text = processText;
            listBoxUsers.DataSource = fetchedUsers;
        }

        private async void ButtonSaveUser_Click(object sender, EventArgs e)
        {
            string messageText;
            // Values from testboxes must be fetched
            string inUsername = textBoxUsername.Text;
            string inEmail = textBoxEmail.Text;
            // Evaluate and act accordingly
            if (InputIsOk(inUsername, inEmail))
            {
                // Call the ControlLayer to get the data saved
                int insertedId = await _userLogic.SaveUser(inUsername, inEmail);
                messageText = (insertedId > 0) ? $"User saved with no {insertedId}" : "Failure: An error occurred!";
            }
            else
            {
                messageText = "Please input valid informations";
            }
            // Finally put out a message saying if the saving went well 
            labelProcessSave.Text = messageText;
        }

        private bool InputIsOk(string username, string email)
        {
            bool isValidInput = false;
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(email))
            {
                if (username.Length > 1 && email.Length > 1)
                {
                    isValidInput = true;
                }
            }
            return isValidInput;
        }


    }
}
