using System;
using System.IO;
using System.Linq;

class scheduleReader{
static void Main(){
    ScheduleReader();
    Console.ReadLine();
    }


static void FileOpener(){

}

static void ScheduleReader(){ 
    string pathToSchedule = "/home/pi/Desktop/schedule.txt";
    var lineCount = File.ReadLines(pathToSchedule).Count();
    Schedule[] imagesToDisplay = new Schedule[lineCount];
    for(int i = 0; i < lineCount; i++){
        string[] lines = File.ReadAllLines(pathToSchedule);
        string[] data = lines[i+1].Split(',');
        Schedule displayFile = new Schedule();
        displayFile.date = data[0];
        displayFile.time = data[1];
        displayFile.pathToImage = data[2];
        displayFile.monitorSelection = data[3];
        imagesToDisplay[i] = displayFile;
    }
    for(int i = 0; i < imagesToDisplay.Length; i++){
        Console.WriteLine("" + imagesToDisplay[i].date + imagesToDisplay[i].time);
    }
}

struct Schedule{
    public string date;
    public string time;
    public string pathToImage;
    public string monitorSelection;
}
}