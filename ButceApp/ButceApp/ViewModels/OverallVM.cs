using ButceApp.Models;
using OxyPlot;
using OxyPlot.Series;
using Plugin.SQLiteConnection;
using SQLite;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace ButceApp.ViewModels
{
    public class OverallVM : BaseViewModel
    {
        public double totalAmounth = 0;
        private PlotModel _plotModel { get; set; }
        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set { _plotModel = value; }
        }
        private PlotModel _chart { get; set; }
        public PlotModel Chart
        {
            get { return _chart; }
            set { _chart = value; }
        }
        public OverallVM()
        {
            Title = "Overall";
            
            Chart = CreateAreaChart();
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            //drawgr = new Command(() => CreateAreaChart());
            //drawgr2 = new Command(() => Simplemodel());
            DbManager db = new DbManager();
            var income=db.GetIncomes();
            
            foreach(Income item in income)
            {
                if(item.Continious || item.Time.AddMonths(1)>DateTime.Now)
                totalAmounth = totalAmounth + item.Amounth;
            }
            var exp = db.GetExpenses();

            PlotModel = Simplemodel(exp);
            //foreach(Income ias in inc)
            //{
            //    db.Delete<Income>(ias);
            //}
            //Expense expense = new Expense() {Name="deneme",Amounth=50,Continious=false,Time=new DateTime() };
            // db.Insert<Expense>(expense);


            OnPropertyChanged();


        }
        public  PlotModel Simplemodel(TableQuery<Expense> expenses)
        {
            var modelP1 = new PlotModel { Title = "Harcamalar" };

            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4 };
            foreach(Expense expense in expenses)
            {
                totalAmounth = totalAmounth - expense.Amounth;
                seriesP1.Slices.Add(new PieSlice(expense.Name, expense.Amounth) { IsExploded = false });
            }
            seriesP1.Slices.Add(new PieSlice("Gelir", totalAmounth) { IsExploded = false });
            //Fill = OxyColors.PaleVioletRed
            //seriesP1.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false  });
            //seriesP1.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            //seriesP1.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            //seriesP1.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            //seriesP1.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            modelP1.Series.Add(seriesP1);
            
            return modelP1;

        }
        public PlotModel CreateAreaChart()
        {
            var plotModel1 = new PlotModel { Title = "AreaSeries with crossing lines" };
            var areaSeries1 = new AreaSeries();
            areaSeries1.Points.Add(new DataPoint(0, 50));
            areaSeries1.Points.Add(new DataPoint(10, 140));
            areaSeries1.Points.Add(new DataPoint(20, 60));
            areaSeries1.Points2.Add(new DataPoint(0, 60));
            areaSeries1.Points2.Add(new DataPoint(5, 80));
            areaSeries1.Points2.Add(new DataPoint(20, 70));
            plotModel1.Series.Add(areaSeries1);
            OnPropertyChanged();
            return plotModel1;

        }

        public ICommand OpenWebCommand { get; }
        public ICommand drawgr { get; }
        public ICommand drawgr2 { get; }
        //private PlotModel _plotModel;

        //public PlotModel PlotModel
        //{
        //    get { return _plotModel; }
        //    set
        //    {
        //        _plotModel = value;
        //        OnPropertyChanged();
        //    }
        //}


    }
}