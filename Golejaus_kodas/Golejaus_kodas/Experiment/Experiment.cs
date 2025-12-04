using System;
using System.Collections.Generic;
using System.Text;
using Golejaus_kodas.Channel;
using Golejaus_kodas.GolayCode;
using Golejaus_kodas.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Golejaus_kodas.Experiment
{
    internal class Experiment
    {
        public static (float[] errorProbability, float[] averageErrorPercentage) experimentWithEncoding()
        {
            float[] errorProbability = new float[100];
            float[] averageErrorPercentage = new float[100];
            byte[] vector = VectorTools.nullVector;
            GolayDecoding decoder = new GolayDecoding();
            GolayEncoding encoder = new GolayEncoding();
            vector = encoder.encodeVector(vector);

            for (int i=0; i<100; ++i)
            {
                errorProbability[i] = (float)(i * 0.01);
                ChannelWithError channel = new ChannelWithError();
                channel.setErrorProbability((float)errorProbability[i]);
                int totalErrorCount = 0;
                for (int j=0; j<100; ++j)
                {
                    byte[] receivedVector = channel.SendThroughChannel(vector);
                    byte[] decodedVector = decoder.decode(receivedVector);
                    totalErrorCount += VectorTools.getErrorInfo(vector, decodedVector).errorCount;
                }
                averageErrorPercentage[i] = (float)totalErrorCount / (vector.Length * 100) * 100f;
            }
            return (errorProbability, averageErrorPercentage);
        }

        public static (float[] errorProbability, float[] averageErrorPercentage) experimentWithoutEncoding()
        {
            float[] errorProbability = new float[100];
            float[] averageErrorPercentage = new float[100];
            byte[] vector = VectorTools.nullVector;

            for (int i = 0; i < 100; ++i)
            {
                errorProbability[i] = (float)(i * 0.01);
                ChannelWithError channel = new ChannelWithError();
                channel.setErrorProbability((float)errorProbability[i]);
                int totalErrorCount = 0;
                for (int j = 0; j < 100; ++j)
                {
                    byte[] receivedVector = channel.SendThroughChannel(vector);
                    totalErrorCount += VectorTools.getErrorInfo(vector, receivedVector).errorCount;
                }
                averageErrorPercentage[i] = (float)totalErrorCount / (vector.Length * 100) * 100f;
            }
            return (errorProbability, averageErrorPercentage);
        }
        public static void GenerateErrorGraph(string outputFilePath)
        {
            // 1️⃣ Run experiments
            var (probWithEncoding, errorWithEncoding) = experimentWithEncoding();
            var (probWithoutEncoding, errorWithoutEncoding) = experimentWithoutEncoding();

            // 2️⃣ Create chart
            Chart chart = new Chart();
            chart.Size = new Size(1000, 600);

            ChartArea area = new ChartArea();
            area.AxisX.Title = "Error Probability";
            area.AxisY.Title = "Bit Error Percentage (%)";
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 1;
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 100;
            chart.ChartAreas.Add(area);

            // 3️⃣ Series for 'With Encoding'
            Series seriesWith = new Series("With Golay Encoding");
            seriesWith.ChartType = SeriesChartType.Line;
            seriesWith.BorderWidth = 2;
            seriesWith.Color = Color.Green;
            chart.Series.Add(seriesWith);

            for (int i = 0; i < probWithEncoding.Length; i++)
            {
                seriesWith.Points.AddXY(probWithEncoding[i], errorWithEncoding[i]);
            }

            // 4️⃣ Series for 'Without Encoding'
            Series seriesWithout = new Series("Without Encoding");
            seriesWithout.ChartType = SeriesChartType.Line;
            seriesWithout.BorderWidth = 2;
            seriesWithout.Color = Color.Red;
            chart.Series.Add(seriesWithout);

            for (int i = 0; i < probWithoutEncoding.Length; i++)
            {
                seriesWithout.Points.AddXY(probWithoutEncoding[i], errorWithoutEncoding[i]);
            }

            // 5️⃣ Optional styling
            chart.Legends.Add(new Legend());
            chart.Titles.Add("Channel Error vs Residual Error with/without Golay Encoding");

            // 6️⃣ Save as PNG
            chart.SaveImage(outputFilePath, ChartImageFormat.Png);
            Console.WriteLine($"Graph saved as {outputFilePath}");
        }
    }
}
