using Candidate_BusinessObjects;
using Candidate_Services;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace CandidateManagement_Monday_Slot02
{
    /// <summary>
    /// Interaction logic for CandidateProfileManagement.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobService;
        private readonly int? RoleID;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            profileService = new CandidateProfileService();
            jobService = new JobPostingService();
        }
        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
            profileService = new CandidateProfileService();
            jobService = new JobPostingService();
            this.RoleID = roleID;
        }

        private void Window_Loaded_Candidate(object sender, RoutedEventArgs e)
        {
            switch (RoleID)
            {
                case 1:
                    break;
                case 2:
                    //Manager
                    this.btnAdd.IsEnabled = false;
                    this.btnDelete.IsEnabled = false;
                    this.btnUpdate.IsEnabled = false;
                    break;
                case 3:
                    //Staff
                    this.btnAdd.IsEnabled = false;
                    this.btnDelete.IsEnabled = false;
                    this.btnUpdate.IsEnabled = false;
                    break;
                default:
                    break;
            }
            this.LoadDataInit();
        }

        private void LoadDataInit()
        {
            this.dgData.ItemsSource = null;
            this.dgData.ItemsSource = profileService.GetCandidates();
            this.cboJobPosting.ItemsSource = jobService.GetJobPostings();
            this.cboJobPosting.DisplayMemberPath = "JobPostingTitle";
            this.cboJobPosting.SelectedValuePath = "PostingId";
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem != null)
            {
                CandidateProfile candidateProfile = dgData.SelectedItem as CandidateProfile;

                if (candidateProfile != null)
                {
                    txtCandidateID.Text = candidateProfile.CandidateId;
                    txtFullName.Text = candidateProfile.Fullname;
                    dpDate.SelectedDate = candidateProfile.Birthday;
                    txtDescription.Text = candidateProfile.ProfileShortDescription;
                    txtImage.Text = candidateProfile.ProfileUrl;
                    cboJobPosting.SelectedValue = candidateProfile.PostingId;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new CandidateProfile
            {
                CandidateId = txtCandidateID.Text,
                Fullname = txtFullName.Text,
                Birthday = dpDate.SelectedDate,
                ProfileShortDescription = txtDescription.Text,
                ProfileUrl = txtImage.Text,
                PostingId = cboJobPosting.SelectedValue.ToString()
            };

            if (profileService.AddCandidateProfile(candidateProfile))
            {
                MessageBox.Show("Add successful");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string candidateID = txtCandidateID.Text;
            if (!string.IsNullOrEmpty(candidateID) 
                && profileService.DeleteCandidateProfile(candidateID))
            {
                this.LoadDataInit();
                MessageBox.Show("Delete Successful");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new CandidateProfile
            {
                CandidateId = txtCandidateID.Text,
                Fullname = txtFullName.Text,
                Birthday = dpDate.SelectedDate ?? DateTime.Now,
                ProfileShortDescription = txtDescription.Text,
                ProfileUrl = txtImage.Text,
                PostingId = cboJobPosting.SelectedValue.ToString()
            };

            if (profileService.UpdateCandidateProfile(candidateProfile))
            {
                MessageBox.Show("Update successful");
                this.LoadDataInit();
            }
        }

        private void btnJobPosting_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            JobPostingWindow jobPosting = new JobPostingWindow(RoleID);
            jobPosting.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string name = txtSearchName.Text.ToLower();
            dgData.ItemsSource = profileService.SearchByName(name);
        }
    }
}
