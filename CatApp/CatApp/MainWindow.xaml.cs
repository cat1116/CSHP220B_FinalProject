using CatApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GridViewColumnHeader listViewSortCol = null;
        private ListSortDirection listViewSortDir = ListSortDirection.Ascending;

        public MainWindow()
        {
            InitializeComponent();
            LoadCats();
        }

        private CatModel selectedCat;

        private void LoadCats()
        {
            var cats = App.CatRepository.GetAll();

            uxCatList.ItemsSource = cats
                .Select(t => CatModel.ToModel(t))
                .ToList();

        }


        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new CatWindow();

            if (window.ShowDialog() == true)
            {
                var uiCatModel = window.Cat;

                var repositoryCatModel = uiCatModel.ToRepositoryModel();

                App.CatRepository.Add(repositoryCatModel);

                LoadCats();

            }
        }
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new CatWindow();
            window.Cat = selectedCat.Clone();

            if (window.ShowDialog() == true)
            {
                App.CatRepository.Update(window.Cat.ToRepositoryModel());
                LoadCats();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedCat != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.CatRepository.Remove(selectedCat.Id);
            selectedCat = null;
            LoadCats();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedCat != null);
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;

        }

        private void UxCatList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCat = (CatModel)uxCatList.SelectedValue;
        }

        private void UxCatList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object o = e.OriginalSource;
            if (o != null)
            {
                selectedCat = (((FrameworkElement)e.OriginalSource).DataContext as CatModel);
                //When the user double clicked the header this event was triggered but, there was no selected row so the selectedCat was null.
                //If you pass a null selectedCat to the change handler it will throw an exception. 
                if (selectedCat != null)
                {
                    uxFileChange_Click(null, null);
                }
            }


        }

        private void uxCatListColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //Get column to sort by.
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();

            //Reset sort.
            if (listViewSortCol != null)
            {
                uxCatList.Items.SortDescriptions.Clear();
            }

            //Default sort direction is ascending.
            ListSortDirection newDir = ListSortDirection.Ascending;

            //Check current sort direction, and change sort direction to descending if current direction is ascending.
            if (listViewSortDir == ListSortDirection.Ascending)
            {
                newDir = ListSortDirection.Descending;

            }

            //Store new sort values.
            listViewSortCol = column;
            listViewSortDir = newDir;

            //Do the sort.
            uxCatList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

    }
}
