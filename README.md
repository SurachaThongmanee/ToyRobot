# Setup and Run
The Toy Robot project is a console application developed using VB.NET targeting .NET 8.

## Setup Instructions
1. Download Visual Studio Community 2022: 
   - Download Visual Studio Community 2022 from (https://visualstudio.microsoft.com/vs/community/).
   - Install visual studio community 2022.
   - In the **Worklaods** section, ensure that
        - **Workloads: Desktop & Mobile => Selected .NET desktop Development** is selected.
   - In the **individual components section** section, ensure that
        -  **.NET 8.0 Runtime (Long Term Support)** is selected.
   - Proceed with the installation.
2. Clone or Download Source Code:
   - Clone or download the source code from the GitHub master branch. https://github.com/SurachaThongmanee/Robot
   - The solution contains two projects: "Robot" and "RobotTest"

  
## How to Run and Test
### Note: In the following commands, x represents the X position, y represents the Y position, and f represents the facing direction.
1. Run the Robot Project:
   - Open the solution in Visual Studio.
   - Set the "Robot" project as the startup project.
   - Adjust the path in the `inputFile` variable within the `Program.vb` file to read commands from the `input.txt` file.
   - Press F5 or click on the Run button to start the application.
  
   #### Alternatively you can uncomment `#Region "Input From cmd"` in the `Program.vb` file for manual input commands via the console command line.
   - Input commands in the command console using the following format:
     - `PLACE x,y,f`
     - `MOVE`
     - `LEFT`
     - `RIGHT`
     - `REPORT`
2. Test Unit Test RobotTest Project
   * Right-click on => `RobotTest.vb`. in **RobotTest** project.
   * Select => **Run Tests** to execute the unit tests.
