using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Client.Models
{
    public class Cell : BindableBase
    {

        private bool m_live;
        public bool live
        {
            get { return m_live; }
            set
            {
                m_live = value;
                OnPropertyChanged("live");
                OnPropertyChanged("Color");
            }
        }

        public string Color
        {
            get
            {
                return live ? "#FFF" : "#000";
            }
        }

    }
}
