using MonkeyFinder.Services;
using System.Threading.Tasks;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        Spece = "Frece";
        this.monkeyService = monkeyService;
    }


    [RelayCommand]
    async Task GoToDetailsAsync(Monkey monkey)
    {
        await Shell.Current.DisplayAlertAsync("Something!", $"Monkey: {monkey.Name}\nLocation: {monkey.Location}", "OK");

        if (monkey is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Monkey", monkey}
            });


    }


    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;
        
        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();

            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlertAsync("Error!", $"Unable to get monkeys: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
