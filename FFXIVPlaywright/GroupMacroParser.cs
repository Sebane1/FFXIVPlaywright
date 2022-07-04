using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypingConnector;

namespace FFXIVPlaywright {
    public class GroupMacroParser {
        Dictionary<string, MacroParticipant> participants = new Dictionary<string, MacroParticipant>();
        List<TimedDialogue> timedDialogues = new List<TimedDialogue>();
        private bool insideDialogue;
        private string currentDialogue;
        private string currentAction;
        private int accumulatedWaitTimeForCurrentLine;
        private int totalAccumulatedWaitTime;
        private int waitTimeForCurrentEvent;
        private string textToParse;

        public Dictionary<string, MacroParticipant> Participants {
            get => participants;
            set => participants = value;
        }
        public List<TimedDialogue> TimedDialogues { get => timedDialogues; set => timedDialogues = value; }

        public void ParseScript(string text, bool eraseQutationsInMacro) {
            insideDialogue = false;
            currentDialogue = "";
            currentAction = "";
            accumulatedWaitTimeForCurrentLine = 0;
            totalAccumulatedWaitTime = 0;
            waitTimeForCurrentEvent = 0;
            participants.Clear();
            totalAccumulatedWaitTime = 0;
            textToParse = text;
            using (StringReader reader = new StringReader(text.Replace("(", null).Replace(")", null))) {
                string input = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(input)) {
                    Tokenizer tokenizer = new Tokenizer(input);
                    string newToken = tokenizer.GetToken();
                    if (newToken.Contains(":")) {
                        string name = newToken.TrimEnd(new char[] { ':' });
                        if (!participants.ContainsKey(name)) {
                            participants.Add(name, new MacroParticipant() { Name = name });
                            if (totalAccumulatedWaitTime > 0) {
                                participants[name].AddLine(new TimedDialogue() { Wait = totalAccumulatedWaitTime });
                            }
                        } else {
                            if (participants[name].AccumalatedTimeSinceLastLine > 0) {
                                participants[name].Actions[participants[name].Actions.Count - 1].Wait += participants[name].AccumalatedTimeSinceLastLine;
                                participants[name].AccumalatedTimeSinceLastLine = 0;
                            }
                        }
                        string token = tokenizer.GetToken();
                        while (!string.IsNullOrWhiteSpace(token)) {
                            if (token.Contains(@"""")) {
                                insideDialogue = !insideDialogue;
                                if (!insideDialogue) {
                                    currentDialogue += (!eraseQutationsInMacro ? token : token.Replace(@"""", null)) + " ";
                                    participants[name].AddLine(new TimedDialogue() { Value = currentDialogue });
                                    currentDialogue = "";
                                } else {
                                    currentDialogue += (!eraseQutationsInMacro ? token : token.Replace(@"""", null)) + " ";
                                    if (token.EndsWith(@"""")) {
                                        participants[name].AddLine(new TimedDialogue() { Value = currentDialogue });
                                        currentDialogue = "";
                                        insideDialogue = false;
                                    }
                                }
                            } else {
                                if (insideDialogue) {
                                    currentDialogue += token + " ";
                                } else {
                                    if (token.Contains("<wait.")) {
                                        int wait = int.Parse(token.Replace("<wait.", null).Replace(">", null));
                                        accumulatedWaitTimeForCurrentLine += wait;
                                        participants[name].Actions[participants[name].Actions.Count - 1].Wait += accumulatedWaitTimeForCurrentLine;
                                    } else if (token.Contains("/")) {
                                        participants[name].AddLine(new TimedDialogue() { Value = token.ToLower() + " " });
                                    } else if (participants[name].Actions[participants[name].Actions.Count - 1].Value.Contains("/")) {
                                        participants[name].Actions[participants[name].Actions.Count - 1].Value += token + " ";
                                    } else {
                                        currentAction += token + " ";
                                    }
                                }
                            }
                            token = tokenizer.GetToken();
                        }
                        //if (!string.IsNullOrWhiteSpace(currentAction)) {
                        //    if (!currentAction.Contains("<wait.")) {
                        //        participants[name].Actions.Add(currentAction + "<wait.1>");
                        //        currentAction = null;
                        //    }
                        //}
                        currentAction = null;
                        currentDialogue = null;
                        totalAccumulatedWaitTime += accumulatedWaitTimeForCurrentLine;
                        participants[name].TotalWaitPerLine.Add(accumulatedWaitTimeForCurrentLine);
                        participants[name].TotalWaits += accumulatedWaitTimeForCurrentLine;
                        foreach (MacroParticipant macroParticipant in participants.Values) {
                            if (macroParticipant.Name != name) {
                                macroParticipant.AccumalatedTimeSinceLastLine += accumulatedWaitTimeForCurrentLine;
                            }
                        }
                        accumulatedWaitTimeForCurrentLine = 0;
                    }
                    input = reader.ReadLine();
                }
            }
        }
        public void ParseScriptForSimulation(string text, bool eraseQutationsInMacro) {
            timedDialogues.Clear();
            accumulatedWaitTimeForCurrentLine = 0;
            totalAccumulatedWaitTime = 0;
            waitTimeForCurrentEvent = 0;
            totalAccumulatedWaitTime = 0;
            textToParse = text;
            using (StringReader reader = new StringReader(text.Replace("(", null).Replace(")", null))) {
                string input = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(input)) {
                    Tokenizer tokenizer = new Tokenizer(input);
                    string newToken = tokenizer.GetToken();
                    if (newToken.Contains(":")) {
                        string name = newToken.TrimEnd(new char[] { ':' });
                        string token = tokenizer.GetToken();
                        while (!string.IsNullOrWhiteSpace(token)) {
                            if (token.Contains(@"""")) {
                                insideDialogue = !insideDialogue;
                                if (!insideDialogue) {
                                    currentDialogue += (!eraseQutationsInMacro ? token : token.Replace(@"""", null)) + " ";
                                    timedDialogues.Add(new TimedDialogue() { Name = name, Value = currentDialogue });
                                    currentDialogue = "";
                                } else {
                                    currentDialogue += (!eraseQutationsInMacro ? token : token.Replace(@"""", null)) + " ";
                                    if (token.EndsWith(@"""")) {
                                        timedDialogues.Add(new TimedDialogue() { Name = name, Value = currentDialogue });
                                        currentDialogue = "";
                                        insideDialogue = false;
                                    }
                                }
                            } else {
                                if (insideDialogue) {
                                    currentDialogue += token + " ";
                                } else {
                                    if (token.Contains("<wait.")) {
                                        timedDialogues[timedDialogues.Count - 1].Wait = int.Parse(token.Replace("<wait.", null).Replace(">", null));
                                    } else if (token.Contains("/")) {
                                        timedDialogues.Add(new TimedDialogue() { Name = name, Value = token });
                                    } else {
                                        currentAction += token + " ";
                                    }
                                }
                            }
                            token = tokenizer.GetToken();
                        }
                        if (!string.IsNullOrWhiteSpace(currentAction)) {
                            if (!currentAction.Contains("<wait.")) {
                                timedDialogues.Add(new TimedDialogue() { Name = name, Value = currentAction, Wait = 1 });
                            }
                        }
                        currentAction = null;
                        currentDialogue = null;
                    }
                    input = reader.ReadLine();
                }
            }
        }

        internal void Open() {
            throw new NotImplementedException();
        }

        public void Save() {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                WriteFile(textToParse, saveFileDialog.FileName);
                foreach (MacroParticipant macroParticipant in participants.Values) {
                    string path = saveFileDialog.FileName.Replace(".txt", null) + "-" + macroParticipant.Name + ".txt";
                    WriteFile(macroParticipant, path);
                }
            }
        }
        public void WriteFile(string text, string path) {
            using (FileStream fileStream =
                new FileStream(path, FileMode.Create)) {
                using (StreamWriter writer = new StreamWriter(fileStream)) {
                    writer.Write(text);
                }
            }
        }
        public void WriteFile(MacroParticipant macroParticipant, string path) {
            using (FileStream fileStream =
                new FileStream(path, FileMode.Create)) {
                using (StreamWriter writer = new StreamWriter(fileStream)) {
                    foreach (var value in macroParticipant.Actions) {
                        writer.WriteLine(value.ToString());
                    }
                }
            }
        }
    }
}
