#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <fstream>

using namespace std;



vector<string> StringBreakUp(string ToBeBroken)
//breaks up a string into more manageable data type
{
    stringstream inputStream(ToBeBroken);
    string segment; //This is what is going to store each line broken up
    vector<string> commandLine;
    while (getline(inputStream, segment, ' '))
    {
        commandLine.push_back(segment);
    }
    return commandLine;
}

void formatting(string foundFlights)
// formating the final part for finding a transfering flight
// As well as printing the final results
{
    vector<string> formattedLine = StringBreakUp(foundFlights);
    if(formattedLine.size() < 5)
    {
        //Same as below, but for half the size.
        int firstFlight = 0;
        int connectingFlight = 0;
        stringstream s(formattedLine[3]);
        s >> firstFlight;
        cout << formattedLine[1] << " -> " << formattedLine[2] << " : ";
        cout << formattedLine[0] << " $" << formattedLine[3] << endl;
    }
    else
    {
        int firstFlight = 0;
        int connectingFlight = 0;
        stringstream s(formattedLine[3]);
        s >> firstFlight;
        stringstream t(formattedLine[7]);
        t >> connectingFlight;
        cout << formattedLine[1] << " -> " << formattedLine[2] << " : ";
        cout << formattedLine[0] << " $" << formattedLine[3] << "; ";
        cout << formattedLine[5] << " -> " << formattedLine[6] << " : ";
        cout << formattedLine[4] << " $" << formattedLine[7];
        cout << " for a total cost of $" << (firstFlight + connectingFlight) << endl;
    }
}

string SearchFile(string fileName, string codeToFind)
// searches "Airline.txt" and "Cities.txt" for the the names of the cities' names and the airline name
{
    string line;
    ifstream inFile; // Opening the file given to function
    inFile.open(fileName.c_str());
    while (getline(inFile, line))
    {
        if (line.substr(0, 2).compare(codeToFind) == 0)
            {
            return line.substr(2);
            // The code will always be 3 letters long, so 4 including the space.
            }
        if (line.substr(0, 3).compare(codeToFind) == 0)
            {
            return line.substr(3);
            }
    }
    inFile.close();
    return "";
}
void addCity(vector<string> commandList)
// adds a city into the city file
// checks if there is a city already in the city file
{
    bool ifInFile = false;
    int x = 2; // City code starts here from user's input
    string cityCodeName = "";
    string line = ""; //arbitrary string to read from file onto
    for (int i = x; i < commandList.size() - 1; i++)
    {
        cityCodeName += commandList[i] + " ";
    }
    cityCodeName += commandList[commandList.size() - 1];

    ifstream inFileI; //opening file to read I for ifstream
    inFileI.open("Cities.txt");
    while (getline(inFileI, line))
    {
        if (line.compare(cityCodeName) == 0)
        {
            ifInFile = true;
            cout << "This city already exists. \n";
            break;
        }
   }
   inFileI.close();

   if (!ifInFile)
   {
       ofstream inFileO; // opening file to add O for ofstream
       inFileO.open("Cities.txt", fstream::app);
       inFileO << cityCodeName << endl;
       inFileO.close();
   }
}

int addAirline(vector<string> commandList)
// adds an airline into the airline file
// checks if there is an airline already in the airline file
{
    bool ifInFile = false;
    int x = 2; // Airline code starts here from user's input
    string airlineCodeName = "";
    string line = ""; //arbitrary string to read from file onto
    for (int i = x; i < commandList.size() - 1; i++)
    {
        airlineCodeName += commandList[i] + " ";
        commandList[i].length() == 2 ? airlineCodeName += "  " : airlineCodeName += " ";
    }
    airlineCodeName += commandList[commandList.size() - 1];

    ifstream inFileI; //opening file to read I for ifstream
    inFileI.open("Airlines.txt");
    while (getline(inFileI, line))
    {
        if (line.compare(airlineCodeName) == 0)
        {
            ifInFile = true;
            cout << "This airline already exists. \n";
            break;
        }
   }
   inFileI.close();

   if (!ifInFile)
   {
       ofstream inFileO; // opening file to add O for ofstream
       inFileO.open("Airlines.txt", fstream::app);
       inFileO << airlineCodeName << endl;
       inFileO.close();
   }
}

int addFlight(vector<string> commandList)
// adds a flight into the flight file
// checks if there is a flight already in the flight file
{
    bool ifInFile = false;
    int x = 2; // Flight info starts here from user's input
    string flightCodes = "";
    string line = ""; //arbitrary string to read from file onto
    for (int i = x; i < commandList.size() - 1; i++)
    {
        flightCodes += commandList[i] + " ";
    }
    flightCodes += commandList[commandList.size() - 1];

    ifstream inFileI; //opening file to read I for ifstream
    inFileI.open("Flights.txt");
    while (getline(inFileI, line))
    {
        if (line.compare(flightCodes) == 0)
        {
            ifInFile = true;
            cout << "This flight already exists. \n";
            break;
        }
   }
   inFileI.close();

   if (!ifInFile)
   {
       ofstream inFileO; // opening file to add O for ofstream
       inFileO.open("Flights.txt", fstream::app);
       inFileO << flightCodes << endl;
       inFileO.close();
   }
}

