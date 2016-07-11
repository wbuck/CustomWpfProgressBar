using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressIndicator
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CircularIndicator : UserControl
    {
        private static readonly BrushConverter BrushConverter = new BrushConverter( );

        public CircularIndicator( )
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty IndicatorBrushProperty =
            DependencyProperty.Register( "IndicatorBrush",
                                          typeof( Brush ),
                                          typeof( CircularIndicator ),
                                          new FrameworkPropertyMetadata( ( Brush )BrushConverter.ConvertFrom( "#FF0091FF" ),
                                                                         FrameworkPropertyMetadataOptions.AffectsRender ) );

        public static readonly DependencyProperty IndicatorTrackBrushProperty =
            DependencyProperty.Register( "IndicatorTrackBrush",
                                          typeof( Brush ),
                                          typeof( CircularIndicator ),
                                          new FrameworkPropertyMetadata( ( Brush )BrushConverter.ConvertFrom( "#FF002E50" ),
                                                                         FrameworkPropertyMetadataOptions.AffectsRender ) );

        public static readonly DependencyProperty NumericDisplayBrushProperty =
            DependencyProperty.Register( "NumericDisplayBrush",
                                          typeof( Brush ),
                                          typeof( CircularIndicator ),
                                          new FrameworkPropertyMetadata( ( Brush )BrushConverter.ConvertFrom( "#FF2B2B2B" ),
                                                                         FrameworkPropertyMetadataOptions.AffectsRender ) );

        public static readonly DependencyProperty NumericDisplayStrokeProperty =
            DependencyProperty.Register( "NumericDisplayStroke",
                                          typeof( Brush ),
                                          typeof( CircularIndicator ),
                                          new FrameworkPropertyMetadata( ( Brush )BrushConverter.ConvertFrom( "#FF0091FF" ),
                                                                         FrameworkPropertyMetadataOptions.AffectsRender ) );

        public static readonly DependencyProperty NumericDisplayForegroundProperty =
            DependencyProperty.Register( "NumericDisplayForeground",
                                          typeof( Brush ),
                                          typeof( CircularIndicator ),
                                          new FrameworkPropertyMetadata( ( Brush )BrushConverter.ConvertFrom( "#FFBCBABA" ),
                                                                         FrameworkPropertyMetadataOptions.AffectsRender ) );

        public static readonly DependencyProperty NumericDisplayVisibilityProperty =
            DependencyProperty.Register( "NumericDisplayVisibility",
                                         typeof( Visibility ),
                                         typeof( CircularIndicator ),
                                         new FrameworkPropertyMetadata( Visibility.Visible,
                                                                        FrameworkPropertyMetadataOptions.AffectsRender ) );

        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register( "Percentage", 
                                         typeof( double ),
                                         typeof( CircularIndicator ),
                                         new PropertyMetadata( 65d, new PropertyChangedCallback( OnPercentageChanged ) ) );

        public Visibility NumericDisplayVisibility
        {
            get { return ( Visibility )GetValue( NumericDisplayVisibilityProperty ); }
            set { SetValue( NumericDisplayVisibilityProperty, value ); }
        }

        public Brush NumericDisplayForeground
        {
            get { return ( Brush )GetValue( NumericDisplayForegroundProperty ); }
            set { SetValue( NumericDisplayForegroundProperty, value ); }
        }

        public Brush IndicatorBrush
        {
            get { return ( Brush )GetValue( IndicatorBrushProperty ); }
            set { SetValue( IndicatorBrushProperty, value ); }
        }

        public Brush IndicatorTrackBrush
        {
            get { return ( Brush )GetValue( IndicatorTrackBrushProperty ); }
            set { SetValue( IndicatorTrackBrushProperty, value ); }
        }

        public Brush NumericDisplayBrush
        {
            get { return ( Brush )GetValue( NumericDisplayBrushProperty ); }
            set { SetValue( NumericDisplayBrushProperty, value ); }
        }

        public Brush NumericDisplayStroke
        {
            get { return ( Brush )GetValue( NumericDisplayStrokeProperty ); }
            set { SetValue( NumericDisplayStrokeProperty, value ); }
        }

        public double Percentage
        {
            get { return ( double )GetValue( PercentageProperty ); }
            set { SetValue( PercentageProperty, value ); }
        }

        private static void OnPercentageChanged( DependencyObject sender, DependencyPropertyChangedEventArgs args )
        {
            var arc = sender as CircularIndicator;

            if( arc == null )
                return;
                       
            if( arc.Percentage > 100 )
            {
                arc.Percentage = 100;
            }
            arc.ChangeProgress( );                 
        }

        private void ChangeProgress( )
        {
            indicator.EndAngle = ( 360 * ( Percentage / 100 ) );
        }

        protected override void OnRender( DrawingContext drawingContext )
        {
            
            
        }

    }
}
