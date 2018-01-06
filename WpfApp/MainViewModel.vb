Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports OxyPlot
Imports OxyPlot.Series

Public Class MainViewModel
    Implements INotifyPropertyChanged

    Private mmodel As PlotModel

    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()

        Model = New PlotModel()

        Model.Title = "Simple example"
        Model.Subtitle = "using OxyPlot in VB.NET"

        Dim series1 = New LineSeries()
        series1.Title = "Series 1"
        series1.MarkerType = MarkerType.Circle
        series1.Points.Add(New DataPoint(0, 0))
        series1.Points.Add(New DataPoint(10, 18))
        series1.Points.Add(New DataPoint(20, 12))
        series1.Points.Add(New DataPoint(30, 8))
        series1.Points.Add(New DataPoint(40, 15))

        Dim series2 = New LineSeries()
        series2.Title = "Series 2"
        series2.MarkerType = MarkerType.Square
        series2.Points.Add(New DataPoint(0, 4))
        series2.Points.Add(New DataPoint(10, 12))
        series2.Points.Add(New DataPoint(20, 16))
        series2.Points.Add(New DataPoint(30, 25))
        series2.Points.Add(New DataPoint(40, 5))

        Model.Series.Add(series1)
        Model.Series.Add(series2)

    End Sub

    Property Model() As PlotModel
        Get
            Return mmodel
        End Get
        Set(value As PlotModel)
            mmodel = value
            NotifyPropertyChanged()
        End Set
    End Property

    ' This method is called by the Set accessor of each property.
    ' The CallerMemberName attribute that is applied to the optional propertyName
    ' parameter causes the property name of the caller to be substituted as an argument.
    Private Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Dim _cmd As New Command(AddressOf AddSeries)

    Public ReadOnly Property AddSeriesCommand As ICommand
        Get
            Return _cmd
        End Get
    End Property

    Private Sub AddSeries()

        Dim series3 = New LineSeries()
        series3.Title = "Series 3"
        series3.MarkerType = MarkerType.Square
        series3.Points.Add(New DataPoint(20, 20))
        series3.Points.Add(New DataPoint(21, 21))
        series3.Points.Add(New DataPoint(22, 22))
        series3.Points.Add(New DataPoint(23, 23))
        series3.Points.Add(New DataPoint(24, 24))
        Model.Series.Add(series3)
        Model.InvalidatePlot(True)
    End Sub

End Class
