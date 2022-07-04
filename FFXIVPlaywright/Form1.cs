using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVPlaywright {
    public partial class Form1 : Form {
        private GroupMacroParser groupMacroParser;
        private string currentPreviewText;
        private int simulationIndex;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            groupMacroParser = new GroupMacroParser();
            Text = "FFXIV Playwright (Alpha) v" + Application.ProductVersion;
            macroTextBox.Text = @"PersonOne: ""Hello! this is a group macro tutorial"" <wait.5>
PersonTwo: ""And I'm a second person who will be participating in this macro!"" <wait.5>
PersonOne: ""Each person should be correctly named with no spaces, and all their dialogue can take place on the same line before going on to the next person."" <wait.5>
PersonOne: ""Subsequent lines still need to label who is speaking"" <wait.5>
PersonTwo: ""All dialogue should be in quotations, otherwise it might be confused as a command argument"" <wait.5>
PersonOne: ""We can use commands and dialogue on the same line"" <wait.1> /happy <wait.5>
PersonTwo: /happy <wait.1> ""I'm very happy to show this off, so happy I may want to cheer"" <wait.1> /cheer <wait.1> ""See! Look how loud I can cheer!"" <wait.5>
PersonOne: ""And this concludes the tutorial! If you're familiar with FFXIV commands and macros, this program aims to use your existing knowledge of those""
PersonTwo: ""But now you can just worry about the big picture macro! This program will split it up into individualized chunks after the fact!"" <wait.1> /cheer <wait.1>
PersonOne: ""Hooray!"" <wait.4> /welcome
";
            groupMacroParser.ParseScript(macroTextBox.Text, cleanQuotations.Checked);
            RefreshList();
        }

        private void actorListBox_SelectedIndexChanged(object sender, EventArgs e) {
            currentPreviewText = null;
            if (actorsList.SelectedItem != null) {
                foreach (var action in groupMacroParser.Participants[(string)actorsList.SelectedItem].Actions) {
                    currentPreviewText += action.ToString() + "\r\n";
                    macroPreviewBox.Text = currentPreviewText;
                }
                macroPreviewBox.Enabled = true;
            }
        }

        private void parseTextButton_Click(object sender, EventArgs e) {
            macroTextBox.Text = macroTextBox.Text.Replace(@"""<", @""" <");
            currentPreviewText = "";
            macroPreviewBox.Text = "";
            macroPreviewBox.Enabled = false;
            groupMacroParser.ParseScript(macroTextBox.Text, cleanQuotations.Checked);
            RefreshList();
            chatLogSimulatorText.Text = null;
            foreach (MacroParticipant macroParticipant in groupMacroParser.Participants.Values) {
                int lineCount = 0;
                foreach (TimedDialogue dialogue in macroParticipant.Actions) {
                    lineCount++;
                    if (dialogue.IssueDetected) {
                        chatLogSimulatorText.AppendText("Warning, " + macroParticipant.Name + "'s line " + dialogue.Value + $" on line {lineCount} of their macro exceeds 170 characters \r\n");
                    }
                }
            }
            MessageBox.Show("Script Processed");
        }

        private void saveButton_Click(object sender, EventArgs e) {
            macroTextBox.Text = macroTextBox.Text.Replace(@"""<", @""" <");
            groupMacroParser.ParseScript(macroTextBox.Text, cleanQuotations.Checked);
            RefreshList();
            groupMacroParser.Save();
        }

        private void openButton_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.AddExtension = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                macroTextBox.Text = OpenFile(openFileDialog.FileName);
                groupMacroParser.ParseScript(macroTextBox.Text, cleanQuotations.Checked);
                RefreshList();
            }
        }
        private void RefreshList() {
            actorsList.Items.Clear();
            foreach (MacroParticipant macroParticipant in groupMacroParser.Participants.Values) {
                actorsList.Items.Add(macroParticipant.Name);
            }
        }
        public string OpenFile(string path) {
            using (FileStream fileStream = new FileStream(path, FileMode.Open)) {
                using (StreamReader reader = new StreamReader(fileStream)) {
                    return reader.ReadToEnd();
                }
            }
        }

        private void macroPreviewBox_TextChanged(object sender, EventArgs e) {
            macroPreviewBox.Text = currentPreviewText;
        }

        private void cleanQuotations_CheckedChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void simulateLogButton_Click(object sender, EventArgs e) {
            simulationIndex = 0;
            chatLogSimulatorText.Text = null;
            groupMacroParser.ParseScriptForSimulation(macroTextBox.Text, cleanQuotations.Checked);
            ExecuteDialogue();
            chatTimer.Start();
        }
        void ExecuteDialogue() {
            if (simulationIndex < groupMacroParser.TimedDialogues.Count) {
                TimedDialogue dialogue = groupMacroParser.TimedDialogues[simulationIndex++];
                chatLogSimulatorText.AppendText(dialogue.Name + ": " + dialogue.Value + "\r\n");
                if (dialogue.Wait != 0) {
                    chatTimer.Interval = dialogue.Wait * 1000;
                } else {
                    chatTimer.Interval = 1000;
                }
            } else {
                chatTimer.Stop();
            }

        }
        private void chatTimer_Tick(object sender, EventArgs e) {
            chatTimer.Stop();
            ExecuteDialogue();
            chatTimer.Start();
        }

        private void macroTextBox_TextChanged(object sender, EventArgs e) {

        }
    }
}
