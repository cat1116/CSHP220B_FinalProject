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
using CatApp.Models;

namespace CatApp
{
    /// <summary>
    /// Interaction logic for CatWindow.xaml
    /// </summary>
    public partial class CatWindow : Window
    {
        public CatWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        public CatModel Cat { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Cat != null)
            {
                if (Cat.Friendly == true)
                {
                    uxFriendlyYes.IsChecked = true;
                }
                else
                {
                    uxFriendlyNo.IsChecked = true;
                }

                if (Cat.EarTipped == true)
                {
                    uxEarTippedYes.IsChecked = true;
                }
                else
                {
                    uxEarTippedNo.IsChecked = true;
                }

                if (Cat.DeClawed == true)
                {
                    uxDeClawedYes.IsChecked = true;
                }
                else
                {
                    uxDeClawedNo.IsChecked = true;
                }

                if (Cat.MicroChipped == true)
                {
                    uxMicroChippedYes.IsChecked = true;
                }
                else
                {
                    uxMicroChippedNo.IsChecked = true;
                }

                if (Cat.SpayedNeutered == true)
                {
                    uxSpayedNeuteredYes.IsChecked = true;
                }
                else
                {
                    uxSpayedNeuteredNo.IsChecked = true;
                }

                if (Cat.Friendly == true)
                {
                    uxVaccinatedYes.IsChecked = true;
                }
                else
                {
                    uxVaccinatedNo.IsChecked = true;
                }




                uxSubmit.Content = "Update";
            }
            else
            {
                Cat = new CatModel();
            }

            uxGrid.DataContext = Cat;
        }

        private bool IsValid(DependencyObject obj)
        {
            //stackoverflow.com/questions/127477/detecting-wpf-validation-errors
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = IsValid(uxGrid);
           //if(Validation.GetHasError(uxName))
           if(!isValid)
            {
                //DialogResult = false;
                e.Handled = true;
                return;
            }
            //Cat = new CatModel();

            //Cat.Name = uxName.Text;

            //int age = 0;
            //if (uxAge.Text != null && uxAge.Text != string.Empty)
            //{
            //    int.TryParse(uxAge.Text, out age);

            //}
            //Cat.Age = age;

            //int weight = 0;
            //if (uxWeight.Text != null && uxWeight.Text != string.Empty)
            //{
            //    int.TryParse(uxWeight.Text, out weight);

            //}
            //Cat.Weight = weight;
            //Cat.Gender = uxGender.Text;
            //Cat.PrimaryColor = uxPrimaryColor.Text;
            //Cat.SecondaryColor = uxSecondaryColor.Text;
            //Cat.Breed = uxBreed.Text;

            if (uxFriendlyYes.IsChecked.Value)
            {
                Cat.Friendly = true;
            }
            else
            {
                Cat.Friendly = false;
            }

            if (uxEarTippedYes.IsChecked.Value)
            {
                Cat.EarTipped = true;
            }
            else
            {
                Cat.EarTipped = false;
            }

            if (uxDeClawedYes.IsChecked.Value)
            {
                Cat.DeClawed = true;
            }
            else
            {
                Cat.DeClawed = false;
            }

            if (uxMicroChippedYes.IsChecked.Value)
            {
                Cat.MicroChipped = true;
            }
            else
            {
                Cat.MicroChipped = false;
            }

            if (uxSpayedNeuteredYes.IsChecked.Value)
            {
                Cat.SpayedNeutered = true;
            }
            else
            {
                Cat.SpayedNeutered = false;
            }

            if (uxVaccinatedYes.IsChecked.Value)
            {
                Cat.Vaccinated = true;
            }
            else
            {
                Cat.Vaccinated = false;
            }

            //Cat.Comments = uxComments.Text;
            //Cat.Photo = string.Empty;

            //Cat.ColonyBorough = uxColonyBorough.Text;
            //Cat.ColonyNeighborhood = uxColonyNeighborhood.Text;
            //Cat.ColonyCaretakerName = uxColonyCaretakerName.Text;
            //Cat.ColonyCaretakerPhone = uxColonyCaretakerPhone.Text;


            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }

    }
}
