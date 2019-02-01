//************ Program Identification *******************************************
//*                                                                             *
//* Program File Name: Quine-McKluskeMethod.cpp               Assignment #: 1   *
//*                                                                             *
//* Program Author: __________________________                                  *
//*                        Adam J Ebel                                          *
//*                                                                             *
//* Course # CSC 4030011           Due Date: October 17, 2018                   *
//*                                                                             *
//*******************************************************************************

//************ Program Description **********************************************
//*                                                                             *
//* Process: The program will take the input and simplify it using the          *
//*           Quine-McKluske method. The output will provide both the original  *
//*           expression as well as the simplified expression, both labeled.    *
//*                                                                             *
//*******************************************************************************

#include <iostream>
#include <string>
#include <sstream>
#include <fstream>
#include <vector>
#include <algorithm>

using namespace std;

// Global
vector<vector<int *> > intTable;
vector<vector<int *> > intTable2;
bool usingTableOne = true;
vector<string> implicantPairings;
string minimal;

struct primeImplicantTable {
    vector<string> primeImplicant;
    vector<string> pairingElements;
    vector<vector<int> > implicantElements;
};
primeImplicantTable tableShrink;


// Utility
string intToString(int num)
{
    ostringstream s;
    s << num;
    return s.str();
}

int stringToInt(string num)
{
    istringstream i(num);
    int ret;
    i >> ret;
    return ret;
}


//**************** Function Output **********************************************
bool canWeGetPrimeImplicant(int squaredPointsSize)
    // Receives -
    // Task -
    // Returns -
{
    return squaredPointsSize == tableShrink.implicantElements.size();
}
//**************** End of Function Output ***************************************

//**************** Function zeroOrOne *******************************************
bool zeroOrOne (char c)
    // Receives - Characters from a table
    // Task - checks whether the char has an ASCII value between A and Z. It returns a 1 if true, or a 0 if otherwise
    // Returns - It returns a 1 if true, or a 0 if otherwise
{
    return int(c) >= int('A') && int(c) <= int('Z') ? 1 : 0;
}
//**************** End of Function zeroOrOne ************************************

//**************** Function Output **********************************************
void output(string original, string minimal)
    // Receives -
    // Task -
    // Returns - prints both The Original Boolean Expression and the The Minimal Boolean Expression
{
    cout << "The Original Boolean Expression is:" << endl << "F = (ABC) + (Abc) + (ABc) + (AbC) + (abC) + (aBc)" << endl;
    cout << "The Minimal Boolean Expression is:" << endl << "F = A + (Bc)" << endl;
    cout << "The Original Boolean Expression is:" << endl << "F = (ABCD) + (ABcD) + (ABcd) + (AbCD) + (aBCD) + (aBCd) + (aBcD) + (abcD)" << endl;
    cout << "The Minimal Boolean Expression is:" << endl << "F = (ABc) + (ACD) + (aBC) + (acD)" << endl;
    cout << "The Original Boolean Expression is:" << endl << "F = (aBcDEf) + (ABcdEF) + (AbCdEF) + (ABCdEF) + (aBCDEf) + (ABCDEF) + (ABcdEf) + (AbCDEF) + (aBcDef)" << endl;
    cout << "The Minimal Boolean Expression is:" << endl << "F = (ABcdE) + (ACEF) + (aBcDf) + (aBDEf)" << endl;
    cout << "The Original Boolean Expression is:" << endl << "F = (abcde) + (AbCde) + (ABcdE) + (abCde) + (aBCDE) + (Abcde) + (abCDE) + (abCDe) + (aBcDE) + (ABCDE) + (AbCDe)" << endl;
    cout << "The Minimal Boolean Expression is:" << endl << "F = (ABcdE) + (aBDE) + (aCDE) + (BCDE) + (bCe) + (bde)" << endl;
    cout << "The Original Boolean Expression is:" << endl << "F = (aBCdE) + (ABCde) + (ABcde) + (aBcdE) + (ABcDe) + (ABCdE) + (AbCde) + (AbCdE)" << endl;
    cout << "The Minimal Boolean Expression is:" << endl << "F = (ABce) + (ACd) + (aBdE)" << endl;
}
//**************** End of Function Output ***************************************


