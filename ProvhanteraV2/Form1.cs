namespace ProvhanteraV2 {
    public partial class Form1 : Form {
        string[] correctAnswers = { "A1", "A2", "B3", "A4", "C5", "B6", "A7", "TRUE" };
        List<string> answers;
        // GÖR EN LISTA PÅ RÄTTA SVAREN

        public Form1() {
            InitializeComponent();
            answers = new List<string>();
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e) {

        }

        private void groupBox2_Enter(object sender, EventArgs e) {

        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void pictureBox2_Click(object sender, EventArgs e) {

        }
        /* LÄGG I DESKTOP FIL SOM SPARAR RESULTAT
            * TITLE PÅ FILL 
            * SVAREN
            * GÖR INGEN RÄTTNING ÅT TEXTBOXES 
            */
        private void EndExam_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); saveFileDialog1.Filter = "Text File|*.txt"; saveFileDialog1.Title = "Save Your Test Results"; if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                string filePath = saveFileDialog1.FileName; 
                using (StreamWriter writer = new StreamWriter(filePath)) {
                    MessageBox.Show("File saved to: " + filePath, "File Saved", MessageBoxButtons.OK);
                   
                    SaveRadioButtonAnswer(A1, writer, 1);
                    SaveRadioButtonAnswer(B1, writer, 1);
                    SaveRadioButtonAnswer(C1, writer, 1);
                    SaveRadioButtonAnswer(A2, writer, 2);
                    SaveRadioButtonAnswer(B2, writer, 2);
                    SaveRadioButtonAnswer(C2, writer, 2);
                    SaveRadioButtonAnswer(A3, writer, 3);
                    SaveRadioButtonAnswer(B3, writer, 3);
                    SaveRadioButtonAnswer(C3, writer, 3);
                    SaveRadioButtonAnswer(A4, writer, 4);
                    SaveRadioButtonAnswer(B4, writer, 4);
                    SaveRadioButtonAnswer(C4, writer, 4);
                    SaveRadioButtonAnswer(A5, writer, 5);
                    SaveRadioButtonAnswer(B5, writer, 5);
                    SaveRadioButtonAnswer(C5, writer, 5);
                    SaveRadioButtonAnswer(A6, writer, 6);
                    SaveRadioButtonAnswer(B6, writer, 6);
                    SaveRadioButtonAnswer(C6, writer, 6);
                    SaveRadioButtonAnswer(A7, writer, 7);
                    SaveRadioButtonAnswer(B7, writer, 7);
                    SaveRadioButtonAnswer(C7, writer, 7);
                    SaveRadioButtonAnswer(TRUE, writer, 8);
                    SaveRadioButtonAnswer(FALSE, writer, 8);
                    SaveTextBoxAnswer(textBox1, writer, 9);
                    SaveTextBoxAnswer(textBox2, writer, 10);
                    SaveTextBoxAnswer(textBox3, writer, 11);
                    SaveTextBoxAnswer(textBox4, writer, 12);
                    SaveTextBoxAnswer(textBox5, writer, 13);
/*
                    MessageBox.Show("File saved to: " + @"/save.txt", "File Saved", MessageBoxButtons.OK);
                    string resultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/results.txt";
                    SaveResults(resultFilePath);
                    MessageBox.Show("Din test resultat är sparat i: " + resultFilePath, "Results Saved", MessageBoxButtons.OK);      
 */
                }
            }
        }

        private void SaveTextBoxAnswer(TextBox textBoxAnswer, StreamWriter writer, int questionNumber) {
            string answer = textBoxAnswer.Text;
            writer.WriteLine("Fråga " + questionNumber + " (Text fråga): " + answer);
            answers.Add(answer);
        }

        private void SaveResults(string resultFilePath) {
            using (StreamWriter resultWriter = new StreamWriter(resultFilePath)) {
                for (int i = 0; i < correctAnswers.Length; i++) {
                    if (answers.Count > i && answers[i] == correctAnswers[i]) {
                        resultWriter.WriteLine("Fråga " + (i + 1) + ": Rätt!");
                    }
                    else if (answers.Count > i) {
                        resultWriter.WriteLine("Fråga " + (i + 1) + ": Fel. Rätta svaret är " + correctAnswers[i]);
                    }
                    else {
                        resultWriter.WriteLine("Fråga " + (i + 1) + ": Fel. Du har inte svarat. Rätta svaret är " + correctAnswers[i]);
                    }
                }
            }
        }

        private void SaveRadioButtonAnswer(RadioButton radioButton, StreamWriter writer, int questionNumber) {
            if (radioButton.Checked) {
                string radioButtonAnswer = radioButton.Name;
                writer.WriteLine("Fråga " + questionNumber + " (Flervals fråga): " + radioButtonAnswer);
                answers.Add(radioButtonAnswer);
            }
        }
    }
}