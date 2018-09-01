//
// Copyright (c) 2016, MindFusion LLC - Bulgaria.
//

using System.Windows;
using System.Windows.Media;


namespace MindFusion.Diagramming.Wpf.Samples.CS.Anchors
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        //public Circle circleQ0, circleQ1, circleQ2, circleQ3, circleQ4;

        ShapeNode q0, q1, q2, q3, q4;

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(Circle circleQ0, Circle circleQ1, Circle circleQ2, Circle circleQ3, Circle circleQ4)
		{
			InitializeComponent();

			diagram.DefaultShape = Shapes.Rectangle;
			diagram.Bounds = new Rect(0, 0, 3840, 3840);

			diagram.NodeEffects.Add(new GlassEffect());
			diagram.NodeEffects.Add(new AeroEffect());

			Style shapeNodeStyle = new Style();
			shapeNodeStyle.Setters.Add(new Setter(ShapeNode.BrushProperty,
				new LinearGradientBrush(Colors.LightGray, Colors.DarkTurquoise, 80)));
			shapeNodeStyle.Setters.Add(new Setter(ShapeNode.FontSizeProperty, 10.75));
			diagram.ShapeNodeStyle = shapeNodeStyle;

            Shape q0Shape = circleQ0.Fdc.Equals("A") ? Shapes.Decision : Shapes.Ellipse;
            q0 = new ShapeNode(diagram);
            q0.Bounds = new Rect(76.8, 350, 115.2, 76.8);
            q0.Shape = q0Shape;
            q0.Text = "q0";
            q0.AnchorPattern = AnchorPattern.Decision1In3Out;
			diagram.Nodes.Add(q0);

            Shape q1Shape = circleQ1.Fdc.Equals("A") ? Shapes.Decision : Shapes.Ellipse;
            q1 = new ShapeNode(diagram);
            q1.Bounds = new Rect(300, 115.2, 115.2, 76.8);
            q1.Shape = q1Shape;
            q1.Text = "q1";
            q1.AnchorPattern = AnchorPattern.Decision2In2Out;
			diagram.Nodes.Add(q1);

            Shape q2Shape = circleQ2.Fdc.Equals("A") ? Shapes.Decision : Shapes.Ellipse;
            q2 = new ShapeNode(diagram);
            q2.Bounds = new Rect(300, 550, 115.2, 76.8);
            q2.Shape = q2Shape;
            q2.Text = "q2";
            q2.AnchorPattern = AnchorPattern.Decision2In2Out;
            diagram.Nodes.Add(q2);

            Shape q3Shape = circleQ3.Fdc.Equals("A") ? Shapes.Decision : Shapes.Ellipse;
            q3 = new ShapeNode(diagram);
            q3.Bounds = new Rect(600, 115.2, 115.2, 76.8);
            q3.Shape = q3Shape;
            q3.Text = "q3";
            q3.AnchorPattern = AnchorPattern.Decision2In2Out;
            diagram.Nodes.Add(q3);

            Shape q4Shape = circleQ4.Fdc.Equals("A") ? Shapes.Decision : Shapes.Ellipse;
            q4 = new ShapeNode(diagram);
            q4.Bounds = new Rect(600, 550, 115.2, 76.8);
            q4.Shape = q4Shape;
            q4.Text = "q4";
            q4.AnchorPattern = AnchorPattern.Decision2In2Out;
            diagram.Nodes.Add(q4);

			var router = diagram.LinkRouter as QuickRouter;
			if (router != null)
				router.UBendMaxLen = 10;
			diagram.RoutingOptions.TriggerRerouting |= RerouteLinks.WhileCreating;
			diagram.RoutingOptions.Anchoring = Anchoring.Ignore;

            drawLinks(q0, circleQ0);
            drawLinks(q1, circleQ1);
            drawLinks(q2, circleQ2);
            drawLinks(q3, circleQ3);
            drawLinks(q4, circleQ4);
        }

        private void drawLinks(ShapeNode origin, Circle data) {

            ShapeNode letterDestiny = null; 
            switch (data.Letter) {
                case "q0": letterDestiny = q0;  break;
                case "q1": letterDestiny = q1; break;
                case "q2": letterDestiny = q2; break;
                case "q3": letterDestiny = q3; break;
                case "q4": letterDestiny = q4; break;
                case "A": break;
            }
            if (letterDestiny != null) {
                DiagramLink link = new DiagramLink(diagram, origin, letterDestiny);
                link.Text = "Letra";
                diagram.Links.Add(link);
            }

            ShapeNode numberDestiny = null;
            switch (data.Number)
            {
                case "q0": numberDestiny = q0; break;
                case "q1": numberDestiny = q1; break;
                case "q2": numberDestiny = q2; break;
                case "q3": numberDestiny = q3; break;
                case "q4": numberDestiny = q4; break;
                case "A": break;
            }
            if (numberDestiny != null)
            {
                DiagramLink link = new DiagramLink(diagram, origin, numberDestiny);
                link.Text = "Numero";
                diagram.Links.Add(link);
            }

            ShapeNode plusDestiny = null;
            switch (data.PlusSymbol)
            {
                case "q0": plusDestiny = q0; break;
                case "q1": plusDestiny = q1; break;
                case "q2": plusDestiny = q2; break;
                case "q3": plusDestiny = q3; break;
                case "q4": plusDestiny = q4; break;
                case "A": break;
            }
            if (plusDestiny != null)
            {
                DiagramLink link = new DiagramLink(diagram, origin, plusDestiny);
                link.Text = "+";
                diagram.Links.Add(link);
            }

            ShapeNode equalDestiny = null;
            switch (data.EqualSymbol)
            {
                case "q0": equalDestiny = q0; break;
                case "q1": equalDestiny = q1; break;
                case "q2": equalDestiny = q2; break;
                case "q3": equalDestiny = q3; break;
                case "q4": equalDestiny = q4; break;
                case "A": break;
            }
            if (equalDestiny != null)
            {
                DiagramLink link = new DiagramLink(diagram, origin, equalDestiny);
                link.Text = "=";
                diagram.Links.Add(link);
            }

        }

		private void radioButton1_Checked(object sender, RoutedEventArgs e)
		{
			diagram.DefaultShape = Shapes.Rectangle;
		}

		private void radioButton2_Checked(object sender, RoutedEventArgs e)
		{
			diagram.DefaultShape = Shapes.Decision;
		}

		private void diagram_NodeCreated(object sender, NodeEventArgs e)
		{
			ShapeNode node = e.Node as ShapeNode;
			if (node == null)
				return;

			if (node.Shape == Shapes.Decision)
				node.AnchorPattern = AnchorPattern.Decision1In3Out;
			else
				node.AnchorPattern = apat2;
		}

		private void OnLoadClick(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openDlg = new Microsoft.Win32.OpenFileDialog();
			if (openDlg.ShowDialog() == true)
				diagram.LoadFromXml(openDlg.FileName);
		}

		private void OnSaveClick(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.SaveFileDialog saveDlg = new Microsoft.Win32.SaveFileDialog();
			if (saveDlg.ShowDialog() == true)
				diagram.SaveToXml(saveDlg.FileName);
		}


		private AnchorPattern apat1;
		private AnchorPattern apat2;
	}
}