void add(vector<string> commandList)
// 2nd level of identifying which command the program is going to take
// This function is for adding either a city, airline, or flight to one of the files used
{
    char c = commandList[1][0];
    switch(c)
    {
    case 'c':
        addCity(commandList); //Sends command to the addCity function
        break;
    case 'a':
        addAirline(commandList); //sends command to the addAirline function
        break;
    case 'f':
        addFlight(commandList); //Sends command to the addFlight
        break;
    default:
        cout << "I didn't understand the 2nd character\n";
        break;

    }
}

void listCities()
// Prints out a list of cities
{
    string line; // a line to hold the data read
    ifstream inFile; //opening file to read
    inFile.open("Cities.txt");
    while (getline(inFile, line))
        cout << line << endl;
}

void listAirlines()
//Prints out the list of airlines
{
    string line; // a line to hold the data read
    ifstream inFile; //opening file to read
    inFile.open("Airlines.txt");
    while (getline(inFile, line))
       cout << line << endl;
}

void listFlights()
// prints out a list of flights
{
    string fileLine; // a line to hold the data read
    ifstream inFile;
    inFile.open("Flights.txt");
    while (getline(inFile, fileLine))
    {
        vector<string> flightCodes = StringBreakUp(fileLine); // Send every line here to be broken up into a manageable vector
        string airlineCode = SearchFile("Airlines.txt", flightCodes[0]); // Send an airline code to search for an airline name
        string departureCityCode = SearchFile("Cities.txt", flightCodes[1]); // Send a city code to search for a departure city name
        string arrivalCityCode = SearchFile("Cities.txt", flightCodes[2]); // Send a city code to search for an arrival city name
        cout << airlineCode << ": " << departureCityCode << " => " << arrivalCityCode << " $" << flightCodes[3] << endl;
    }
    inFile.close();
}

void listFile(vector<string> commandList)
// 2nd level of identifying which command the program is going to take
// this function is for listing one of the files used
{
    char c = commandList[1][0];
    switch(c)
    {
    case 'c':
        listCities(); //Calls the listCity function
        break;
    case 'a':
        listAirlines(); //Calls the addAirline function
        break;
    case 'f':
        listFlights(); //Calls the addFlight
        break;
    default:
        cout << "I didn't understand the 2nd character\n";
        break;

    }
}

vector<string> find(string depCode, string arrCode, string connectionCode)
{
    vector<string> foundFlights;
    bool allowConnection = connectionCode == "1";
    //SearchFile function won't work.
    ifstream inFile;
    string line;
    string departureCode;
    string lineArrivalCode;
    inFile.open("Flights.txt");
    while (getline(inFile, line))
    {
        vector<string> flightPath = (StringBreakUp(line));
        departureCode = flightPath[1];
        lineArrivalCode = flightPath[2];
        if (departureCode.compare(depCode) == 0)
        {
            //Get the latter 3 characters after the space and save it
            if(lineArrivalCode.compare(arrCode) == 0)
            {
                foundFlights.push_back(line);
            }
            else
            {
                if(allowConnection)
                {
                    vector<string> temp = find(lineArrivalCode, arrCode, "0");
                    if(temp.size() > 0)
                    {
                        for(int i = 0; i < temp.size(); i++)
                        {
                            foundFlights.push_back(line + " " + temp[i]);
                        }
                    }
                }
            }
        }
    }
    inFile.close();
    return foundFlights;
}

int main()
{
    bool running = true;
    cout << "Waiting for an input\n";
    while (running)
    {
        string UserInput;
        getline(cin, UserInput);
        vector<string> commandList = StringBreakUp(UserInput);
        vector<string> foundFlights;
        char c = commandList[0][0];
        switch(c)
        {
            case 'a':
                add(commandList);
                break;
            case 'l':
                listFile(commandList);
                break;
            case 'f':
                foundFlights = find(commandList[1], commandList[2], commandList[3]);
                for(int i = 0; i < foundFlights.size(); i ++)
                {
                    formatting(foundFlights[i]);
                }
                break;
            case 'q': // Exiting the program with the q key
                cout << "Goodbye\n";
                running = false;
                break;
            default: // Do something if the code doesn't recognize the command
                cout << "I didn't understand this character\n";
            break;
        }
    }
    return 0;
}
