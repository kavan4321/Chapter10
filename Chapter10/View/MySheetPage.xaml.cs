using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.ApplicationModel;
using The49.Maui.BottomSheet;

namespace Chapter10.View;

public partial class MySheetPage : BottomSheet
{
    public MySheetPage()
    {
        InitializeComponent();
    }

    private async void CameraClicked(object sender, EventArgs e)
    {
        PermissionStatus permissionStatus = await CheckPermissionStatus();
        if (permissionStatus == PermissionStatus.Granted)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
        }
       

    }

    private async void GalleryClicked(object sender, EventArgs e)
    {
        PermissionStatus permissionStatus = await CheckPermissionGalleryStatus();
        if (permissionStatus == PermissionStatus.Granted)
        {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);
                }
            
        }
    }

    private void CancelClicked(object sender, EventArgs e)
    {


    }


    private async Task<PermissionStatus> CheckPermissionStatus()
    {
        PermissionStatus _permissionStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();
        try
        {          
            if (_permissionStatus != PermissionStatus.Granted)
            {
                bool shouldShowRationale =Permissions.ShouldShowRationale<Permissions.Camera>();
                if (shouldShowRationale)
                {
                     ShowRationaleDialog();
                }
                _permissionStatus = await Permissions.RequestAsync<Permissions.Camera>();
                if (_permissionStatus != PermissionStatus.Granted)
                {
                    shouldShowRationale =
                   Permissions.ShouldShowRationale<Permissions.Camera>();
                    if (!shouldShowRationale)
                    {
                         NavigateToAppSettings();
                    }
                    return _permissionStatus;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return _permissionStatus;
    }
    private void ShowRationaleDialog()
    {
        Toast.Make("Camera Permission Required", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        //bool result= await DisplayAlert("Camera Permission Required","This permission is needed to capture photos","Ok");
    }

    private async Task<PermissionStatus> CheckPermissionGalleryStatus()
    {
        PermissionStatus _permissionStatus = await Permissions.CheckStatusAsync<Permissions.Photos>();
        try
        {
            if (_permissionStatus != PermissionStatus.Granted)
            {
                bool shouldShowRationale = Permissions.ShouldShowRationale<Permissions.Photos>();
                if (shouldShowRationale)
                {
                    ShowRationaleGalleryDialog();
                }
                _permissionStatus = await Permissions.RequestAsync<Permissions.Photos>();
                if (_permissionStatus != PermissionStatus.Granted)
                {
                    shouldShowRationale =
                   Permissions.ShouldShowRationale<Permissions.Photos>();
                    if (!shouldShowRationale)
                    {
                        NavigateToAppSettings();
                    }
                    return _permissionStatus;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return _permissionStatus;
    }
    private void ShowRationaleGalleryDialog()
    {
        Toast.Make("Photo Permission Required", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        //bool result= await DisplayAlert("Camera Permission Required","This permission is needed to capture photos","Ok");
    }
    private void NavigateToAppSettings()
    {      
            AppInfo.ShowSettingsUI();       
    }


}

