using Plugin.Media;
using Plugin.Permissions;
using practice_3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace practice_3.ViewModels
{
    class ContactFieldsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand EditContactCommand { get; set; }

        public ICommand TakePicture { get; set; }
        public ICommand PickPictureFromGallery { get; set; }

        public Contact contact { get; set; }
            
        public string ProfileImg { get; set; }
        public ContactFieldsViewModel(Contact current_contact = null)
        {
            string actionCommand = "";
            if (current_contact == null)
            {
                actionCommand = "AddContact";
                contact = new Contact();
                ProfileImg = "contact_placeholder.png";
            } else
            {
                actionCommand = "EditContact";
                contact = current_contact;
                ProfileImg = contact.PicturePath;
                if (String.IsNullOrEmpty(contact.PicturePath))
                    ProfileImg  = "contact_placeholder.png";
            }

            TakePicture = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("No Camera", "No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;
                contact.PicturePath = file.Path;
                ProfileImg = file.Path;
            });

            PickPictureFromGallery = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                    return;

                contact.PicturePath = file.Path;
                ProfileImg = file.Path;
            });

            EditContactCommand = new Command(async () =>
            {
                MessagingCenter.Send<string, Contact>("Contacts", actionCommand, contact);

                await App.Current.MainPage.Navigation.PopAsync();
            });

        }
    }
}
