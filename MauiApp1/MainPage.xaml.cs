namespace MauiApp1;
using IO.Ably;
using IO.Ably.Realtime;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

       
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
        //Establish connection to Ably
        var options = new ClientOptions();
        options.AutomaticNetworkStateMonitoring = false;
        //options.CaptureCurrentSynchronizationContext = true;
        //options.CustomContext = SynchronizationContext.Current;

        options.Key = "m3sDLg.SbtX_A:lIGdC-bS9Vp7Hu1kfyWjk_ImzKL5XBCyBERV426tykg";


        var ably = new AblyRealtime(options);

        ably.Connection.On(ConnectionEvent.Connected, args =>
        {
            Console.Out.WriteLine("Connected to Ably!");
        });

        //publish messages to a channel

        var channel = ably.Channels.Get("quickstart");
        channel.Publish("greeting", "hello!");

       
	}
}

