using System;
using System.Collections.ObjectModel;
using RozApp.Model;

namespace RozApp.ViewModel
{
    public class NameViewModel
    {
        private ObservableCollection<Name> nameCollection;
        public ObservableCollection<Name> NameCollection
        {
            get { return nameCollection; }
            set { nameCollection = value; }
        }
        public NameViewModel()
        {
            nameCollection = new ObservableCollection<Name>();
            nameCollection.Add(new Name() { ID = 1, Sname = "Eric" });
            nameCollection.Add(new Name() { ID = 2, Sname = "James" });
            nameCollection.Add(new Name() { ID = 3, Sname = "Jacob" });
            nameCollection.Add(new Name() { ID = 4, Sname = "Lucas" });
            nameCollection.Add(new Name() { ID = 5, Sname = "Mark" });
        }
    }
}
