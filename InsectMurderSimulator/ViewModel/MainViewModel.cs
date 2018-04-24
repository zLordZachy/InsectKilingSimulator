using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using InsectMurderSimulator.Annotations;
using InsectMurderSimulator.Objects;
using InsectMurderSimulator.Recources;
using VektorovyEditor.helpers;

namespace InsectMurderSimulator.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ZCommand AddCommand { get; set; }
        public ZCommand DeleteCommand { get; set; }
        public DispatcherTimer Timer { get; set; }
        public Random Rand { get; set; }
        public IList<Insect> InsectList { get; set; }

        public string InsectCounter
        {
            get => _insectCounter;
            set
            {
                _insectCounter = value;
                OnPropertyChanged(nameof(InsectCounter));
            }
        }

        public int InsectCounterNum
        {
            get => _insectCounterNum;
            set
            {
                _insectCounterNum = value;
                InsectCounter = $"Pocet komaru: {InsectCounterNum}";
            }
        }


        public string InsectDeathCounter
        {
            get => _insectDeathCounter;
            set
            {
                _insectDeathCounter = value;
                OnPropertyChanged(nameof(InsectDeathCounter));
            }
        }

        public int InsectDeatgCounterNum
        {
            get => _insectDeatgCounterNum;
            set
            {
                _insectDeatgCounterNum = value;
                InsectDeathCounter = $"Pocet zabitých komaru: {InsectDeatgCounterNum}";
            }
        }

        private readonly Canvas _canvas;
        private readonly RecourcesData _recourcesData;
        private string _insectCounter;
        private string _insectDeathCounter;
        private int _insectCounterNum;
        private int _insectDeatgCounterNum;

        public MainViewModel(Canvas canvas)
        {
            _canvas = canvas;
            _recourcesData = new RecourcesData();
            AddCommand = new ZCommand(CanAdd, Add);
            DeleteCommand = new ZCommand(CanDelte, Delete);
            InsectList = new List<Insect>();
            Timer = new DispatcherTimer();
            Timer.Tick += TimerTick;
            Timer.Interval = new TimeSpan(0,0,0,0,45);
            Timer.Start();
            Rand = new Random(2);
            
        }

        private bool CanDelte(object obj)
        {
            return true;
        }

        private void Delete(object obj)
        {
            List<Insect> insect = InsectList.Where(x => x.Stav == InsectStatus.Dead).ToList();
            for (var index = 0; index < insect.Count; index++)
            {
                var ins = insect[index];
                _canvas.Children.Remove(ins.Image);
                InsectList.Remove(ins);
            }
        }


        private void TimerTick(object sender, EventArgs e)
        {
            foreach (Insect insect in InsectList)
            {
                if (insect.Stav == InsectStatus.Alive)
                {
                    SetNewAliveImage(insect);
                    MoveWithAliveInsect(insect);
                }else if (insect.Stav == InsectStatus.Falling)
                {
                    SetNewFalingImage(insect);
                    Fallinsect(insect);
                }
            }
        }

        private void Fallinsect(Insect insect)
        {
            if (insect == null)
                return;
            if (insect.FallingCounter == 0)
            {
                if (insect.Image.Width > 100)
                {
                    insect.FallingToPositionTime = 150;
                }
                else
                {
                    insect.FallingToPositionTime = Rand.Next(1, 100);
                }
            }

            if (insect.FallingToPositionTime < insect.FallingCounter)
            {
               SetNewDeadImage(insect);
                insect.Stav = InsectStatus.Dead;
            }

            ProcessFallingInsect(insect);
            insect.FallingCounter++;
        }

        private void ProcessFallingInsect(Insect insect)
        {
            double top = Canvas.GetTop(insect.Image);
            if (top < _canvas.ActualHeight - insect.Image.ActualHeight)
            {
                top += 5;
                Canvas.SetTop(insect.Image, top);
            }
            else
            {
                insect.Stav = InsectStatus.Dead;
            }
                
        }

        private void MoveWithAliveInsect(Insect insect)
        {
            if(insect == null)
                return;

            if (insect.DistancCounter > insect.FilghtToPositionTime)
            {
                insect.DistancCounter = 0;
                insect.FilghtToPositionTime = Rand.Next(1, 150);
                SetNewAliveMoves(insect);
            }

            ProcessMoveAliveInsect(insect);
            insect.DistancCounter++;
        }

        private void ProcessMoveAliveInsect(Insect insect)
        {
            if(insect == null)
                return;

            if (insect.MoveLeft)
            {
                double left = Canvas.GetLeft(insect.Image);
                if (left < _canvas.ActualWidth)
                    Canvas.SetLeft(insect.Image, ++left);
            }

            if (insect.MoveRight)
            {
                double left = Canvas.GetLeft(insect.Image);
                if (left > 0)
                    Canvas.SetLeft(insect.Image, --left);
            }

            if (insect.MoveTop)
            {
                double top = Canvas.GetTop(insect.Image);
                if (top < _canvas.ActualHeight - insect.Image.ActualHeight - 150)
                    Canvas.SetTop(insect.Image, ++top);
            }

            if (insect.MoveDown)
            {
                double top = Canvas.GetTop(insect.Image);
                if (top > 0)
                    Canvas.SetTop(insect.Image, --top);
            }


            if (insect.MoveFront)
            {
                double width = insect.Image.ActualWidth;
                if (width < 200)
                {
                    insect.Image.Width = width + 1;
                    insect.Image.Height = width + 1;
                }
            }

            if (insect.MoveBack)
            {
                double width = insect.Image.ActualWidth;
                if (width > 10)
                {
                    insect.Image.Width = width - 1;
                    insect.Image.Height = width - 1;
                }
            }
        }

        private void SetNewAliveMoves(Insect insect)
        {
            int move = Rand.Next(0, 2);

            if (move == 1)
            {
                insect.MoveBack = false;
                insect.MoveFront = true;

            }
            else
            {
                insect.MoveBack = true;
                insect.MoveFront = false;
            }

            move = Rand.Next(0, 2);
            if (move == 1)
            {
                insect.MoveTop = true;
                insect.MoveDown = false;
            }
            else
            {
                insect.MoveTop = false;
                insect.MoveDown = true;
            }

            move = Rand.Next(0, 2);
            if (move == 1)
            {
                insect.Image.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform {ScaleX = -1};
                insect.Image.RenderTransform = flipTrans;
                insect.MoveRight = true;
                insect.MoveLeft = false;
            }
            else
            {
                insect.Image.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform {ScaleX = 1};
                insect.Image.RenderTransform = flipTrans;
                insect.MoveRight = false;
                insect.MoveLeft = true;
            }
        }

        private void SetNewDeadImage(Insect insect)
        {
            insect.Image.Source = _recourcesData.Image17;
        }

        private void SetNewAliveImage(Insect insect)
        {
            if(insect == null)
                return;
            BitmapImage image = _recourcesData.Image01;
            switch (insect.PictureStats)
            {
                case 1:
                    image = _recourcesData.Image01;
                    break;
                case 2:
                    image = _recourcesData.Image02;
                    break;
                case 3:
                    image = _recourcesData.Image03;
                    break;
                case 4:
                    image = _recourcesData.Image04;
                    break;
                case 5:
                    image = _recourcesData.Image05;
                    break;
                case 6:
                    image = _recourcesData.Image06;
                    break;
                case 7:
                    image = _recourcesData.Image07;
                    break;
                case 8:
                    image = _recourcesData.Image08;
                    break;
                case 9:
                    image = _recourcesData.Image09;
                    break;
                case 10:
                    image = _recourcesData.Image10;
                    break;
                case 11:
                    image = _recourcesData.Image11;
                    break;
                case 12:
                    image = _recourcesData.Image12;
                    insect.PictureStats = 0;
                    break;
            }

            insect.PictureStats++;
            insect.Image.Source = image;
        }

        private void SetNewFalingImage(Insect insect)
        {
            if (insect == null)
                return;
            BitmapImage image = _recourcesData.Image13;

            switch (insect.PictureStats)
            {
                case 13:
                    image = _recourcesData.Image13;

                    break;
                case 14:
                    image = _recourcesData.Image14;

                    break;
                case 15:
                    image = _recourcesData.Image15;

                    break;
                case 16:
                    image = _recourcesData.Image16;

                    insect.PictureStats = 12;
                    break;
            }
            insect.PictureStats++;
            insect.Image.Source = image;
        }

        private bool CanAdd(object obj)
        {
            return true;
        }

        private void Add(object obj)
        {
            AddInsect();
        }

        private void AddInsect()
        {
           BitmapImage btpImage = _recourcesData.Image01;

            Image image = new Image {Source = btpImage};
            image.MouseLeftButtonDown += MouseLeftButtonKill;
            Insect insect = new Insect {Image = image, Stav = InsectStatus.Alive, PictureStats = 1};
            Canvas.SetTop(image, Rand.Next(10, (int)( _canvas.ActualHeight - image.ActualHeight -150)));
            Canvas.SetLeft(image, Rand.Next(10, (int) (_canvas.ActualWidth - image.ActualWidth -50)));
            _canvas.Children.Add(insect.Image);
            InsectList.Add(insect);
            InsectCounterNum++;
        }

        private void MouseLeftButtonKill(object sender, MouseButtonEventArgs e)
        {
            Image i = sender as Image;
            Insect  killedInsect = InsectList.FirstOrDefault(x => Equals(x.Image, i));
            if(killedInsect == null || killedInsect.Stav == InsectStatus.Dead)
                return;
            killedInsect.Stav = InsectStatus.Falling;
            killedInsect.PictureStats = 13;
            InsectDeatgCounterNum++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}