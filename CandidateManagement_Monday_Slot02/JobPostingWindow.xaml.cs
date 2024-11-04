using Candidate_BusinessObjects;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_Monday_Slot02
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private readonly IJobPostingService jobPostingService;
        private readonly int? RoleID;

        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
        }

        public JobPostingWindow(int? roleID)
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
            this.RoleID = roleID;
        }

        private void LoadDataInit()
        {
            this.dgJobPosting.ItemsSource = null;
            this.dgJobPosting.ItemsSource = jobPostingService.GetJobPostings();
        }

        private void Window_Loaded_Job(object sender, RoutedEventArgs e)
        {
            switch (RoleID)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    this.btnAdd.IsEnabled = false;
                    this.btnDelete.IsEnabled = false;
                    this.btnUpdate.IsEnabled = false;
                    break;
                default:
                    break;
            }
            this.LoadDataInit();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new JobPosting
            {
                PostingId = txtPostID.Text,
                PostedDate = dpDate.SelectedDate,
                Description = txtDescription.Text,
                JobPostingTitle = txtTitle.Text,
            };

            if (jobPostingService.AddJobPosting(jobPosting))
            {
                MessageBox.Show("Add successful");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void dgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgJobPosting.SelectedItem != null)
            {
                JobPosting jobPosting = dgJobPosting.SelectedItem as JobPosting;

                if (jobPosting != null)
                {
                    txtPostID.Text = jobPosting.PostingId;
                    txtTitle.Text = jobPosting.JobPostingTitle;
                    dpDate.SelectedDate = jobPosting.PostedDate;
                    txtDescription.Text = jobPosting.Description;
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new JobPosting
            {
                PostingId = txtPostID.Text,
                PostedDate = dpDate.SelectedDate,
                Description = txtDescription.Text,
                JobPostingTitle = txtTitle.Text,
            };
            if (jobPostingService.UpdateJobPosting(jobPosting))
            {
                this.LoadDataInit();
                MessageBox.Show("Update successful");
            }
            else
            {
                MessageBox.Show("Something goes wrong");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string id = txtPostID.Text;
            if(!string.IsNullOrEmpty(id) && jobPostingService.DeleteJobPosting(id))
            {
                this.LoadDataInit();
                MessageBox.Show("Delete Successfully");
            }
            else
            {
                MessageBox.Show("Something goes wrong");
            }
        }

        private void btnCandidateProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CandidateProfileWindow candidateProfileWindow = new CandidateProfileWindow(RoleID);
            candidateProfileWindow.Show();
        }
    }
}
