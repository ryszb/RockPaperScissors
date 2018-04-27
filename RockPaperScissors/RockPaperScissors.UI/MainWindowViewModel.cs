using System.Collections.Generic;

using RockPaperScissors.Logic;

using static RockPaperScissors.Logic.Gesture;
using static RockPaperScissors.UI.PlayerType;

namespace RockPaperScissors.UI
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IReadOnlyCollection<Gesture> _gestures = new List<Gesture>
        {
            Rock, Paper, Scissors, Lizard, Spock
        };

        private Game _game;

        public PlayerType PlayerOneTypeChosen { get; set; }

        public PlayerType PlayerTwoTypeChosen { get; set; }

        public IReadOnlyList<PlayerSelection> PlayersSelection => new List<PlayerSelection>
        {
            new PlayerSelection { PlayerType = Human, Content = "Human player" },
            new PlayerSelection { PlayerType = Computer, Content = "Computer" },
            new PlayerSelection { PlayerType = TacticalComputer, Content = "Tactical computer" }
        };

        public int MaxRoundsChosen { get; set; }

        public IReadOnlyList<MaxRoundSelection> RoundsSelection => new List<MaxRoundSelection>
        {
            new MaxRoundSelection { MaxRoundsNumber = 3, Content = "Best of 3" },
            new MaxRoundSelection { MaxRoundsNumber = 5, Content = "Best of 5" },
            new MaxRoundSelection { MaxRoundsNumber = 7, Content = "Best of 7" },
            new MaxRoundSelection { MaxRoundsNumber = 9, Content = "Best of 9" }
        };

        public int PlayerOneScore => _game?.PlayerOneScore ?? 0;

        public int PlayerTwoScore => _game?.PlayerTwoScore ?? 0;

        public bool PlayerOneReady => _game?.PlayerOne.Ready ?? false;

        public bool PlayerTwoReady => (_game?.PlayerTwo.Ready ?? false) && PlayerOneReady;

        public Gesture PlayerOneLastMove => _game.PlayerOne.PreviousGesture;

        public Gesture PlayerTwoLastMove => _game.PlayerTwo.PreviousGesture;

        public bool ReadyToThrow => _game?.CanThrow ?? false;

        public bool GameActive => _game != null && !_game.PlayerOneIsAWinner && !_game.PlayerTwoIsAWinner;

        public bool GameInactive => !GameActive;

        public string PlayerWins
        {
            get
            {
                if (_game.PlayerOneIsAWinner)
                {
                    return "Player One Wins!";
                }

                if (_game.PlayerTwoIsAWinner)
                {
                    return "Player Two Wins!";
                }

                return string.Empty;
            }
        }

        public Command ChooseRockCommand { get; }

        public Command ChoosePaperCommand { get; }

        public Command ChooseScissorsCommand { get; }

        public Command ChooseLizardCommand { get; }

        public Command ChooseSpockCommand { get; }

        public Command StartGameCommand { get; }

        public Command ThrowCommand { get; }


        public MainWindowViewModel()
        {
            ChooseRockCommand = new Command(() => GameActive && !ReadyToThrow, () => ChooseGesture(Rock));
            ChoosePaperCommand = new Command(() => GameActive && !ReadyToThrow, () => ChooseGesture(Paper));
            ChooseScissorsCommand = new Command(() => GameActive && !ReadyToThrow, () => ChooseGesture(Scissors));
            ChooseLizardCommand = new Command(() => GameActive && !ReadyToThrow, () => ChooseGesture(Lizard));
            ChooseSpockCommand = new Command(() => GameActive && !ReadyToThrow, () => ChooseGesture(Spock));
            StartGameCommand = new Command(() => GameInactive, StartGame);
            ThrowCommand = new Command(() => ReadyToThrow, Throw);

            MaxRoundsChosen = 3;
            PlayerOneTypeChosen = Human;
            PlayerTwoTypeChosen = Human;
        }

        public void StartGame()
        {
            _game = new Game(
                CreatePlayer(PlayerOneTypeChosen),
                CreatePlayer(PlayerTwoTypeChosen),
                MaxRoundsChosen);

            SendNotifications();
        }

        private Player CreatePlayer(PlayerType type)
        {
            switch (type)
            {
                case Human:
                    return new HumanPlayer();
                case Computer:
                    return new ComputerPlayer(_gestures, new RandomNumberGenerator());
                case TacticalComputer:
                    return new TacticalComputerPlayer(_gestures, new RandomNumberGenerator());
                default:
                    return new HumanPlayer();
            }
        }

        public void ChooseGesture(Gesture gesture)
        {
            _game.SetPlayerGesture(gesture);

            SendNotifications();
        }

        public void Throw()
        {
            _game.Throw();

            SendNotifications();
        }

        private void SendNotifications()
        {
            RaisePropertyChangedEvent(nameof(ReadyToThrow));
            RaisePropertyChangedEvent(nameof(PlayerOneScore));
            RaisePropertyChangedEvent(nameof(PlayerTwoScore));
            RaisePropertyChangedEvent(nameof(PlayerOneReady));
            RaisePropertyChangedEvent(nameof(PlayerTwoReady));
            RaisePropertyChangedEvent(nameof(GameActive));
            RaisePropertyChangedEvent(nameof(GameInactive));
            RaisePropertyChangedEvent(nameof(PlayerWins));
            RaisePropertyChangedEvent(nameof(PlayerOneLastMove));
            RaisePropertyChangedEvent(nameof(PlayerTwoLastMove));
        }
    }

    public class MaxRoundSelection
    {
        public int MaxRoundsNumber { get; set; }

        public string Content { get; set; }
    }

    public class PlayerSelection
    {
        public PlayerType PlayerType { get; set; }

        public string Content { get; set; }
    }

    public enum PlayerType
    {
        Human,
        Computer,
        TacticalComputer
    }
}
