using System.Linq;
using LeagueBinding.Client.Common;
using LeagueBinding.Client.Models.Enums;

namespace LeagueBinding.Client.Models
{
    public class GameEvent
        : NotifyPropertyChanged
    {
        private readonly char[] _specialChars = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+' };
        private readonly char[] _unspecialChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-', '=' };

        public string GameEventValueLabel
        {
            get
            {
                if (IsLowerCaseLetter())
                {
                    return _gameEventValue.ToUpper();
                }
                if (IsShiftPressed())
                {
                    if (IsSpecialChar())
                    {
                        for (var i = 0; i < _specialChars.Length; i++)
                        {
                            var val = _gameEventValue.ToCharArray();
                            if (val.Length != 1) continue;
                            if (_specialChars[i] == val[0])
                            {
                                return "Shift\n" + _unspecialChars[i];
                            }
                        }
                    }
                    return "Shift\n" + _gameEventValue;
                }
                return _gameEventValue;
            }
        }

        public string ExportValue()
        {
            if (IsLowerCaseLetter())
            {
                return "[" + _gameEventValue.ToLower() + "]";
            }
            if (IsShiftPressed())
            {
                if (IsSpecialChar())
                {
                    for (var i = 0; i < _specialChars.Length; i++)
                    {
                        var val = _gameEventValue.ToCharArray();
                        if (val.Length != 1) continue;
                        if (_specialChars[i] == val[0])
                        {
                            return string.Format("[Shift][{0}]", _unspecialChars[i]);
                        }
                    }
                }
                return string.Format("[Shift][{0}]", _gameEventValue.ToLower());
            }
            return _gameEventValue;
        }

        private GameEventNames _gameEventName;
        public GameEventNames GameEventName
        {
            get { return _gameEventName; }
            set
            {
                _gameEventName = value;
                OnPropertyChanged();
            }
        }

        private string _gameEventValue;
        public string GameEventValue
        {
            get { return _gameEventValue; }
            set
            {
                _gameEventValue = value;
                OnPropertyChanged();
                OnPropertyChanged("GameEventValueLabel");
            }
        }

        private bool IsLowerCaseLetter()
        {
            var charArray = _gameEventValue.ToCharArray();
            if (charArray.Length == 1)
            {
                return charArray[0] >= 'a' && charArray[0] <= 'z';
            }
            return false;
        }

        private bool IsSpecialChar()
        {
            var charArray = _gameEventValue.ToCharArray();
            if (charArray.Length == 1)
            {
                return (_specialChars.Contains(charArray[0]));
            }
            return false;
        }

        private bool IsShiftPressed()
        {
            var charArray = _gameEventValue.ToCharArray();
            if (charArray.Length == 1)
            {
                return (_specialChars.Contains(charArray[0])) || (charArray[0] >= 'A' && charArray[0] <= 'Z');
            }
            return false;
        }
    }
}