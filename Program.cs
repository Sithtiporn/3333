using System;
using System.IO;

public class ImageProcessor
{
    public static void Main()
    {
        string inputImagePath = "input_image.txt";
        string kernelPath = "convolution_kernel.txt";
        string outputImagePath = "output_image.txt";

        double[,] inputImage = ReadImageDataFromFile(inputImagePath);

        double[,] kernel = ReadImageDataFromFile(kernelPath);

        double[,] convolvedImage = ConvolveImage(inputImage, kernel);

        WriteImageDataToFile(outputImagePath, convolvedImage);
    }

    public static double[,] ReadImageDataFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        int height = lines.Length;
        int width = lines[0].Split(',').Length;
        double[,] imageData = new double[height, width];

        for (int i = 0; i < height; i++)
        {
            string[] values = lines[i].Split(',');
            for (int j = 0; j < width; j++)
            {
                imageData[i, j] = Convert.ToDouble(values[j]);
            }
        }

        return imageData;
    }

    public static void WriteImageDataToFile(string filePath, double[,] imageData)
    {
        int height = imageData.GetLength(0);
        int width = imageData.GetLength(1);
        string[] lines = new string[height];

        for (int i = 0; i < height; i++)
        {
            string[] values = new string[width];
            for (int j = 0; j < width; j++)
            {
                values[j] = imageData[i, j].ToString();
            }
            lines[i] = string.Join(", ", values);
        }

        File.WriteAllLines(filePath, lines);
    }

    public static double[,] ConvolveImage(double[,] inputImage, double[,] kernel)
    {
        int inputHeight = inputImage.GetLength(0);
        int inputWidth = inputImage.GetLength(1);
        int kernelHeight = kernel.GetLength(0);
        int kernelWidth = kernel.GetLength(1);
        int outputHeight = inputHeight - kernelHeight + 1;
        int outputWidth = inputWidth;
        }
    }