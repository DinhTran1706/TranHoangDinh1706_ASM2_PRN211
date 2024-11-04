using Candidate_BusinessObjects;
using Candidate_Services;
using System.Windows;

namespace CandidateManagement_Monday_Slot02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService iAccountService;
        public MainWindow()
        {
            InitializeComponent();
            iAccountService = new HRAccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iAccountService
                .GetHraccountByEmail(txtEmail.Text.Trim());
            if (hraccount != null && txtPassword.Password
                .Equals(hraccount.Password))
            {
                int? roleID = hraccount.MemberRole;
                switch (roleID)
                {
                    case 1:
                        this.Hide();
                        CandidateProfileWindow candForm = new CandidateProfileWindow(roleID);
                        candForm.Show();
                        break;
                    case 2:
                        this.Hide();
                        CandidateProfileWindow managerCandidate = new CandidateProfileWindow(roleID);
                        managerCandidate.Show();
                        break;
                    case 3: 
                        this.Hide();
                        CandidateProfileWindow staffCandidate = new CandidateProfileWindow(roleID);
                        staffCandidate.Show();
                        break;
                    default: 
                        break;
                }
                
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}