# Questions

1 - Discuss your strategy and decisions implementing the application. Please, consider time
complexity, effort cost, technologies used and any other variable that you understand
important on your development process.

R - Considering it's a simple project, there is no need to use many libraries for the resolution. So I focus on using only the necessary ones.
For the backend, I used .NET Core 8 and xUnit + Moq for the development of the unit tests. I also used CsvHelper to read the csv files. For the frontend, I used react + vite for the project and installed styled-components library for styling the document and axios to do the http requests.

2 - How would you change your solution to account for future columns that might be
requested, such as “Bill Voted On Date” or “Co-Sponsors”?

R - I would change my data models to accept these new columns. As I used LINQ for my resolution, It wouldn't be a problema to adjust my queries to bring the new data or develop new queries.

3 - How would you change your solution if instead of receiving CSVs of data, you were given a
list of legislators or bills that you should generate a CSV for?

R - I would use the same CSV library to generate the files. I would feed a list with the votes, legislator and bills informations before using a template to generate de CSV file.

4. How long did you spend working on the assignment?

R - Aproximately 5 hours.