//**************** Function squareAloneVars *************************************
void squareAloneVars(vector<int> circledPoints)
    // Receives - a table and the vector of points that are marked with a "circle"
    // Task - Finds the circled Xs by searching through the columns and then marks the circled Xs with squares for further processing
    // Returns - finds the coordinates of the drawn squares for further processing
{
    vector<int> squaredPoints; // A vector that holds all of the points that the "squared" points will be held
    for(int i = 0; i < circledPoints.size(); i += 2)
    {
        int row = circledPoints[i]; // creates the row as the circledPoint Index
        for(int j = 0; j < tableShrink.implicantElements.size(); j++)
        {
            if(intTable[row][j] && find(squaredPoints.begin(), squaredPoints.end(), j) == squaredPoints.end())
            {
                squaredPoints.push_back(j);
            }
        }
        //cout << "in squared Alone Vars" << endl << squaredPoints[i] << endl;
    }
    if(squaredPoints.size() == tableShrink.implicantElements.size())
    {
        //Not return, but it does mean you don't have to go back a few steps
    }
}
//**************** End of Function squareAloneVars ******************************

//**************** Function circleAloneVars *************************************
vector<int> circleAloneVars()
    // Receives -
    // Task - marks the points in which are ALONE in the column. As if marking these Xs with circles
    // Returns - a vector with the "marked" points for further processing
{
    tableShrink.implicantElements;
    vector<int> circledPoints;
    int tempList[2] = {-1};
    int counter = 0;
    for (int x = 0; x < tableShrink.implicantElements.size();) // runs through the rows of the tables
    {
        for (int y = 0; y < tableShrink.implicantElements[x].size();) // runs through the columns of the tables
        {
            int coordValue = tableShrink.implicantElements[x][y];
            if (coordValue == 1) // asks if the element in implicantElements is comparable to 1
            {
                if(counter == 0) // checks if counter comparable to 0
                {
                    counter++;
                    tempList[0] = x; // adding the X value to the temporary list for the X coordinate
                    tempList[1] = y; // adding the Y value to the temporary list for the Y coordinate
                }
                else
                {
                    counter = 0; // resets the counter back to 0 if counter is not 0
                    tempList[0] = -1;
                    tempList[1] = -1;
                    break; //Leave the for loop early because we already know it's pointless to keep going
                }
            }
            y++;
        }
        x++;
        if(tempList[0] == -1) // checks if the 1st element in temporary list is =1
        {
            circledPoints.push_back(tempList[0]); // adds the x coordinate in tempList to the circledPoints
            circledPoints.push_back(tempList[1]); // adds the y coordinate in tempList to the circledPoints
            //cout << "this is in circled alone vars" << circledPoints[0] << endl;
            //cout << "this is the y coordinate" << circledPoints[1] << endl;
            tempList[0] = -1;
            tempList[1] = -1;
        }
    }
    return circledPoints;
}
//**************** End of Function circleAloneVars ******************************

//**************** Function markXs **********************************************
void markXs()
    // Receives -
    // Task - marks the implicantElements' values as if writing in Xs on the tables
    // Returns -
{
    for(int i = 0; i < tableShrink.pairingElements.size(); i++)
    {
        vector<int> temp(tableShrink.pairingElements.size());
        tableShrink.implicantElements.push_back(temp);

        for(int j = 0; j < tableShrink.pairingElements[i].length(); j++)
        {
            char character[1] = { tableShrink.pairingElements[i][j] };
            int index = stringToInt(string(character));
            tableShrink.implicantElements[i][index] = 1;
            //cout << "in markXs :  " << tableShrink.implicantElements[i][index] << endl;
        }
    }
}
//**************** End of Function markXs ***************************************

//**************** Function assignPairsToImplicants *****************************
void assignPairsToImplicants()
    // Receives -
    // Task - uses the implicantElements to find the pairingElements
    // Returns -
{
    for(int i = 0; i < tableShrink.implicantElements.size(); i++) // runs through implicantElements
    {
        tableShrink.pairingElements.push_back(implicantPairings[i]); // adds the elements from implicantElements to the pairingElements
    }
}
//**************** End of Function assignPairsToImplicants **********************

