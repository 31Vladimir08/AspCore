﻿namespace MapStructure.MapRegistry
{
    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Services.Notebook;
    using StructureMap;

    public class StructuremapServiceRegistry : Registry
    {
        public StructuremapServiceRegistry()
        {
            For<INotebookService>().Use<NotebookService>();
        }
    }
}
