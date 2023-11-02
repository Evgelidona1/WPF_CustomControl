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

namespace CANVI
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CANVI"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CANVI;assembly=CANVI"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:CustomControls/>
    ///
    /// </summary>
    public class CustomControls : Control
    {
        private Point oint = new Point(0, 0);
        public CustomControls()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControls), new FrameworkPropertyMetadata(typeof(CustomControls)));
        }
        public CustomControls(double x, double y)
        {
            oint = new Point(x, y);
            //drawingContext.DrawEllipse(Brushes.Yellow, null, oint, 50, 50);
        }
        //protected override Size MeasureOverride(Size availableSize)
        //{
        //    return new Size(100, 30); // Устанавливаем желаемые размеры контрола
        //}
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            //Point oint = new Point(255, 350);
            drawingContext.DrawEllipse(Brushes.Yellow, null, oint, 50, 50);

        }
    }
}
