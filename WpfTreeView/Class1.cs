
using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfTreeView
{
    public class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public string Test { get; set; } = "My properties";
        public Class1()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(20);
                    Test=(i++).ToString();
                    PropertyChanged(this,new PropertyChangedEventArgs("Test"));

                }

            });

        }
        public override string ToString()
        {
            return "Hello world";
        }
    }
}
