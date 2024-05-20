namespace friends;

public partial class DBFriendPage : ContentPage
{
	public DBFriendPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var friend = (Friend)BindingContext;
        if (!String.IsNullOrEmpty(friend.Name))
        {
            App.Database.SaveItem(friend);
        }
        this.Navigation.PopAsync();
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        var friend = (Friend)BindingContext;
        App.Database.DeleteItem(friend.Id);
        this.Navigation.PopAsync();
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        this.Navigation.PopAsync();
    }
}