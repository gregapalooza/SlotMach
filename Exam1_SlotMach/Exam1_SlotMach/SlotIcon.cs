using System;
using System.Drawing;
using System.Windows.Forms;
using Exam1_SlotMach.Properties;

namespace Exam1_SlotMach
{
    class SlotIcon : PictureBox
    {
        static Random rand = new Random();

        private int slotValue;

        public int SlotValue
        {
            get => slotValue;
            set => slotValue = value;
        }
        /// <summary>
        /// Assigns a number to array spot.
        /// </summary>
        /// <returns></returns>
        public int AssignValue()
        {
            slotValue = rand.Next(1, 11);
            return slotValue;
        }
        /// <summary>
        /// Depending on the value given method gets a img for the array. Has 10 cases.
        /// </summary>
        /// <param name="slotValue"></param>
        /// <returns></returns>
        public static Bitmap GetImage(int slotValue)
        {
            Bitmap bm = null;

            switch (slotValue)
            {
                case 1:
                    bm = Resources._1;
                    break;
                case 2:
                    bm = Resources._2;
                    break;
                case 3:
                    bm = Resources._3;
                    break;
                case 4:
                    bm = Resources._4;
                    break;
                case 5:
                    bm = Resources._5;
                    break;
                case 6:
                    bm = Resources._6;
                    break;
                case 7:
                    bm = Resources._7;
                    break;
                case 8:
                    bm = Resources._8;
                    break;
                case 9:
                    bm = Resources._9;
                    break;
                case 10:
                    bm = Resources._10;
                    break;
            }

            return bm;
        }
    }
}
