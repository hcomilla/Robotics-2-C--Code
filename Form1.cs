using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboticsIIFinalCountdownProjectExtraordinaire
{
    public partial class Form1 : Form
    {
        VideoCapture _capture;
        Thread _captureThread;
        SerialPort arduinoSerial = new SerialPort();
        bool enableCoordinateSending = true;
        Thread serialMonitoringThread;
        public Form1()
        {
            InitializeComponent();
        }

        public void ProcessImage()
        {
            while (_capture.IsOpened)
            {
                Mat workingImage = _capture.QueryFrame();
                var imgConv = workingImage.ToImage<Bgr, byte>();
                imgConv.ROI = new Rectangle(70, 60, workingImage.Width - 140, workingImage.Height - 120);
                workingImage = imgConv.Mat;
                // resize to PictureBox aspect ratio
                int newHeight = workingImage.Size.Height * sourcePictureBox.Size.Width / workingImage.Size.Width;
                Size newSize = new Size(sourcePictureBox.Size.Width, newHeight);
                CvInvoke.Resize(workingImage, workingImage, newSize);
                // as a test for comparison, create a copy of the image with a binary filter:
                var binaryImage = workingImage.ToImage<Gray, byte>().ThresholdBinary(new Gray(125), new
                Gray(255)).Mat;
                // Sample for gaussian blur:
                var blurredImage = new Mat();
                var cannyImage = new Mat();
                var decoratedImage = new Mat();
                var radiusImage = new Mat(); 
                decoratedImage = workingImage.Clone();
                radiusImage = decoratedImage.Clone();
                // find contours:
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    // Build list of contours
                    CvInvoke.FindContours(binaryImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    int radius = 3;
                    int thickness = 1;
                    int countedContours = 0;
                    int scaledX = 0;
                    int scaledY = 0;
                    int sortingShapes = 0;
                    for (int i = 0; i < contours.Size; i++)
                    {
                        VectorOfPoint contour = contours[i];
                        double area = CvInvoke.ContourArea(contour);
                        if (area > 2000 || area < 260) //mess with this for mounting camera
                        {
                            continue;
                        }
                        countedContours++;
                        Rectangle boundingBox = CvInvoke.BoundingRectangle(contour);
                        Point center = new Point(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height / 2);
                        scaledX = (int)Math.Round((center.X * 22) / (double)workingImage.Size.Width);
                        scaledY = (int)Math.Round((center.Y * 17) / (double)workingImage.Size.Height);

                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                            // get an array of points in the contour
                            Point[] points = approxContour.ToArray();
                            // if array length isn't 4, something went wrong, abort warping process (for demo, draw points instead)
                            if (points.Length == 4)
                            {
                                CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.Green).MCvScalar, 2);
                                CvInvoke.Circle(radiusImage, center, radius, new Bgr(Color.Orange).MCvScalar, thickness);
                                //categorizing shapes as 0 or 1 (0 is square, 1 is triangle)
                                sortingShapes = 0;
                            }
                            else if (points.Length == 3)
                            {
                                CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.DeepPink).MCvScalar, 2);
                                CvInvoke.Circle(radiusImage, center, radius, new Bgr(Color.Purple).MCvScalar, thickness);
                                //categorizing shapes as 0 or 1 (0 is square, 1 is triangle)
                                sortingShapes = 1;
                            }
                            else
                            {
                                CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.Red).MCvScalar, 2);
                            }

                    
                        }

                        //sending to arduino coordinates and if it is a sqaure or triangle
                        if (enableCoordinateSending)
                        {
                            if (scaledX >= 0 && scaledY >= 0)
                            {
                                byte[] buffer = new byte[5]
                                {
                                Encoding.ASCII.GetBytes("<")[0],
                                Convert.ToByte(sortingShapes),
                                Convert.ToByte(scaledX),
                                Convert.ToByte(scaledY),
                                Encoding.ASCII.GetBytes(">")[0]
                                };
                                arduinoSerial.Write(buffer, 0, 5);
                                enableCoordinateSending = false;
                            }
                            else
                            {
                                MessageBox.Show("X and Y values must be integers", "Unable to parse coordinates");
                            }
                        }
                    }


                    Invoke(new Action(() =>
                    {
                        contourLabel.Text = $"There are {countedContours} contours detected";
                        coordinateLabel.Text = $"Coordinates: {scaledX},{scaledY} Shape: {sortingShapes}";
                    }));
                }
                // output images:
                sourcePictureBox.Image = workingImage.Bitmap;
                coloredPictureBox.Image = decoratedImage.Bitmap;
                radiusPictureBox.Image = radiusImage.Bitmap;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1 is external camera and zero is laptop camera
            _capture = new VideoCapture(1);
            _captureThread = new Thread(ProcessImage);
            _captureThread.Start();
            try
            {
                arduinoSerial.PortName = "COM15";
                arduinoSerial.BaudRate = 9600;
                arduinoSerial.Open();
                serialMonitoringThread = new Thread(MonitorSerialData);
                serialMonitoringThread.Start();
                xInput.Text = "130";
                yInput.Text = "224";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Initializing COM port");
                Close();
            }
        }

        private void MonitorSerialData()
        {
            while (true)
            {
                // block until \n character is received, extract command data
                string msg = arduinoSerial.ReadLine();
                // confirm the string has both < and > characters
                if (msg.IndexOf("<") == -1 || msg.IndexOf(">") == -1)
                {
                    continue;
                }
                // remove everything before (and including) the < character
                msg = msg.Substring(msg.IndexOf("<") + 1);
                // remove everything after (and including) the > character
                msg = msg.Remove(msg.IndexOf(">"));
                // if the resulting string is empty, disregard and move on
                if (msg.Length == 0)
                {
                    continue;
                }
                // parse the command
                if (msg.Substring(0, 1) == "S")
                {
                    // command is to suspend, toggle states accordingly:
                    ToggleFieldAvailability(msg.Substring(1, 1) == "1");
                }
                else if (msg.Substring(0, 1) == "P")
                {
                    // command is to display the point data, output to the text field:
                    Invoke(new Action(() =>
                    {
                        returnedPointLbl.Text = $"Returned Point Data: {msg.Substring(1)}";
                    }));
                }
            }
        }
        private void ToggleFieldAvailability(bool suspend)
        {
            Invoke(new Action(() =>
            {
                enableCoordinateSending = !suspend;
                lockStateToolStripStatusLabel.Text = $"State: {(suspend ? "Locked" : "Unlocked")}";
            }));
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialMonitoringThread.Abort();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!enableCoordinateSending)
            {
                MessageBox.Show("Temporarily locked...");
                return;
            }
            int x = -1;
            int y = -1;
            if (int.TryParse(xInput.Text, out x) && int.TryParse(yInput.Text, out y))
            {
                byte[] buffer = new byte[5] {
                    Encoding.ASCII.GetBytes("<")[0],
                    Convert.ToByte(0),
                    Convert.ToByte(x),
                    Convert.ToByte(y),
                    Encoding.ASCII.GetBytes(">")[0]
                };
                arduinoSerial.Write(buffer, 0, 5);
            }
            else
            {
                MessageBox.Show("X and Y values must be integers", "Unable to parse coordinates");
            }
        }
    }
}
