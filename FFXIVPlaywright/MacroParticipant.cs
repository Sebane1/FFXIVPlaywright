using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVPlaywright {
    public class MacroParticipant {
        string name;
        List<TimedDialogue> actions = new List<TimedDialogue>();
        int totalWaitTime = 0;
        List<int> totalWaitPerLine = new List<int>();
        int accumalatedTimeSinceLastLine = 0;
        public List<TimedDialogue> Actions {
            get => actions;
            set {
                actions = value;
            }
        }
        public string Name { get => name; set => name = value; }
        public int TotalWaits { get => totalWaitTime; set => totalWaitTime = value; }
        public List<int> TotalWaitPerLine { get => totalWaitPerLine; set => totalWaitPerLine = value; }
        public int AccumalatedTimeSinceLastLine { get => accumalatedTimeSinceLastLine; set => accumalatedTimeSinceLastLine = value; }
        public void AddLine(TimedDialogue timedDialogue) {
            if (actions.Count % 14 == 0 && actions.Count > 0) {
                actions.Add(new TimedDialogue { Value = @"/nextmacro (intended for macrochain plugin)" + "\r\n", IsLineBreak = true });
            }
            actions.Add(timedDialogue);
        }
    }
}
