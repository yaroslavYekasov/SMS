namespace friends;

public partial class DBListPage : ContentPage
{
	public DBListPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        friendsList.ItemsSource = App.Database.GetItems();
        base.OnAppearing();
    }

    private async void friendsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Friend selectedFriend = (Friend)e.SelectedItem;
        DBFriendPage friendPage = new DBFriendPage();
        friendPage.BindingContext = selectedFriend;
        await Navigation.PushAsync(friendPage);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Friend friend = new Friend();
        DBFriendPage friendPage = new DBFriendPage();
        friendPage.BindingContext = friend;
        await Navigation.PushAsync(friendPage);
    }
}