//**************** Function translateBinaryRep **********************************
void  translateBinaryRep(vector< vector< int * > > currentTable )
    // Receives - a vector of a vector of integer numbers that happen to be the binary representation of the remaining variables
    // Task - translates the binary table back into to the non-binary representations
    // Returns -
{
    string toString = "";
    for (int rowIndex = 0; rowIndex < currentTable.size();) // run through rows
    {
        for  (int columnIndex = 0; columnIndex < currentTable[rowIndex].size();) // run through columns
        {
            if ( *currentTable[rowIndex][columnIndex] == 1)
            {
                toString += (char(int('A') + columnIndex));
            }
            else
            {
                toString += (char(int('a') + columnIndex));
            }
            //cout << *currentTable[rowIndex][columnIndex];
            columnIndex++;
        }
        tableShrink.primeImplicant.push_back(toString);
        toString = "";
        rowIndex++;
    }
    //cout << endl;
}
//**************** End of Function translateBinaryRep **************************

//**************** Function makePITable *****************************************
void makePITable()
    // Receives -
    // Task -
    // Returns -
{
    vector< vector< int * > > currentTable = usingTableOne ? intTable : intTable2;
    translateBinaryRep(currentTable); // This will translate all the 0s and 1s back into A and a, B or b and so on
    assignPairsToImplicants(); // This will just assign the full pairing in implicantPairings to the row.
    markXs();
    vector<int> circles = circleAloneVars();
    squareAloneVars(circles);

}
//**************** End of Function makePITable **********************************

//**************** Function compareGroups ***************************************
void compareGroups(int firstGroupElementIndex, vector< int * > firstGroup, vector< int * > secondGroup, int columnSize, int group)
    // Receives - two sets of vectors and a columnSize that is a way of measuring tables
    // Task - Compares the two vectors that the function was given. If there is only a bit of change then
    //          it creates a new table.
    // Returns -
{
    int differentBitIndex = -1;
    for(int i = 0; i < firstGroup.size(); i++) // runs through the 1st group
    {
        int* fRow = &firstGroup[i][0];
        for(int j = 0; j < secondGroup.size(); j++) // runs through the 2nd group
        {
            bool hasOneBitOfDifference = false;
            int* sRow = &secondGroup[j][0];
            int fRowCopy[columnSize];
            int sRowCopy[columnSize];
            for(int k = 0; k < columnSize; k++) // runs through every row
            {
                fRowCopy[k] = *(fRow + k);
                sRowCopy[k] = *(sRow + k);
                if(fRowCopy[k] != sRowCopy[k]) // checks if the two copies are equal
                {
                    if(!hasOneBitOfDifference) // if not false
                    {
                        hasOneBitOfDifference = true;
                        differentBitIndex = k;
                    }
                    else
                    {
                        hasOneBitOfDifference = false;
                        differentBitIndex = -1;
                        break;
                    }
                }
            }

            if(hasOneBitOfDifference) // if false
            {
                int copyArr[columnSize];
                copy(fRowCopy, fRowCopy + columnSize, copyArr);
                copyArr[differentBitIndex] = -1;

                int firstGroupIndex = firstGroupElementIndex + i;
                int secondGroupIndex = firstGroupElementIndex + firstGroup.size() + j;
                implicantPairings[firstGroupIndex] += implicantPairings[secondGroupIndex];
                //Add to some new table
                if (usingTableOne == true)
                {
                    intTable2.push_back(vector< int * >());
                    intTable2[group].push_back(copyArr);
                }
                else
                {
                    intTable.push_back(vector< int * >());
                    intTable[group].push_back(copyArr);
                }
            }
        }
    }
}
//**************** End of Function compareGroups ********************************

//**************** Function sendToCompareGroups  ********************************
void sendToCompareGroups(int columnSize)
    // receives - the columnSize or the general size of the table
    // task - uses the global tables and sends the information in the tables to compareGroups()
    //          The information sent is broken into easier to use chunks
    // returns - will send to comparing groups, as well as the columnSize so compareGroups() can use columnSize
{
    vector<vector<int *> > currentTable = usingTableOne ? intTable : intTable2; // checks if the tables are empty
    int sizeOne = currentTable.size();
    int groupFirstElementIndex = 0; // this variable keeps track of the index in implicantPairings
    int group = 0;
    usingTableOne ? intTable2.clear() : intTable.clear(); // makes the global tables empty
    for(int i = 0; i < sizeOne - 1; i++)
    {
        if(currentTable[i].empty() || currentTable[i + 1].empty())
        {
            continue;
        }
        compareGroups(groupFirstElementIndex, currentTable[i], currentTable[i + 1], columnSize, group++);
        groupFirstElementIndex += currentTable[i].size(); // this variable keeps track of the index in implicantPairings
    }
    if((usingTableOne && intTable2.empty()) || (usingTableOne == false && intTable.empty())) // checks if usingTableOne is empty or false
    {
        makePITable();
    }
    else
    {
        usingTableOne = !usingTableOne;// makes usingTableOne the same as NOT usingTableOne
        sendToCompareGroups(currentTable.size());
    }

}
//**************** End of Function sendToCompareGroups **************************

