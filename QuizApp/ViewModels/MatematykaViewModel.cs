using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QuizApp.Models;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;

namespace QuizApp.ViewModels
{
    public class MatematykaViewModel : ViewModelBase
    {
        private List<Question> _questions;
        private int _currentQuestionIndex;
        private string _selectedAnswer;
        private int _score;
        private bool _quizFinished;
        private string _resultText;
        private bool _isResultVisible;

        public List<Question> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                RaisePropertyChanged();
            }
        }

        public int CurrentQuestionIndex
        {
            get { return _currentQuestionIndex; }
            set
            {
                _currentQuestionIndex = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(CurrentQuestion));
                RaisePropertyChanged(nameof(IsQuizFinished));
            }
        }

        public Question CurrentQuestion
        {
            get
            {
                if (CurrentQuestionIndex >= 0 && CurrentQuestionIndex < Questions.Count)
                    return Questions[CurrentQuestionIndex];
                else
                    return null;
            }
        }

        public string SelectedAnswer
        {
            get { return _selectedAnswer; }
            set
            {
                _selectedAnswer = value;
                RaisePropertyChanged();
            }
        }

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged();
            }
        }

        public bool IsQuizFinished
        {
            get { return _quizFinished; }
            set
            {
                _quizFinished = value;
                RaisePropertyChanged();
            }
        }

        public string ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                RaisePropertyChanged();
            }
        }

        public bool IsResultVisible
        {
            get { return _isResultVisible; }
            set
            {
                _isResultVisible = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CheckAnswerCommand { get; }
        public ICommand NextQuestionCommand { get; }
        public ICommand FinishQuizCommand { get; }

        public MatematykaViewModel()
        {
            CheckAnswerCommand = new RelayCommand(CheckAnswer);
            NextQuestionCommand = new RelayCommand(NextQuestion);
            FinishQuizCommand = new RelayCommand(FinishQuiz);
            LoadQuestions();
            CurrentQuestionIndex = 0;
        }

        private void LoadQuestions()
        {
            using (var connection = new SQLiteConnection("Data Source=quiz.db;Version=3;"))
            {
                connection.Open();

                string selectQuery = "SELECT Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer FROM Questions";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    var questions = new List<Question>();
                    while (reader.Read())
                    {
                        string questionText = reader.GetString(0);
                        string answerA = reader.GetString(1);
                        string answerB = reader.GetString(2);
                        string answerC = reader.GetString(3);
                        string answerD = reader.GetString(4);
                        string correctAnswer = reader.GetString(5);

                        var options = new List<string> { answerA, answerB, answerC, answerD };

                        var question = new Question
                        {
                            QuestionText = questionText,
                            Options = options,
                            CorrectAnswer = correctAnswer
                        };
                        questions.Add(question);
                    }
                    Questions = questions;
                }
            }
        }

        private void CheckAnswer()
        {
            if (CurrentQuestion.CorrectAnswer.Equals(SelectedAnswer, StringComparison.OrdinalIgnoreCase))
            {
                Score++;
            }
        }

        private void NextQuestion()
        {
            if (CurrentQuestionIndex < Questions.Count - 1)
            {
                CheckAnswer();
                CurrentQuestionIndex++;
                SelectedAnswer = null;
            }
            else
            {
                // Ostatnie pytanie
                IsQuizFinished = true;
            }
        }

        private void FinishQuiz()
        {
            ResultText = $"Wynik: {Score} / {Questions.Count}";
            IsResultVisible = true;
        }
    }
}
