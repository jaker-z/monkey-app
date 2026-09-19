namespace MonkeyFinder.ViewModel;

[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    public MonkeyDetailsViewModel()
    {
        
    }

    [ObservableProperty]
    Monkey monkey;


    [RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");

        // If you want to pass parameters through the above method:
        //int userID = 0;
        //string status = "Active";
        //await Shell.Current.GoToAsync($"..?Id={userID}&Status={status}");
    }

}
