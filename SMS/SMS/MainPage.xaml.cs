﻿using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SMS
{
    public partial class MainPage : ContentPage
    {
        TableView tableView;
        TableSection fotosection;
        EntryCell tel_nr, email, text;
        public MainPage()
        {
            tel_nr = new EntryCell()
            {
                Label = "Telefon",
                Placeholder = "Sisesta tel. number",
                Keyboard = Keyboard.Telephone
            };
            email = new EntryCell()
            {
                Label = "Email",
                Placeholder = "Sisesta email",
                Keyboard = Keyboard.Email

            };
            text = new EntryCell()
            {
                Label = "Plaun kirjuta text",
                Placeholder = "Sisesta text",
                Keyboard = Keyboard.Default,
            };
            fotosection = new TableSection();
            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed: ")
                    {
                        text
                    },
                    new TableSection("Kontaktiandmed: ")
                    {
                        tel_nr,
                        email,

                    },
                    fotosection
                }
            };

            Button sms_btn = new Button { Text = "Saada SMS" };
            sms_btn.Clicked += Sms_btn_Clicked; ;

            Button call_btn = new Button { Text = "Helista" };
            call_btn.Clicked += Call_btn_Clicked; ;

            Button mail_btn = new Button { Text = "Kirjuta kiri" };
            mail_btn.Clicked += Mail_btn_Clicked; ;

            Grid actionStackLayout = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };
            actionStackLayout.Children.Add(call_btn, 0, 0);
            actionStackLayout.Children.Add(sms_btn, 1, 0);
            actionStackLayout.Children.Add(mail_btn, 2, 0);

            StackLayout st = new StackLayout { Children = { tableView, actionStackLayout } };

            Content = st;
        }

        private void Mail_btn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var uri = new Uri("mailto:" + email.Text + "?subject=Tervitus!&body=" + text.Text);
                Device.OpenUri(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to open mail client: " + ex);
            }
        }

        private void Call_btn_Clicked(object sender, EventArgs e)
        {
            try
            {

                var uri = new Uri("tel:" + tel_nr.Text);

                Device.OpenUri(uri);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Unable to call: " + ex);
            }
        }

        private void Sms_btn_Clicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel_nr.Text, text.Text);
            }
        }
    }
}
