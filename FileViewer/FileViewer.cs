using System;
using System.IO;
using System.Linq;
using System.Drawing;

class scheduleReader{
static void Main(){
    Schedule[] imagesList = ScheduleReader();
    FileCompletion(imagesList);
    Console.ReadLine();
    }

static async Task FileViewer(Schedule imageData){
    string[] monitorSelection = imageData.monitorSelection.Split('.');
    string date = imageData.date;
    string startTimeData = imageData.timeStart + ":00";
    string endTimeData = imageData.timeEnd + ":00";
    DateTime timeStart = Convert.ToDateTime(startTimeData);
    DateTime timeEnd = Convert.ToDateTime(endTimeData);
    int[] monitors = new int[monitorSelection.Length];
    for(int i = 0; i < monitorSelection.Length; i++){
        monitors[i] = Convert.ToInt32(monitorSelection[i]);
    }
    while(DateTime.Now != timeStart){
        //wait 1 minute
        if (DateTime.Now == timeStart){
            while(DateTime.Now != timeEnd){
                //display image
                Image newImage = Image.FromFile(imageData.pathToImage);
                Point ulCorner = new Point(100, 100);
                Graphics.DrawImage(newImage, ulCorner);
                //wait 1 minute
                if (DateTime.Now == timeEnd){
                    break;
                }
            }
        }
    }
}

static async void FileCompletion(Schedule[] imagesList){
    bool[] boolImagesList = new bool[imagesList.Length];
    for(int i = 0; i < imagesList.Length; i++){
        boolImagesList = FileViewer(imagesList[i]);
        }
}

static Schedule[] ScheduleReader(){ 
    string pathToSchedule = "/home/pi/Desktop/schedule.txt";
    var lineCount = File.ReadLines(pathToSchedule).Count();
    Schedule[] imagesToDisplay = new Schedule[lineCount];
    string[] lines = File.ReadAllLines(pathToSchedule);
    for(int i = 0; i < lineCount; i++){ 
        string[] data = lines[i+1].Split(',');
        Schedule displayFile = new Schedule();
        displayFile.date = data[0];
        displayFile.timeStart = data[1];
        displayFile.timeEnd = data[2];
        displayFile.pathToImage = data[3];
        displayFile.monitorSelection = data[4];
        imagesToDisplay[i] = displayFile;
    }
    return imagesToDisplay;
    //Debug Loop
    /*for(int i = 0; i < imagesToDisplay.Length; i++){
        Console.WriteLine("" + imagesToDisplay[i].date + imagesToDisplay[i].time);
    }*/
}

struct Schedule{
    public string date;
    public string timeStart;
    public string timeEnd;
    public string pathToImage;
    public string monitorSelection;
    }
}