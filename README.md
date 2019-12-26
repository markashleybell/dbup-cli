# DbUp

This application will run any number of SQL release scripts from a folder, in sequential order, skipping any which have already been applied to the specified database.

It takes two arguments: the first is the path to the folder containing the release scripts, and the second is the connection string for the database to apply the scripts to.

## Example command line

    .\dbup.exe "C:\Src\MYSOLUTION\MYDATABASEPROJECT\Releases" "Data Source=localhost;Initial Catalog=DATABASENAME;Integrated Security=True"