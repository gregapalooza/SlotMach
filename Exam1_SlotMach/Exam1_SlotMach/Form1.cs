using Exam1_SlotMach.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Exam1_SlotMach
{
    public partial class Form1 : Form
    {
        #region ---- private props ----
        private SlotIcon[] pictures = new SlotIcon[3];
        private int[] compareArry = new int[3];
        private double total;
        #endregion

        #region -------- form controls --------
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            LoadNewArry();
            ThreeOfAKind(compareArry);  
        }
        #endregion

        #region ---- Main methods ----
        /// <summary>
        /// This will create a placeholder image on form load.
        /// </summary>
        public void StartUp()
        {
            // Fills pictures array with stock images for initial play this is just for looks
            for (int i = 0; i < pictures.Length; i++)
            {
                pictures[i] = new SlotIcon();
                pictures[i].Image = Resources._17; // Just random img outside the range of possible ran int
                int xloc = 81 + (i * 118);
                pictures[i].Location = new System.Drawing.Point(xloc, 245);
                pictures[i].Name = "pictureBox" + i;
                pictures[i].Size = new System.Drawing.Size(59, 90);
                pictures[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictures[i].TabIndex = 0;
                pictures[i].TabStop = false;

                this.Controls.Add(pictures[i]);
                textBoxTotal.Text = total.ToString("c");
            }
        }

        /// <summary>
        /// This method creates a new array of slot images.
        /// </summary>
        public void LoadNewArry()
        {
            for (int i = 0; i < pictures.Length; i++)
            {
                LoadSlot(i);
            }
        }

        /// <summary>
        /// Method creates the pictureboxes with the slot images passes i from LoadNewArry()
        /// </summary>
        /// <param name="i"></param>
        public void LoadSlot(int i)
        {
            pictures[i] = new SlotIcon();
            pictures[i].SlotValue = pictures[i].AssignValue();
            compareArry[i] = pictures[i].SlotValue;                         // Populates compareArry using value assigned to icons in resources.
            pictures[i].Image = SlotIcon.GetImage(pictures[i].SlotValue);
            // Fits icons into slot area in the background.
            int xloc = 81 + (i * 118);
            pictures[i].Location = new System.Drawing.Point(xloc, 245);

            pictures[i].Name = "slot: " + i;
            pictures[i].Size = new System.Drawing.Size(59, 90);             // needs to fit in with background img (size is unique).
            pictures[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictures[i].TabIndex = 0;
            pictures[i].TabStop = false;

            this.Controls.Add(pictures[i]);
        }

        /// <summary>
        /// Method compares the second array created with the values of the images and compares them to reward the player money and congradulates them on a jackpot.
        /// </summary>
        /// <param name="compareArry"></param>
        public void ThreeOfAKind(int[] compareArry)
        {
            if (compareArry[0] == compareArry[1])
            {
                if (compareArry[0] == compareArry[2]) // Nested if is to check for 3-o-kind.
                {
                    total += 1.00;
                    textBoxJackPot.Visible = true; // Jackpot message.
                }
                else
                {
                    total += 0.10;
                }

                textBoxTotal.Text = total.ToString("c");
            }
            else if ((compareArry[0] == compareArry[2]) || (compareArry[1] == compareArry[2]))
            {
                total += 0.10;
                textBoxTotal.Text = total.ToString("c");
            }
        }

        /// <summary>
        /// Method resets the initial array to be filled again with new pics.
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < pictures.Length; i++)
            {
                pictures[i].Dispose(); // Empty the images for new ones.
            }
            textBoxJackPot.Visible = false; // Jackpot message disappears.
        }
        #endregion
    }
}