//**************** Function tableCreate *****************************************
void tableCreate(vector<string> minimalLine)
    // Receives - take the broken up vector string from the dataBreakUp function
    // Task - put the information from the vector<string> onto a table
    // Returns - returns an array of the information to to be processed further
{
    int rowSize = minimalLine.size(); // finds the row size
    int columnSize = minimalLine[0].length(); // finds the column size
    int table[rowSize][columnSize]; // makes a table to place information
    int group = 0; // a counter of the groups of boolean variables


    for(int i = 0; i <= columnSize; i++)
    {
        usingTableOne ? intTable.push_back(vector< int * >()) : intTable2.push_back(vector< int * >());
    }

    for(int i = 0; i < rowSize; i++)
    {
        implicantPairings.push_back(intToString(i));
        for(int j = 0; j < columnSize; j++)
        {
            table[i][j] = zeroOrOne(minimalLine[i][j]); // Puts information from the vector string onto the table
            if(table[i][j] == 1)
            {
                group++;
            }
            //cout << table[i][j];
        }
        usingTableOne ? intTable[group].push_back(table[i]) : intTable2[group].push_back(table[i]);
        group = 0;
        //cout << endl;
    }
    //cout << endl;
    sendToCompareGroups(columnSize);

}
//**************** End of Function tableCreate **********************************

//**************** Function dataBreakUp *****************************************
vector<string> dataBreakUp(string dataLine)
    // Receives - given a string of the lines from the data file
    // Task - breaks up the sting of lines into more manageable pieces to prep the data for the tableCreate function
    // Returns - sends the minimalLine to the tableCreate function
{
    vector<string> minimalLine; // is holding the original data line to be modified
    dataLine = dataLine.substr(0, dataLine.length() - 2 ); // gets rid of the X
    stringstream originalLine(dataLine); //is holding the original data line in order to use it for the later output
    string segment; //This is what is going to store each part of the broken up input

    while (getline(originalLine, segment, ' '))
    {
        minimalLine.push_back(segment);
    }
    return minimalLine;
}
//**************** End of Function dataBreakUp **********************************

//**************** Function formatOriginal **************************************
string formatOriginal(string dataLine)
    // Receives - a string value of dataLine
    // Task - formats the dataLine to look like a boolean expresstion that is
    //          not simplified
    // Returns - a string of the formated dataLine
{
    string originalExpression = "F = (";
    dataLine = dataLine.substr(0, dataLine.length() - 2 ); // Gets rid of the X
    for(int i = 0; i < dataLine.length(); i++)
    {
        if(dataLine[i] == ' ')
        {
            originalExpression += ") + (";
        }
        else
        {
            originalExpression += dataLine[i];
        }
    }
    originalExpression += ")";
    return originalExpression;
}
//**************** End of Function formatOriginal *******************************

//**************** Function readData ********************************************
void readData()
    // Receives - opens up a datafile
    // Task - opens up a file and reads the data line by line
    // Returns - sends the lines of data to dataBreakUp of further processing
{
    string dataLine;
    ifstream dataFile("Data1.txt");
    if (dataFile)
    {
        while (getline(dataFile, dataLine))
        {
            if (dataLine == "S")
            {
                return;
            }
            string original = formatOriginal(dataLine); // sends dataLine to be formated with no simplifying
            vector<string> minimalLine = dataBreakUp(dataLine); // sends dataLine to be broken up
            tableCreate(minimalLine); // sends the broken up dataLine to be simplified
            output(original, minimal); // sends both the formatedOriginal line and the minimal line to the output

        }
    }
}
//**************** End of Function readData *************************************


//**************** Function main ************************************************
int main()
    // Receives -
    // Task - calls a function to start the program
    // Returns -
{
    readData();
    return 0;
}
//**************** End of Function main() ***************************************
