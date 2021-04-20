# The Mars Rover Challenge
https://code.google.com/archive/p/marsrovertechchallenge/


## Setup
### Prerequisites
- Dotnet Core 3.1 SDK must be installed.
- Visual Studio 2019 must be installed.
- Git must be installed if you want to clone the repository, otherwise you can downloadt it as a zip.

Use a command line interface (cmd, PowerShell etc.), follow the steps below:

### Step 1. Clone or download this repository
git clone https://github.com/smhlana/the-mars-rover-challenge

This contains 2 projects, _The Mars Rover Challenge_ which is the solution for the challenge and 
_MarsRoverControllerTests_ which has the unit tests.

### Step 2. Install .NET Core API dependencies
    cd the-mars-rover-challenge
    dotnet restore
    
### Step 4. Run the application
    Open the The Mars Rover Challenge.sln in Visual Studio 2019 
    (the-mars-rover-challenge\The Mars Rover Challenge.sln).
    Build and run the solution.
    
    This will open up a console screen with instructions and prompts. Fill in the required data to deploy
    and control the rover(s).

## Thing to note:
    1. Grid below means plateau. The plateau on the console window is represented as a grid.
    2. The grid is not marked. Please follow the conventions of a x-y graph - x is horizontal and 
        increases to the right of the screen, y is vertical and increases to the top of the screen.
    3. A rover will not move past the set border of the plaetau no matter how many move (M) instructions
        you issue. 
    4. The maximum dimensions for the plaetau are 20x30. The way the plateau is presented depends on
        your screeen size. A plaetau of this size will fit on a 1920x1080 display resolution without
        being disfigured.
    5. The maximum number of rovers you can deploy on a plaetau is equal to the maximum number of points
        you can have on the grid, which is the product of the x and y values of the upper right coordinates.
    6. The rovers can occupy the same position. If this happens, only the one written onto the grid last
        will be visible, you will be able to see it when one of them moves to a unique location on the grid.
        
![mar rover challenge](https://user-images.githubusercontent.com/11193045/115358660-2ade4500-a1be-11eb-893d-08a1531dfb84.jpg)

