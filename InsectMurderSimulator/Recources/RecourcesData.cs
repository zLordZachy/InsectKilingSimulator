using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace InsectMurderSimulator.Recources
{
    public class RecourcesData
    {

        public BitmapImage Image01 { get; set; }
        public BitmapImage Image02 { get; set; }

        public BitmapImage Image03 { get; set; }

        public BitmapImage Image04 { get; set; }

        public BitmapImage Image05 { get; set; }

        public BitmapImage Image06 { get; set; }

        public BitmapImage Image07 { get; set; }

        public BitmapImage Image08 { get; set; }
        public BitmapImage Image09 { get; set; }
        public BitmapImage Image10 { get; set; }

        public BitmapImage Image11 { get; set; }

        public BitmapImage Image12 { get; set; }

        public BitmapImage Image13 { get; set; }
        public BitmapImage Image14 { get; set; }
        public BitmapImage Image15 { get; set; }
        public BitmapImage Image16 { get; set; }

        public BitmapImage Image17 { get; set; }

        public RecourcesData()
        {
            Image01 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp01.gif", UriKind.Absolute));
            Image02 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp02.gif", UriKind.Absolute));
            Image03 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp03.gif", UriKind.Absolute));
            Image04 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp04.gif", UriKind.Absolute));
            Image05 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp05.gif", UriKind.Absolute));
            Image06 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp06.gif", UriKind.Absolute));
            Image07 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp07.gif", UriKind.Absolute));
            Image08 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp08.gif", UriKind.Absolute));
            Image09 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp09.gif", UriKind.Absolute));
            Image10 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp10.gif", UriKind.Absolute)); 
            Image11 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp11.gif", UriKind.Absolute)); 
            Image12 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Alive/komar_transp12.gif", UriKind.Absolute)); 
            Image13 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Falling/komar_transp13.gif", UriKind.Absolute)); 
            Image14 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Falling/komar_transp14.gif", UriKind.Absolute)); 
            Image15 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Falling/komar_transp15.gif", UriKind.Absolute)); 
            Image16 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Falling/komar_transp16.gif", UriKind.Absolute));
            Image17 = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Recources/Dead/komar_transp17.gif", UriKind.Absolute)); 
        }
    }
}
