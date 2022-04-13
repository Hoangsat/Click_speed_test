using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace click_test_speed
{
    public partial class Form1 : Form

    {
        long time_start;
        long time_finish;
        int max_counter = 10;
        int counter;
        string mode = "stop";//"play"


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            start_game();
        }
        void start_game()
        {
            if (mode == "play") return;
            mode = "play";
            
            counter = max_counter;
            label_counter.Text = counter.ToString();
            label_result.Text = "";
            button_start.Enabled = false;

        }

      

        void play_game()
        {
            if (mode == "stop") return;
            if(counter==max_counter)
                time_start = DateTime.Now.Ticks;
            if (counter > 0)
                counter--;
            label_counter.Text = counter.ToString();

            if(counter==0)
            {
                stop_game();
            }
        }

        void stop_game()
        {
            mode = "stop";
            time_finish = DateTime.Now.Ticks;
            double secons = TimeSpan.FromTicks(time_finish - time_start).TotalSeconds;
            double click_per_seconds = max_counter / secons;
            label_result.Text = click_per_seconds.ToString("#.#") + "Click per second";
            button_start.Enabled = true;


        }

        private void label_counter_MouseDown(object sender, MouseEventArgs e)
        {
        
            play_game();
        }
    }
}
