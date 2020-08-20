using Dakota.Receiver.SerialPort;
using MailNotification.Machine;
using MailNotification.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailNotification
{
    public class Notification
    {
        public static ArduinoInfoModel ArduinoInfo = null;
        public static SerialPortReceiver Receiver = 
            new SerialPortReceiver(new ArduinoMachine("Mail Notification"));

        public async Task<object> Connect(string input)
        {
            return await Task.Run(() =>
            {
                ArduinoInfo = JsonConvert.DeserializeObject<SettingsModel>(File.ReadAllText(input)).ArduinoInfo;

                Receiver.DisConnect();
                Receiver.PortName = ArduinoInfo.PortName;
                Receiver.BaudRate = ArduinoInfo.BaudRate;
                Receiver.Parity = ArduinoInfo.Parity;
                Receiver.DataBits = 8;
                Receiver.StopBits = StopBits.One;
                Receiver.Handshake = Handshake.None;
                return Receiver.Connect();
            });
        }

        public async Task<object> SendMailReceiveMessage(string input)
        {
            return await Task.Run(() =>
            {
                Receiver.SendData(90);
                return true;
            });
        }

        public async Task<object> SendCloseMessage(string input)
        {
            return await Task.Run(() =>
            {
                Receiver.SendData(1000);
                return true;
            });
        }
    }
}
