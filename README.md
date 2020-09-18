# SimpleNotes 

To run application locally: 

1. Install .NET Core 3.1, latest node.js.
2. Clone or extract into your local directory.
3. To run API: execute `dotnet run` inside `../SimpleNotesAPI/SimpleNotesAPI/` directory.
  By default used mocked repository. You can switch to a real repository in `..\SimpleNotes\SimpleNotesAPI\BLL\Helpers\DataInitializer.cs` file.
4. To run SPA: execute `npm install` and `ng serve` in `../SimpleNotes-Angular/` directory.
5. To start e2e test execute `ng e2e`.
6. Open `http://localhost:3000/` in your browser.
