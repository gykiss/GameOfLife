using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using GameOfLife.Client.Services;

namespace GameOfLife.Client.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            InitTimer();
        }
        public DispatcherTimer timer;
        private void InitTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
        }
        
        public async Task Next()
        {
            int[,] table = await Services.Commands.GetNextGeneration(Table.ToIntArray());
            if(table!=null)
            {
                Table = table.ToCellArray();
            }
            
        }

        private Models.Cell[,] m_Table;
        public Models.Cell[,] Table
        {
            get { return m_Table; }
            set
            {
                m_Table = value;
                OnPropertyChanged("Table");
            }
        }
        
        private string m_PlayPause = "Play";
        public string PlayPause
        {
            get { return m_PlayPause; }
            set
            {
                m_PlayPause = value;
                OnPropertyChanged("PlayPause");
            }
        }

        private bool m_Auto = false;
        public bool Auto
        {
            get { return m_Auto; }
            set
            {
                m_Auto = value;
                if (m_Auto)
                {
                    
                    timer?.Start();
                }
                else
                {
                    timer?.Stop();
                }
                OnPropertyChanged("Auto");
                OnPropertyChanged("PlayPauseButtonContent");
            }
        }

        
        public string PlayPauseButtonContent
        {
            get { return Auto ? "Pause" : "Play"; }
        }


        private bool m_isEdit = true;
        public bool isEdit
        {
            get { return m_isEdit; }
            set
            {
                m_isEdit = value;
                OnPropertyChanged("isEdit");
                OnPropertyChanged("isEditVisibility");
            }
        }

        public Visibility isEditVisibility
        {
            get { return isEdit ? Visibility.Collapsed : Visibility.Visible; }
        }



    }

    public class ItemTappedClick : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter is Models.Cell)
            {
                Models.Cell cell = parameter as Models.Cell;
                cell.live = !cell.live;
            }
        }
    }
}
