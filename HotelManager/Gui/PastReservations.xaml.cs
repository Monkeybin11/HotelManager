﻿using HotelManager.Entity;
using HotelManager.Service;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace HotelManager.Gui
{
    /// <summary>
    /// Interaction logic for PastReservations.xaml
    /// </summary>
    public partial class PastReservations : BaseFrameWithSearch<Reservation>
    {
       
        private ReservationService reservationService = ServiceFactory.GetReservationService();

        public PastReservations()
        {
            InitializeComponent();
        }

        protected override void BaseFrame_Loaded(object sender, RoutedEventArgs e)
        {
            base.BaseFrame_Loaded(sender, e);
            emptyListMessage.Text = "No reservations.";
            GridView gridView = list.View as GridView;
            gridView.Columns.Add(CreateColumn("FromDateString", "From"));
            gridView.Columns.Add(CreateColumn("ToDateString", "To"));
            gridView.Columns.Add(CreateColumn("RoomString", "Room"));
            gridView.Columns.Add(CreateColumn("EndDateString", "Completed"));
            gridView.Columns.Add(CreateColumn("Person", "Person"));
            gridView.Columns.Add(CreateColumn("Contact", "Contact"));
            gridView.Columns.Add(CreateColumn("CreationDateString", "Created"));
            ReloadData("");
        }

        protected override void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            base.Worker_DoWork(sender, e);
            string query = (string)e.Argument;
            items = reservationService.FindPastReservation(query);
        }

    }
}
