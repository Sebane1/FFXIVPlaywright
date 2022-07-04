using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVPlaywright {
    public class TimedDialogue {
        string name;
        int wait;
        string value;
        bool issueDetected;
        bool isLineBreak;
        public string Value {
            get => value; set {
                issueDetected = value.Length > 170;
                this.value = value;
            }
        }
        public int Wait { get => wait; set => wait = value; }
        public string Name { get => name; set => name = value; }
        public bool IsLineBreak { get => isLineBreak; set => isLineBreak = value; }
        public bool IssueDetected { get => issueDetected; set => issueDetected = value; }

        public override string ToString() {
            return Value + (IsLineBreak || wait == 0 ? "" : $"<wait.{wait}>");
        }
    }
}
