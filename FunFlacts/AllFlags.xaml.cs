using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagData;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunFlacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllFlags : ContentPage
    {
        private FunFlactsViewModel flagsViewModel = DependencyService.Get<FunFlactsViewModel>();
        private bool editMode;
        public AllFlags()
        {
            InitializeComponent();
            EditButtonProperties();
            editMode = false;
            FlagListView.ItemsSource = flagsViewModel.Flags;
        }

        private void FlagListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (editMode)
            {
                var flag = (sender as ListView).SelectedItem as Flag;
                RemoveSelectedFlag(flag);
            }
            else
            {
                flagsViewModel.CurrentFlag = (sender as ListView).SelectedItem as Flag;
                Navigation.PushAsync(new FlagDetailsPage());
            }

        }

        private void RemoveSelectedFlag(Flag flag)
        {
            flagsViewModel.RemoveFlag(flag);
        }
        private void EditButtonProperties()
        {
            EditToolbar.Text = "Edit";
            EditToolbar.IconImageSource = "ic_edit.png";

        }

        private void CancelEditButtonProperties()
        {
            EditToolbar.Text = "Cancel Edit";
            EditToolbar.IconImageSource = "ic_cancel.png";
        }
        private void EditButton_OnClicked(object sender, EventArgs e)
        {
            editMode = !editMode;
            if (editMode)
            {
                CancelEditButtonProperties();
            }
            else
            {
                EditButtonProperties();
            }

        }
    }
}