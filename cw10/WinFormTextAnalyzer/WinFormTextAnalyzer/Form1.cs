using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTextAnalyzer
{
    public partial class Form1 : Form
    {
        private readonly List<string> _correctWordsList;
        private IDictionary<string, int> _count;
        private List<string> _incorrectWordsList;

        public Form1()
        {
            InitializeComponent();

            _correctWordsList = GetCorrectWords();
            _count = new Dictionary<string, int>();
            _incorrectWordsList = new List<string>();

            Load += Form1_Load;
        }

        private List<string> GetCorrectWords()
        {
            WebClient client = new WebClient();
            String correctWords =
                client.DownloadString("https://www.wordgamedictionary.com/english-word-list/download/english.txt");
            List<string> correctWordsList = correctWords.Split(new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None).ToList();
            return correctWordsList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            _incorrectWordsList.Clear();
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            _count.Clear();

            var text = inputBox.Text;
            Analyze(text);
        }

        private void Analyze(string text)
        {
            text = Regex.Replace(text, @"[^0-9a-zA-Z]+", " ");
            List<string> wordsToCheck = text.Split(' ').ToList();

            progressBar.Maximum = wordsToCheck.Count;
            var i = 1;
            foreach (var word in wordsToCheck)
            {
                var isCorrect = IsCorrect(word);
                if (isCorrect)
                {
                    if (_count.ContainsKey(word.ToLower()))
                    {
                        _count[word.ToLower()] += 1;
                    }
                    else
                    {
                        _count.Add(word.ToLower(), 1);
                    }
                }

                progressBar.Value = i;
                i++;
            }

            foreach (var word in _incorrectWordsList)
            {
                textBox1.Text += word + Environment.NewLine;
            }
            foreach (KeyValuePair<string, int> kvp in _count)
            {
                textBox2.Text += kvp.Key + " - " + kvp.Value + Environment.NewLine;
            }
        }

        private bool IsCorrect(string word)
        {
            foreach (var correctWord in _correctWordsList)
            {
                if (correctWord.ToLower() == word.ToLower())
                {
                    return true;
                }
            }
            if (!_incorrectWordsList.Contains(word.ToLower()))
            {
                _incorrectWordsList.Add(word.ToLower());
            }

            return false;
        }
    }
}
