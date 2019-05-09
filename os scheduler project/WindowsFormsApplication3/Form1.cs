using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            time.Hide();
            arrival.Hide();
            priorty_list.Hide();
            tabcnt.AutoSize = true;
            tabcnt.TabPages[0].AutoSize = true;
            quantum.Text = "Q";
            quantum.Enabled = false;
         
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }



        Dictionary<int, TextBox> T = new Dictionary<int, TextBox>();
        Dictionary<int, TextBox> A = new Dictionary<int, TextBox>();
        Dictionary<int, TextBox> P = new Dictionary<int, TextBox>();

        List<process> processes = new List<process>();





        private void go_Click(object sender, EventArgs e)
        {

            string arrival_text;
            string burst_text;
            string priorty_text;
            gantt.Controls.Clear();
            processes.Clear();
            int number_of_processes = int.Parse(number.Text);
            for (int i = 0; i < number_of_processes; i++)
            {
                arrival_text = A.Values.ElementAt(i).Text;
                burst_text = T.Values.ElementAt(i).Text;
                priorty_text = P.Values.ElementAt(i).Text;
                process p = new process(int.Parse(arrival_text), int.Parse(burst_text), i + 1, int.Parse(priorty_text));
                processes.Add(p);
            }
            tabcnt.SelectTab("gantt");
            if (fcfs.Checked == true)
            {
                fcfs_paint();  
            }
            if (shortfirst.Checked == true)
            {
               sjf_paint();
            }
            if (priorty.Checked == true)
            {
                priorty_paint();
            }
            if (roundrobbin.Checked == true)
            {
                roundrobbin_paint();
            }
            if(prem_priorty.Checked==true)
            {
                prem_priorty_paint();
            }
            if(srtf.Checked==true)
            {
                srtf_paint();
            }
            if (roundrobbin.Checked == true)
            {

               //Round robbin
                  
            }
          //  gantt_Paint();
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void processes_Click(object sender, EventArgs e)
        {

        }

        private void config_Click(object sender, EventArgs e)
        {

        }

        private void arrival_Enter(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


        }

        int scale = 50;
        private void fcfs_paint()
        {

            int number_processes = int.Parse(number.Text);
            Graphics gObject = gantt.CreateGraphics();
            Random rnd = new Random();
            gantt.Controls.Clear();
            Font font = new Font("Times New Roman", 9.0f);
            int i = 0;
            gantt.AutoScroll=true;
            List<int> departure=new List<int>();
          


            //sorting according to arrival
            for (int k = 0; k < number_processes; k++)
            {
                for (int l = 0; l < number_processes; l++)
                {
                    if (processes[k].get_arrival() < processes[l].get_arrival())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                    
                }
            
            }
            int time = processes[0].get_arrival();
            
            //printing
                foreach (process p in processes)
                {

                    int arrival = (p.get_arrival());
                    int burst = (p.get_burst());
                    if (time > arrival) arrival = time;
                    if (time < arrival) time=arrival;

                    Color redColor = Color.FromArgb(255, 0, 0);
                    SolidBrush brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));

                    
 
                    Label draw = new Label();
                    draw.Location = new Point(arrival*scale, 150);
                    draw.Size = new Size(burst*scale, 20);
                    draw.Text = "P" + (p.get_index()).ToString();
                    draw.TextAlign = ContentAlignment.MiddleCenter;
                    draw.BackColor = (Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))); 
                    gantt.Controls.Add(draw);
                    time += burst;

                    departure.Add(time);

             

                    Label b = new Label();
                    b.Text = (arrival ).ToString();
                    b.Location = new Point(arrival*scale, 180);

                    b.Font = font;
                    b.Size = new System.Drawing.Size(40, 17);
                    gantt.Controls.Add(b);


                    Label c = new Label();
                    c.Text = (time).ToString();
                    c.Location = new Point(time*scale, 180);
                    c.Font = font;
                    c.Size = new System.Drawing.Size(40, 17);
                    gantt.Controls.Add(c);

                    i++;

                }
                float tat = 0;
                float wt = 0;
                for (int iq = 0; iq < number_processes; iq++)
                {
                    tat += (departure[iq] - processes[iq].get_arrival());
                    wt += departure[iq] - processes[iq].get_arrival() - processes[iq].get_burst();
                }
                tat /= number_processes;
                wt /= number_processes;

                Label d = new Label();
                d.Text = "TAT= "+(tat).ToString() +  "   WT= "+(wt).ToString();
                d.Location = new Point(150,220);
                d.Font = new Font("Times New Roman", 16.0f);
                d.Size = new System.Drawing.Size(200, 50);
                gantt.Controls.Add(d);
         
            Button go_back = new Button();
            go_back.Location = new Point(200, 270);
            go_back.Text = "Back";
            go_back.Click += new EventHandler(go_back_Click);
            gantt.Controls.Add(go_back);



        }


        private void sjf_paint()
        {



            int number_processes = int.Parse(number.Text);
            Graphics gObject = gantt.CreateGraphics();
            Random rnd = new Random();
            gantt.Controls.Clear();
            Font font = new Font("Times New Roman", 9.0f);
            int i = 0;
            List<int> departure = new List<int>();


            //sorting according to arrival
            for (int k = 0; k < number_processes; k++)
            {
                for (int l = 0; l < number_processes; l++)
                {
                    if (processes[k].get_arrival() < processes[l].get_arrival())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                    else if(processes[k].get_arrival() == processes[l].get_arrival()&&processes[k].get_burst() < processes[l].get_burst())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                }

            }
          
            int time = processes[0].get_arrival();

            //printing
            for(i=0;i<number_processes;i++)
            {
                process p = processes[i];
                int arrival = (p.get_arrival());
                int burst = (p.get_burst());
                if (time > arrival) arrival = time;
                if (time < arrival) time = arrival;



                Label draw = new Label();
                draw.Location = new Point(arrival*scale, 150);
                draw.Size = new Size(burst*scale, 20);
                draw.Text = "P" + (p.get_index()).ToString();
                draw.TextAlign = ContentAlignment.MiddleCenter;
                draw.BackColor = (Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                gantt.Controls.Add(draw);
                time += burst;
                departure.Add(time);


              

                for (int j = i + 1; j < number_processes-1; j++)
                {
                    if (processes[j].get_arrival() <= time)
                    {
                        for (int k = j + 1; k < number_processes; k++)
                        {
                            if( processes[k].get_arrival() <= time&&processes[j].get_burst()>processes[k].get_burst())
                            {
                            process t = processes[j];
                            processes[j] = processes[k];
                            processes[k] = t;
                            }
                        }
                     
                    }
                    
                
                }

          

              

                Label b = new Label();
                b.Text = (arrival).ToString();
                b.Location = new Point(arrival*scale, 180);

                b.Font = font;
                b.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(b);

                Label c = new Label();
                c.Text = (time).ToString();
                c.Location = new Point(time*scale, 180);
                c.Font = font;
                c.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(c);



            }

            float tat = 0;
            float wt = 0;
            for (int iq = 0; iq < number_processes; iq++)
            {
                tat += (departure[iq] - processes[iq].get_arrival());
                wt += departure[iq] - processes[iq].get_arrival() - processes[iq].get_burst();
            }
            tat /= number_processes;
            wt /= number_processes;

            Label d = new Label();
            d.Text = "TAT= " + (tat).ToString() + "   WT= " + (wt).ToString();
            d.Location = new Point(150, 220);
            d.Font = new Font("Times New Roman", 16.0f);
            d.Size = new System.Drawing.Size(200, 50);
            gantt.Controls.Add(d);

            Button go_back = new Button();
            go_back.Location = new Point(200, 270);
            go_back.Text = "Back";
            go_back.Click += new EventHandler(go_back_Click);
            gantt.Controls.Add(go_back);




        }

        private void priorty_paint()
        {



            int number_processes = int.Parse(number.Text);
            Graphics gObject = gantt.CreateGraphics();
            Random rnd = new Random();
            gantt.Controls.Clear();
            Font font = new Font("Times New Roman", 9.0f);
            int i = 0;
            List<int> departure = new List<int>();


            //sorting according to arrival
            for (int k = 0; k < number_processes; k++)
            {
                for (int l = 0; l < number_processes; l++)
                {
                    if (processes[k].get_arrival() < processes[l].get_arrival())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                    else if (processes[k].get_arrival() == processes[l].get_arrival() && processes[k].get_priorty() < processes[l].get_priorty())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                }

            }

            int time = processes[0].get_arrival();

            //printing
            for (i = 0; i < number_processes; i++)
            {
                process p = processes[i];
                int arrival = (p.get_arrival());
                int burst = (p.get_burst());
                if (time > arrival) arrival = time;
                if (time < arrival) time = arrival;



                Label draw = new Label();
                draw.Location = new Point(arrival * scale, 150);
                draw.Size = new Size(burst * scale, 20);
                draw.Text = "P" + (p.get_index()).ToString();
                draw.TextAlign = ContentAlignment.MiddleCenter;
                draw.BackColor = (Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                gantt.Controls.Add(draw);
                time += burst;
                departure.Add(time);

                for (int j = i + 1; j < number_processes - 1; j++)
                {
                    if (processes[j].get_arrival() <= time)
                    {
                        for (int k = j + 1; k < number_processes; k++)
                        {
                            if (processes[k].get_arrival() <= time && processes[j].get_priorty() > processes[k].get_priorty())
                            {
                                process t = processes[j];
                                processes[j] = processes[k];
                                processes[k] = t;
                            }
                        }

                    }


                }




                Label b = new Label();
                b.Text = (arrival).ToString();
                b.Location = new Point(arrival * scale, 180);

                b.Font = font;
                b.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(b);

                Label c = new Label();
                c.Text = (time).ToString();
                c.Location = new Point(time * scale, 180);
                c.Font = font;
                c.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(c);


            }




            float tat = 0;
            float wt = 0;
            for (int iq = 0; iq < number_processes; iq++)
            {
                tat += (departure[iq] - processes[iq].get_arrival());
                wt += departure[iq] - processes[iq].get_arrival() - processes[iq].get_burst();
            }
            tat /= number_processes;
            wt /= number_processes;

            Label d = new Label();
            d.Text = "TAT= " + (tat).ToString() + "   WT= " + (wt).ToString();
            d.Location = new Point(150, 220);
            d.Font = new Font("Times New Roman", 16.0f);
            d.Size = new System.Drawing.Size(200, 50);
            gantt.Controls.Add(d);

            Button go_back = new Button();
            go_back.Location = new Point(200, 270);
            go_back.Text = "Back";
            go_back.Click += new EventHandler(go_back_Click);
            gantt.Controls.Add(go_back);



        }

        private void roundrobbin_paint()
        {

            int number_processes = int.Parse(number.Text);
            Graphics gObject = gantt.CreateGraphics();
            Random rnd = new Random();
            gantt.Controls.Clear();
            Font font = new Font("Times New Roman", 9.0f);
            List<int> bursts = new List<int>();
            List<int> arrivals = new List<int>();

            //BDAYT EL ALGORITHM

             for (int j = 0; j < number_processes; j++)
            { 
                arrivals.Add(processes[j].get_arrival());
            }
             for (int k = 0; k < number_processes; k++)
             {
                 bursts.Add(processes[k].get_burst());
             }
            //sorting according to arrival
            for (int k = 0; k < number_processes; k++)
            {
                for (int l = 0; l < number_processes; l++)
                {
                    if (processes[k].get_arrival() < processes[l].get_arrival())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                }

            }
           
            // algorithm of RR
            int[] remaining = new int[number_processes];
            int[] dyn_arrival = new int[number_processes];
            List<process> seq = new List<process>();
            List<int> seq_burst = new List<int>();
            List<int> seq_start = new List<int>();
            List<int> seq_end = new List<int>();
            for (int i = 0; i < number_processes; i++)
            {
                remaining[i] = processes[i].get_burst();
                dyn_arrival[i] = processes[i].get_arrival();
            }
            int time = processes[0].get_arrival();
            int Q = int.Parse(quantum.Text);
            while (true)
            {
                bool flag = true;
                for (int i = 0; i < number_processes; i++)
                {
                    if (dyn_arrival[i] <= time)
                    {
                        if (dyn_arrival[i] <= Q)
                        {
                            if (remaining[i] > 0)
                            {
                                flag = false;
                                if (remaining[i] > Q)
                                {
                                    time = time + Q;
                                    remaining[i] = remaining[i] - Q;
                                    dyn_arrival[i] = dyn_arrival[i] + Q;
                                    seq.Add(processes[i]);
                                    seq_burst.Add(Q);
                                    seq_start.Add(time - Q);
                                }
                                else
                                {
                                    time = time + remaining[i];
                                    seq.Add(processes[i]);
                                    seq_burst.Add(remaining[i]);
                                    seq_start.Add(time - remaining[i]);
                                    processes[i].set_finish(time);
                                    remaining[i] = 0;
                                }
                            }
                        }
                        else if (dyn_arrival[i] > Q)
                        {
                            for (int j = 0; j < number_processes; j++)
                            {

                                if (dyn_arrival[j] < dyn_arrival[i])
                                {
                                    if (remaining[j] > 0)
                                    {
                                        flag = false;
                                        if (remaining[j] > Q)
                                        {
                                            time = time + Q;
                                            remaining[j] = remaining[j] - Q;
                                            dyn_arrival[j] = dyn_arrival[j] + Q;
                                            seq.Add(processes[j]);
                                            seq_burst.Add(Q);
                                            seq_start.Add(time - Q);
                                        }
                                        else
                                        {
                                            time = time + remaining[j];
                                            seq.Add(processes[j]);
                                            seq_burst.Add(remaining[j]);
                                            seq_start.Add(time - remaining[j]);
                                            processes[i].set_finish(time);
                                            remaining[j] = 0;
                                        }
                                    }
                                }
                            }

                            // now the previous porcess according to 
                            // ith is process 
                            if (remaining[i] > 0)
                            {
                                flag = false;

                                // Check for greaters 
                                if (remaining[i] > Q)
                                {
                                    time = time + Q;
                                    remaining[i] = remaining[i] - Q;
                                    dyn_arrival[i] = dyn_arrival[i] + Q;
                                    seq.Add(processes[i]);
                                    seq_burst.Add(Q);
                                    seq_start.Add(time - Q);
                                }
                                else
                                {
                                    time = time + remaining[i];
                                    seq.Add(processes[i]);
                                    seq_burst.Add(remaining[i]);
                                    seq_start.Add(time - remaining[i]);
                                    processes[i].set_finish(time);
                                    remaining[i] = 0;
                                }
                            }
                        }
                    }

                    // if no process is come on thse critical 
                    /*else if (dyn_arrival[i] > time)
                    {
                        time++;
                        i--;
                    }*/
                }
                // for exit the while loop 
                if (flag)
                {
                    break;
                }

            }


            List<Color> colours = new List<Color>();
            for (int i = 0; i < number_processes; i++)
            {
                colours.Add(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
            }

            for (int i = 0; i < seq_burst.Count; i++)
            {
                seq[i].set_burst(seq_burst[i]);
                seq[i].set_arrival(seq_start[i]);
                seq[i].set_color(colours[(seq[i].get_index() - 1)]);
            }

            //printing
            for (int i = 0; i < seq_burst.Count; i++)
            {
                process p = seq[i];
                int arrival = seq_start[i];
                int burst = seq_burst[i];


                Color redColor = Color.FromArgb(255, 0, 0);
                SolidBrush brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));


                Label draw = new Label();
                draw.Location = new Point(arrival * scale, 150);
                draw.Size = new Size(burst * scale, 20);
                draw.Text = "P" + (p.get_index()).ToString();
                draw.TextAlign = ContentAlignment.MiddleCenter;
                draw.BackColor = seq[i].get_color();
                gantt.Controls.Add(draw);
                //  time += burst;




                Label b = new Label();
                b.Text = (arrival).ToString();
                b.Location = new Point(arrival * scale, 180);

                b.Font = font;
                b.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(b);


                Label c = new Label();
                c.Text = (time).ToString();
                c.Location = new Point(time * scale, 180);
                c.Font = font;
                c.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(c);


            }
            float tat = 0;
            float wt = 0;
            for (int iq = 0; iq < number_processes; iq++)
            {
                tat += (processes[iq].get_finish() - arrivals[iq]);
                wt += processes[iq].get_finish() - arrivals[iq] - bursts[iq];
            }
            tat /= number_processes;
            wt /= number_processes;



            Label d = new Label();
            d.Text = "TAT= " + (tat).ToString() + "   WT= " + (wt).ToString();
            d.Location = new Point(150, 220);
            d.Font = new Font("Times New Roman", 16.0f);
            d.Size = new System.Drawing.Size(200, 50);
            gantt.Controls.Add(d);






            Button go_back = new Button();
            go_back.Location = new Point(200, 300);
            go_back.Text = "Back";
            go_back.Click += new EventHandler(go_back_Click);
            gantt.Controls.Add(go_back);



        }
        //preemptive priority

        private void prem_priorty_paint()
        {
            int number_processes = int.Parse(number.Text);
            Graphics gObject = gantt.CreateGraphics();
            Random rnd = new Random();
            gantt.Controls.Clear();
            Font font = new Font("Times New Roman", 9.0f);
            int i = 0;
            int lol = 0;
            int count = number_processes;
            int[] arr_time = new int[number_processes];
            int cou = 0;
            Boolean falg = false;
            int cons_count = number_processes;
            List<int> departure = new List<int>();
            Color[] colors = { Color.Red, Color.Gold, Color.Green, Color.Black, Color.Blue, Color.Brown, Color.DarkBlue, Color.DarkGreen, Color.DarkOrange, Color.Aqua, Color.DeepPink, Color.DarkViolet };
            for (int k = 0; k < number_processes; k++)
            {
                processes[k].set_color((Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))));
            }
            //sorting according to arrival
            for (int k = 0; k < number_processes; k++)
            {

                for (int l = 0; l < number_processes; l++)
                {
                    if (processes[k].get_arrival() < processes[l].get_arrival())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                    else if (processes[k].get_arrival() == processes[l].get_arrival() && processes[k].get_priorty() < processes[l].get_priorty())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                }

            }
            for (int l = 0; l < number_processes; l++)
            {
                arr_time[l] = processes[l].get_arrival();
            }
            //then creates a new list to put in it the processes with preemption
            List<process> new_processes = new List<process>();
            for (int t = 0; t < number_processes-1 ; t++)
            {// if priority of next is better than me then create a new process with time equal to nextarrival- myarrival
                //and make my time equal my burst- time taken first before preemption
                for (int o = t + 1; o < number_processes; o++)
                {
                    if (processes[o].get_arrival() > processes[t].get_arrival() && processes[o].get_arrival() > cou)
                    {
                        if (processes[t].get_priorty() > processes[o].get_priorty() || falg == true)
                        {
                            if (processes[t].get_burst() + cou < processes[o].get_arrival())
                            {
                                new_processes.Add(processes[t]);
                                cou += (processes[t].get_burst());
                                processes.RemoveAt(t);
                                number_processes--;



                                int timo = processes[t].get_arrival() - cou;
                                processes[t - 1].set_burst(processes[t - 1].get_burst() - timo);
                                

                                process ph = new process(processes[t - 1].get_arrival(), timo, processes[t - 1].get_index(), processes[t - 1].get_priorty());
                                ph.set_color(processes[t - 1].get_color()); ////////////////////color 3ayz yt3ml?
                                new_processes.Add(ph);
                                cou += ph.get_burst();
                                processes[t - 1].set_arrival(processes[t].get_arrival());

                                /*  for (int u = t-1; u < number_processes; u++)
                                  {
                                      if (processes[u].get_priorty() < processes[t-1].get_priorty())
                                          processes[u].set_priority(processes[u].get_priorty() - 1);
                                  }
                                  processes[t].set_priority(processes[t].get_priorty() - 1);*/
                                for (int y = o ; y < number_processes; y++) {
                                    if (processes[t].get_priorty() > processes[y].get_priorty())
                                    {
                                        int timoo = processes[y].get_arrival() - cou;
                                        processes[t].set_burst(processes[t].get_burst() - timoo);


                                        process phr = new process(processes[t].get_arrival(), timoo, processes[t].get_index(), processes[t].get_priorty());
                                        phr.set_color(processes[t].get_color()); ////////////////////color 3ayz yt3ml?
                                        new_processes.Add(phr);
                                        processes[t].set_arrival(processes[o].get_arrival());

                                        for (int u = t; u < number_processes; u++)
                                        {
                                            if (processes[u].get_priorty() < processes[t].get_priorty())
                                                processes[u].set_priority(processes[u].get_priorty() - 1);
                                        }
                                        processes[t].set_priority(processes[t].get_priorty() - 1);
                                        count++;
                                    }   
                                }
                                

                                count++;
                                continue;

                            }

                            int times = processes[o].get_arrival() - processes[t].get_arrival();

                            processes[t].set_burst(processes[t].get_burst() - times);
                            

                            process p = new process(processes[t].get_arrival(), times, processes[t].get_index(), processes[t].get_priorty());
                            p.set_color(processes[t].get_color()); ////////////////////color 3ayz yt3ml?
                            new_processes.Add(p);
                            processes[t].set_arrival(processes[o].get_arrival());
                            
                            for (int u = t; u < number_processes; u++)
                            {
                                if (processes[u].get_priorty() < processes[t].get_priorty())
                                    processes[u].set_priority(processes[u].get_priorty() - 1);
                                }
                            processes[t].set_priority(processes[t].get_priorty() - 1);
                            for (int y = o + 1; y < number_processes; y++)
                            {
                                if (processes[o].get_priorty() > processes[y].get_priorty())
                                {
                                    falg = true;
                                    break;
                                    
                                }
                                else
                                {
                                    new_processes.Add(processes[o]);
                                    lol = processes[o].get_burst();
                                    cou += (p.get_burst() + processes[o].get_burst());
                                    processes.RemoveAt(o);
                                    number_processes--;

                                    if (processes[o].get_arrival() > cou)
                                    {
                                        int timo = processes[o].get_arrival() - cou;
                                        processes[t].set_burst(processes[t].get_burst() - timo);
                                        

                                        process ph = new process(processes[t].get_arrival(), timo, processes[t].get_index(), processes[t].get_priorty());
                                        ph.set_color(processes[t].get_color()); ////////////////////color 3ayz yt3ml?
                                        new_processes.Add(ph);
                                        processes[t].set_arrival(processes[o].get_arrival() + timo);
                                      
                                        for (int u = t; u < number_processes; u++)
                                        {
                                            if (processes[u].get_priorty() < processes[t].get_priorty())
                                                processes[u].set_priority(processes[u].get_priorty() - 1);
                                        }
                                        processes[t].set_priority(processes[t].get_priorty() - 1);
                                        count++;
                                        break;
                                    }
                                }
                            }
                            if (cou != p.get_burst() + lol)
                            { cou += p.get_burst(); }
                            count++;//make a new counter for the new number of processes
                            
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
            }



            //sorting processes again according to priority to add them to new processes list
            for (int k = 0; k < number_processes; k++)
            {
                for (int l = 0; l < number_processes; l++)
                {
                    if (processes[k].get_priorty() < processes[l].get_priorty())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                    else if (processes[k].get_priorty() == processes[l].get_priorty() && processes[k].get_arrival() < processes[l].get_arrival())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                }

            }
            ////end of sort///
            ///add the processes after sorting to the new processes list
            for (int u = 0; u < number_processes; u++)
            {
                process h = processes[u];
                new_processes.Add(h);
            }

            int time = new_processes[0].get_arrival();

            //printing
            for (i = 0; i < count; i++)
            {
                process p = new_processes[i];
                int arrival = (p.get_arrival() * scale);
                int burst = (p.get_burst() * scale);
                if (time > arrival) arrival = time;
                if (time < arrival) time = arrival;


                Color redColor = Color.FromArgb(255, 0, 0);
                SolidBrush brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));


                Label draw = new Label();
                draw.Location = new Point(arrival, 150);
                draw.Size = new Size(burst, 20);
                draw.Text = "P" + (p.get_index()).ToString();
                draw.TextAlign = ContentAlignment.MiddleCenter;
                draw.BackColor = (p.get_color());
                gantt.Controls.Add(draw);
                time += burst;
                departure.Add(time/scale);



                Label b = new Label();
                b.Text = (arrival / scale).ToString();
                b.Location = new Point(arrival, 180);

                b.Font = font;
                b.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(b);


                Label c = new Label();
                c.Text = (time / scale).ToString();
                c.Location = new Point(time, 180);
                c.Font = font;
                c.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(c);



            }
            float tat = 0;
            float wt = 0;
            for (int iq = 0; iq < count; iq++)
            {
                tat += (departure[iq] - new_processes[iq].get_arrival());
                wt += departure[iq] - new_processes[iq].get_arrival() - new_processes[iq].get_burst();
            }
            tat /= cons_count;
            wt /= cons_count;

            Label d = new Label();
            d.Text = "TAT= " + (tat).ToString() + "   WT= " + (wt).ToString();
            d.Location = new Point(150, 220);
            d.Font = new Font("Times New Roman", 16.0f);
            d.Size = new System.Drawing.Size(200, 50);
            gantt.Controls.Add(d);

            




            Button go_back = new Button();
            go_back.Location = new Point(200, 300);
            go_back.Text = "Back";
            go_back.Click += new EventHandler(go_back_Click);
            gantt.Controls.Add(go_back);




        }

        //srtf 
        private void srtf_paint()
        {
            int number_processes = int.Parse(number.Text);
            Graphics gObject = gantt.CreateGraphics();
            Random rnd = new Random();
            gantt.Controls.Clear();
            Font font = new Font("Times New Roman", 9.0f);
            int i = 0;
            int lol = 0;
            int count = number_processes;
            int[] arr_time = new int[number_processes];
            int cou = 0;
            Boolean falg = false;
            int cons_count = number_processes;
            List<int> departure = new List<int>();
            // Dictionary<int,int>departure=new Dictionary<int,int>();
            //List<int> remain = new List<int>();

            //SETTING COLOR
            for (int k = 0; k < number_processes; k++)
            {
                processes[k].set_color((Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))));
            }
            //sorting according to arrival
            for (int k = 0; k < number_processes; k++)
            {

                for (int l = 0; l < number_processes; l++)
                {
                    if (processes[k].get_arrival() < processes[l].get_arrival())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                    else if (processes[k].get_arrival() == processes[l].get_arrival() && processes[k].get_priorty() < processes[l].get_priorty())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                }

            }
            for (int l = 0; l < number_processes; l++)
            {
                arr_time[l] = processes[l].get_arrival();
            }
            //then creates a new list to put in it the processes with preemption
            List<process> new_processes = new List<process>();
            for (int t = 0; t < number_processes - 1; t++)
            {// if priority of next is better than me then create a new process with time equal to nextarrival- myarrival
                //and make my time equal my burst- time taken first before preemption
                for (int o = t + 1; o < number_processes; o++)
                {
                    if (processes[o].get_arrival() > processes[t].get_arrival() && processes[o].get_arrival() > cou)
                    {
                        if (processes[t].get_burst() > processes[o].get_burst() || falg == true)
                        {
                            if (processes[t].get_burst() + cou < processes[o].get_arrival())
                            {
                                new_processes.Add(processes[t]);
                                cou += (processes[t].get_burst());
                                processes.RemoveAt(t);
                                number_processes--;



                                int timo = processes[t].get_arrival() - cou;
                                processes[t - 1].set_burst(processes[t - 1].get_burst() - timo);


                                process ph = new process(processes[t - 1].get_arrival(), timo, processes[t - 1].get_index(), processes[t - 1].get_priorty());
                                ph.set_color(processes[t - 1].get_color()); ////////////////////color 3ayz yt3ml?
                                new_processes.Add(ph);
                                processes[t-1].set_arrival(processes[o].get_arrival());

                                for (int u = t; u < number_processes; u++)
                                {
                                    if (processes[u].get_priorty() < processes[t-1].get_priorty())
                                        processes[u].set_priority(processes[u].get_priorty() - 1);
                                }
                                processes[t-1].set_priority(processes[t-1].get_priorty() - 1);
                                count++;
                                break;

                            }
                            int times = processes[o].get_arrival() - processes[t].get_arrival();

                            processes[t].set_burst(processes[t].get_burst() - times);


                            process p = new process(processes[t].get_arrival(), times, processes[t].get_index(), processes[t].get_priorty());
                            p.set_color(processes[t].get_color()); ////////////////////color 3ayz yt3ml?
                            new_processes.Add(p);
                            processes[t].set_arrival(processes[o].get_arrival());

                            for (int u = t; u < number_processes; u++)
                            {
                                if (processes[u].get_priorty() < processes[t].get_priorty())
                                    processes[u].set_priority(processes[u].get_priorty() - 1);
                            }
                            processes[t].set_priority(processes[t].get_priorty() - 1);
                            for (int y = o + 1; y < number_processes; y++)
                            {
                                if (processes[o].get_burst() > processes[y].get_burst())
                                {
                                    falg = true;
                                    break;
                                    /* int timess = processes[y].get_arrival() - processes[o].get_arrival();
                                     processes[o].set_burst(processes[o].get_burst() - timess);

                                     process pr = new process(processes[o].get_arrival(), timess, processes[o].get_index(), processes[o].get_priorty());
                                     pr.set_color(Color.DeepPink);
                                     new_processes.Add(pr);
                                     count++;
                                     new_processes.Add(processes[y]);
                                     processes.RemoveAt(y);
                                     number_processes--;
                                     cou += (pr.get_burst() + processes[y].get_burst());*/
                                }
                                else
                                {
                                    new_processes.Add(processes[o]);
                                    lol = processes[o].get_burst();
                                    cou += (p.get_burst() + processes[o].get_burst());
                                    processes.RemoveAt(o);
                                    number_processes--;

                                    int timo = processes[o].get_arrival() - cou;
                                    processes[t].set_burst(processes[t].get_burst() - timo);


                                    process ph = new process(processes[t].get_arrival(), timo, processes[t].get_index(), processes[t].get_priorty());
                                    ph.set_color(processes[t].get_color()); ////////////////////color 3ayz yt3ml?
                                    new_processes.Add(ph);
                                    processes[t].set_arrival(processes[o].get_arrival());

                                    for (int u = t; u < number_processes; u++)
                                    {
                                        if (processes[u].get_priorty() < processes[t].get_priorty())
                                            processes[u].set_priority(processes[u].get_priorty() - 1);
                                    }
                                    processes[t].set_priority(processes[t].get_priorty() - 1);
                                    count++;
                                    break;

                                }
                            }
                            if (cou != p.get_burst() + lol)
                            { cou += p.get_burst(); }
                            count++;//make a new counter for the new number of processes
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
            }
            //sorting processes again according to srtf to add them to new processes list
            for (int k = 0; k < number_processes; k++)
            {
                for (int l = 0; l < number_processes; l++)
                {
                    if (processes[k].get_burst() < processes[l].get_burst())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                    else if (processes[k].get_burst() == processes[l].get_burst() && processes[k].get_arrival() < processes[l].get_arrival())
                    {
                        process t = processes[k];
                        processes[k] = processes[l];
                        processes[l] = t;
                    }
                }

            }
            ////end of sort///
            ///add the processes after sorting to the new processes list
            for (int u = 0; u < number_processes; u++)
            {
                process h = processes[u];
                new_processes.Add(h);
            }

            int time = new_processes[0].get_arrival();

            //printing
            for (i = 0; i < count; i++)
            {
                process p = new_processes[i];
                int arrival = (p.get_arrival() * scale);
                int burst = (p.get_burst() * scale);
                if (time > arrival) arrival = time;
                if (time < arrival) time = arrival;


                Color redColor = Color.FromArgb(255, 0, 0);
                SolidBrush brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));


                Label draw = new Label();
                draw.Location = new Point(arrival, 150);
                draw.Size = new Size(burst, 20);
                draw.Text = "P" + (p.get_index()).ToString();
                draw.TextAlign = ContentAlignment.MiddleCenter;
                draw.BackColor = (p.get_color());
                gantt.Controls.Add(draw);
                time += burst;
                departure.Add(time / scale);
               /* if (departure.ContainsKey(p.get_index()))
                    departure[p.get_index()] = time;
                else
                    departure.Add(p.get_index(), time);
           */
                Label b = new Label();
                b.Text = (arrival/scale).ToString();
                b.Location = new Point(arrival, 180);
                b.Font = font;
                b.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(b);


                Label c = new Label();
                c.Text = (time/scale).ToString();
                c.Location = new Point(time, 180);
                c.Font = font;
                c.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(c);

            }

            float tat = 0;
            float wt = 0;
            for (int iq = 0; iq < count; iq++)
            {
                tat += (departure[iq] - new_processes[iq].get_arrival());
                wt += departure[iq] - new_processes[iq].get_arrival() - new_processes[iq].get_burst();
            }
            tat /= cons_count;
            wt /= cons_count;
            Label d = new Label();
            d.Text = "TAT= " + (tat).ToString() + "   WT= " + (wt).ToString();
            d.Location = new Point(150, 220);
            d.Font = new Font("Times New Roman", 16.0f);
            d.Size = new System.Drawing.Size(200, 50);
            gantt.Controls.Add(d);

            Button go_back = new Button();
            go_back.Location = new Point(200, 270);
            go_back.Text = "Back";
            go_back.Click += new EventHandler(go_back_Click);
            gantt.Controls.Add(go_back);

            departure.Clear();


        }










        private void gantt_Paint()
        {
            int number_processes = int.Parse(number.Text);
            Graphics gObject = gantt.CreateGraphics();
            Random rnd = new Random();
            gantt.Controls.Clear();
            Font font = new Font("Times New Roman", 9.0f);



            for (int i = 0, j = 10; i < number_processes; i++)
            {

                Color redColor = Color.FromArgb(255, 0, 0);
                SolidBrush brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                gObject.FillRectangle(brush, j, 150, 480 / number_processes, 20); //total width of screen is 480
                j += 480 / number_processes;
                Label a = new Label();
                a.Text = "P" + (i + 1).ToString();
                a.Location = new Point(j-240/number_processes, 200);
                a.Name = "P" + (i + 1).ToString();
                a.Font = font;
                a.Size = new System.Drawing.Size(40, 17);
                gantt.Controls.Add(a);

            }
            Button go_back = new Button();
            go_back.Location = new Point(200, 250);
            go_back.Text = "Back";
            go_back.Click += new EventHandler(go_back_Click);
            gantt.Controls.Add(go_back);
           


        }
        private void go_back_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            tabcnt.SelectTab("config");
            gantt.Controls.Clear();
            processes.Clear();
           
        }


        private void arrival_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (number.Text == "")
            {

                time.Hide();
                arrival.Hide();
                priorty_list.Hide();

            }
            else if (number.Text != null)
            {
                A.Clear();
                T.Clear();
                P.Clear();
                processes.Clear();
                try
                {
                    int number_of_processes = int.Parse(number.Text);
                    int pointX = 0;
                    int pointY = 20;

                    arrival.Controls.Clear();
                    time.Controls.Clear();
                    priorty_list.Controls.Clear();
                    gantt.Controls.Clear();
                    for (int i = 0; i < number_of_processes; i++)
                    {
                        TextBox a = new TextBox();
                        a.Text = "P" + (i + 1).ToString();
                        a.Location = new Point(pointX, pointY);
                        A.Add(i + 1, a);
                        arrival.Controls.Add(a);
                        arrival.Show();
                        pointY += 25;
                    }
                    pointY = 20;
                    for (int i = 0; i < number_of_processes; i++)
                    {
                        TextBox a = new TextBox();
                        a.Text = "P" + (i + 1).ToString();
                        a.Location = new Point(pointX, pointY);
                        T.Add(i + 1, a);
                        time.Controls.Add(a);
                        time.Show();
                        pointY += 25;
                    }

                    pointY = 20;

                    for (int i = 0; i < number_of_processes; i++)
                    {
                        TextBox a = new TextBox();
                        a.Text = "0";
                        a.Location = new Point(pointX, pointY);
                        P.Add(i + 1, a);
                        priorty_list.Controls.Add(a);
                        priorty_list.Show();
                        pointY += 25;
                    }


                }
                catch (Exception)
                {
                    /*MessageBox.Show(e.ToString());*/
                    MessageBox.Show("ERROR!");
                }


            }


        }

        private void time_Enter(object sender, EventArgs e)
        {

        }

        private void priort_list_Enter(object sender, EventArgs e)
        {

        }

        private void priorty_CheckedChanged(object sender, EventArgs e)
        {
            if ((priorty.Checked || prem_priorty.Checked) && number.Text != null)
                priorty_list.Enabled = true;
            else
            {
                priorty_list.Enabled = false;

            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void prem_priorty_CheckedChanged(object sender, EventArgs e)
        {
            if ((priorty.Checked || prem_priorty.Checked) && number.Text != null)
                priorty_list.Enabled = true;
            else
            {
                priorty_list.Enabled = false;

            }

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            number.Text = "";
            tabcnt.SelectTab("config");

        }

        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(13))
            {


                string arrival_text;
                string burst_text;
                int number_of_processes = int.Parse(number.Text);
                for (int i = 0; i < number_of_processes; i++)
                {
                    arrival_text = A.Values.ElementAt(i).Text;
                    burst_text = T.Values.ElementAt(i).Text;
                  
                }

                tabcnt.SelectTab("gantt");
                fcfs_paint();
            }

        }

        private void roundrobbin_CheckedChanged(object sender, EventArgs e)
        {
            if (roundrobbin.Checked)
                quantum.Enabled = true;
            else
                quantum.Enabled = false;
        }
    }
}

class process
{
    int arrival;
    int burst;
    int index;
    int priorty;
    Color color;
    int finish;
    


    public process(int arrival, int burst,int index,int priorty)
    {
        this.arrival = arrival;
        this.burst = burst;
        this.index = index;
        this.priorty = priorty;
        
    }
    public int get_arrival()
    {
        return arrival;
    }
    public int get_burst()
    {
        return burst;
    }
    public int get_index()
    {
        return index;
    }

    public int get_priorty()
    {
        return priorty;
    }
    public void set_burst(int burst)
    {
        this.burst = burst;
    }
    public void set_arrival(int arrival)
    {
        this.arrival = arrival;
    }
    public void set_index(int index)
    {
        this.index = index;
    }
    public void set_priority(int priorty)
    {
        this.priorty = priorty;
    }
    public void set_color(Color color)
    {
        this.color = color;
    }
    public Color get_color()
    {
       return color;
    }
    public int get_finish()
    {
        return finish;
    }
    public void set_finish(int finish)
    {
        this.finish = finish;
    }
}





