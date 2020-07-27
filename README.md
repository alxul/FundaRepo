# FundaRepo
This is a test project, for Funda.nl

It demonstrates an import of real estate properties to the database and a search with grouping by real estate agency.

The database gets deleted and created on every start.
Run the web project, select a city in the textbox (preferably a small one to reduce amount of data), and click Import.
Import data for the cities you want, with garden or without.

After it's done the data is saved in the db and can be quickly queried and groupped as the excercise asks.
The property HasGarden is filled depending on the api call we make, I didn't see any property that gives that info (not sure if it exists), so I save it based on the import input.
