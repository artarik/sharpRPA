﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharpRPA.UI.Forms.Supplemental
{
    public partial class frmShowCursorPosition : UIForm
    {

        public POINT lpPoint;
        public int xPos { get; set; }
        public int yPos { get; set; }
        public frmShowCursorPosition()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        private void tmrGetPosition_Tick(object sender, EventArgs e)
        {
    
            GetCursorPos(out lpPoint);
            lblXPosition.Text = "X Position: " + lpPoint.X;
            lblYPosition.Text = "Y Position: " + lpPoint.Y;
            xPos = lpPoint.X;
            yPos = lpPoint.Y;



        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        private void ShowCursorPosition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
               this.DialogResult = DialogResult.OK;
            }
        }

        private void ShowCursorPosition_Load(object sender, EventArgs e)
        {
           
        }

        private void frmShowCursorPosition_MouseEnter(object sender, EventArgs e)
        {
            //move to bottom right if form is in the way
            MoveFormToBottomRight(this);
          
        }
    }


}
