using System.Formats.Asn1;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using TickTackToes.GameLoopLogic;


namespace TickTackToes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        GameLogic _GameLogic = new GameLogic();

        private void ComputerAction()
        {
            if (_GameLogic.CurrentPlayer == "O")
            {
                var button = new Button();
                //UIElementAutomationPeer.CreatePeerForElement(button);
                //ButtonAutomationPeer peer = new ButtonAutomationPeer(button);
                //IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                //invokeProv.Invoke();
                Button[] buttons = { Grid1, Grid2, Grid3, Grid4, Grid5, Grid6, Grid7, Grid8, Grid9 };
                //var ClickLocation = _GameLogic.ComputerClick();
                Random rand = new Random();
               
                foreach (var item in buttons)
                {
                    button = buttons[rand.Next(9)];
                    if (button.Content == null || button.Content == String.Empty)
                    {
                        button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                        var cordinates = button.Tag.ToString().Split(',');
                        var xValue = int.Parse(cordinates[0]);
                        var yValue = int.Parse(cordinates[1]);
                        var buttonPosition = new Position() { x = xValue, y = yValue };

                        _GameLogic.UpdateBoard(buttonPosition, _GameLogic.CurrentPlayer);
                        break;
                    }
                }       
            }
            _GameLogic.SetNextPlayer();
        }

        private void PlayerClickSpace(object sender, RoutedEventArgs e)
        {
            //This is the button that the player clicked on and it sends back the button data.
            //if the space content is not filled it makes the content the same as the current player which if it is the player it becomes an X
            var space = (Button)sender;
            if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
            space.Content = _GameLogic.CurrentPlayer;

            //Gets what position was clicked based on tags and Position class, so grid 0,0 to 2,2 where 1,1 is the middle of the grid. Sadly 0,0 is grid 7 and 2,2 is grid 3. AKA first number is collumn and the second is the row, so 0,0 is grid 7, 0,1 is grid 4 and 0,2 is grid 1.
            //We also split the incomming tag so that we get the two numbers so 0,1 becomes actually x = 0 and y = 1.
            var cordinates = space.Tag.ToString().Split(',');
            var xValue = int.Parse(cordinates[0]);
            var yValue = int.Parse(cordinates[1]);
            var buttonPosition = new Position() { x = xValue, y = yValue };

            _GameLogic.UpdateBoard(buttonPosition, _GameLogic.CurrentPlayer);

            if (_GameLogic.WinCondition())
            {
                WinScreen.Text = $"{_GameLogic.CurrentPlayer} Wins!!!";
                WinScreen.Visibility = Visibility.Visible;
            }
            else
            {
                _GameLogic.SetNextPlayer();
                Thread.Sleep(100);
                ComputerAction();
                Thread.Sleep(100);
            }
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            foreach (var control in GridBoard.Children)
            {
                if (control is Button)
                {
                    ((Button)control).Content = String.Empty;
                }
            }
            _GameLogic = new GameLogic();
            WinScreen.Visibility = Visibility.Collapsed;
        }

    }
}
