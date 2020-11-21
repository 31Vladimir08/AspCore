namespace BusinessLogic.MapRegistry
{
    using BusinessLogic.Interfaces.Notebook;
    using BusinessLogic.Services.Notebook;
    using StructureMap;

    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<INotebookService>().Use<NotebookService>();
        }
    }
}
