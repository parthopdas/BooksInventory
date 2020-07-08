## Book Repository - Isar Aerospace

## Main Goal

Develop a GUI using C#, which imports data from the attached CSV file and displays them in a window using the DataGridView-Control (WinForms) or DataGrid-Control (WPF).

## Details

- Create a graphical user interface, consisting out of a DataGridView-/DataGrid-Control and necessary buttons for other features
- With the press of a button, the user shall be able to select the attached books list (Books.csv) and import it automatically into the GUI and into the DataGridView/DataGrid
- Column Types:
  - "Title", "Author", "Price" and "Year": text columns
  - "Binding": combo box column
  - "In Stock": check box column
  - "Description": not displayed. Create a button column to show the description in a tool tip, message box, etc. when the user presses the button
- Rows with books, that are not in stock shall be highlighted
- The text of each cell in the "Price" column shall be colored according to its value (color gradient from highest to lowest price)
- Add another button which deletes all books from DataGridView/DataGrid, that are not in stock

## Highlights

- Solution built along the lines of [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
  - Individual pieces have high cohesive and low coupling.
  - Layers become more general as we progress inwards. E.g. if we want to have build a web based solution, Application/Persistence/Domain/Common layers will stay the same.
  - Demonstrates the CQRS pattern.
- All business logic unit tested.
- All awaitable code is async.

## TODO

- Keeping the persistence layer simple.
- Wire up keyboard shortcuts for the menus.
- Strengthen Book parsing logic.
- Support other decimal separators in book parsing logic. 
- Price column gradation background assumes max price.
