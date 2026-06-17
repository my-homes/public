using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace SimpleVideoPlayer
{
    public partial class Form1 : Form
    {
        //VLC stuff
        public LibVLC _libVLC;
        public MediaPlayer _mp;
        public Media media;

        public bool isFullscreen = false;
        public bool isPlaying = false;
        public Size oldVideoSize;
        public Size oldFormSize;
        public Point oldVideoLocation;

        public Form1()
        {
            InitializeComponent();
            Core.Initialize();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(ShortcutEvent);
            oldVideoSize = videoView1.Size;
            oldFormSize = this.Size;
            oldVideoLocation = videoView1.Location;
            //VLC stuff
            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mp;
        }

        public void ShortcutEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && isFullscreen) // from fullscreen to window
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; // change form style
                this.WindowState = FormWindowState.Normal; // back to normal size
                this.Size = oldFormSize;
                menuStrip1.Visible = true; // the return of the menu strip 
                videoView1.Size = oldVideoSize; // make video the same size as the form
                videoView1.Location = oldVideoLocation; // remove the offset
                isFullscreen = false;
            }

            if (isPlaying) // while the video is playing
            {
                if (e.KeyCode == Keys.Space) // Pause and Play
                {
                    if (_mp.State == VLCState.Playing)
                    {
                        _mp.Pause();
                    }
                    else
                    {
                        _mp.Play();
                    }
                }

                if (e.KeyCode == Keys.J) // skip 1% backwards
                {
                    _mp.Position -= 0.01f;
                }
                if (e.KeyCode == Keys.L) // skip 1% forwards
                {
                    _mp.Position += 0.01f;
                }
            }
        }

        private void goFullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false; // goodbye menu strip
            videoView1.Size = this.Size; // make video the same size as the form
            videoView1.Location = new Point(0, 0); // remove the offset
            this.FormBorderStyle = FormBorderStyle.None; // cheange form style
            this.WindowState = FormWindowState.Maximized;
            isFullscreen = true;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 url_ofd = new Form2();
            url_ofd.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                PlayFile(ofd.FileName);
            }
        }

        public void PlayFile(string file)
        {
            _mp.Play(new Media(_libVLC, file));
            isPlaying = true;
        }
        public void PlayURLFile(string file)
        {
            _mp.Play(new Media(_libVLC, new Uri(file)));
            isPlaying = true;
        }
    }
}
