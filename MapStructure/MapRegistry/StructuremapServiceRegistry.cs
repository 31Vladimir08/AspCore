namespace MapStructure.MapRegistry
{
    using BusinessLogic.Interfaces.Logic.Notebook;
    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Logic.Notebook;
    using BusinessLogic.Services.Notebook;
    using StructureMap;

    public class StructuremapServiceRegistry : Registry
    {
        public StructuremapServiceRegistry()
        {
            For<INotebookService>().Use<NotebookService>();
            For<INotebookLogic>().Use<NotebookLogic>();
        }
    }
}
