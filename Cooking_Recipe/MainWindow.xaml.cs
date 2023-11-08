using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace Cooking_Recipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<Tuple<string, FlowDocument>> docs;
        public MainWindow()
        {
            InitializeComponent();
           
            docs = new List<Tuple<string, FlowDocument>>();
            
           CreateExamples();
            AddToList();
        }

        public void AddToList()
        {
            foreach (var item in docs)
            {
                ls.Items.Add(item.Item1);
            }
        }

        public void CreateExamples()
        {
            try
            {
                Run run1 = new Run("ПЕЛЬМЕНИ СО СВИНИНОЙ: ПРОСТОЙ РЕЦЕПТ ДЛЯ ДРУЖЕСТВЕННЫХ ПОСИДЕЛОК");
                Paragraph paragraph1 = new Paragraph(new Bold(run1));
                paragraph1.FontSize = 30;
                paragraph1.TextAlignment = TextAlignment.Center;
                paragraph1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                Paragraph paragraph2 = new Paragraph();
                //картинка
                Image img = new Image();
                BitmapImage bimg = new BitmapImage();
                bimg.BeginInit();
                bimg.UriSource = new Uri("Pelmen.jpg", UriKind.Relative);
                bimg.EndInit();
                img.Source = bimg;
                BlockUIContainer block = new BlockUIContainer(img);
                Figure fig = new Figure(block);
                fig.Width = new FigureLength(200);
                fig.HorizontalAnchor = FigureHorizontalAnchor.ContentRight;

                //текст
                Run run2 = new Run();
                run2.Text = "Многие из нас могут вспомнить дружеские посиделки, когда семья или друзья вместе лепят пельмени. Это сначала весело, а позже, когда блюдо будет готово, то и вкусно. Можно придумать несколько разных вариантов начинок: пельмени с куриным фаршем, с говядиной, свининой, смесью разного мяса или даже с добавлением морепродуктов. Часть пельменей можно заморозить, чтобы наслаждаться блюдом в течение более длительного времени. " + "Сегодня мы ничего не усложняли, а предлагаем рецепт пельменей со свининой. Чтобы они получились более сочными и вкусными, даем вам несколько советов.  ";
                paragraph2.Inlines.Add(fig);
                paragraph2.Inlines.Add(run2);

                Run run3 = new Run();
                run3.Text = "Выбирая мясо для начинки ориентируйтесь на свой вкус. Мы не хотели, чтобы фарш был слишком жирным, поэтому выбрали постную мякоть свинины, в которой не много жира. Конечно, можно взять уже готовый фарш, но в случае, если вы уверены в его качестве. Чтобы пельмени были более сочными, не забудьте добавить в готовый фарш немного ледяной воды и тщательно перемешать.  ";
                Paragraph paragraph3 = new Paragraph(run3);

                //ссылки
                Run run4 = new Run("Матеріал взято з ");
                Hyperlink hp = new Hyperlink(new Run("https://klopotenko.com/ru/pelmeni-so-svininoj/"));
                hp.NavigateUri = new Uri("https://klopotenko.com/ru/pelmeni-so-svininoj/");
                Paragraph paragraph4 = new Paragraph();
                paragraph4.Inlines.Add(run4);
                paragraph4.Inlines.Add(hp);

                FlowDocument doc = new FlowDocument();
                doc.Blocks.Add(paragraph1);
                doc.Blocks.Add(paragraph2);
                doc.Blocks.Add(paragraph3);
                doc.Blocks.Add(paragraph4);
                docs.Add(new Tuple<string, FlowDocument>(run1.Text, doc));
               
            }
            catch
            {

            }

            try{
                Run run1 = new Run("КАК ПРИГОТОВИТЬ БОРЩ: 5 ВКУСНЫХ РЕЦЕПТОВ");
                Paragraph paragraph1 = new Paragraph(new Bold(run1));
                paragraph1.FontSize = 30;
                paragraph1.TextAlignment = TextAlignment.Center;
                paragraph1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                Paragraph paragraph2 = new Paragraph();
                //картинка
                Image img = new Image();
                BitmapImage bimg = new BitmapImage();
                bimg.BeginInit();
                bimg.UriSource = new Uri("Borsh.jpg", UriKind.Relative);
                bimg.EndInit();
                img.Source = bimg;
                BlockUIContainer block = new BlockUIContainer(img);
                Figure fig = new Figure(block);
                fig.Width = new FigureLength(200);
                fig.HorizontalAnchor = FigureHorizontalAnchor.ContentRight;

                //текст
                Run run2 = new Run();
                run2.Text = "Украинский борщ признан UNESCO! Он вошел в Список нематериального культурного наследия этой авторитетной организации, как нуждающийся в срочной охране. Об этом вкусном блюде мы готовы говорить целую вечность, а теперь о борще будет говорить и весь мир.\r\n\r\nМы знаем бесчисленное количество невероятно вкусных рецептов и каждый из них уникален и вкусен по-своему. В мире не существует какого-то одного стандартного признанного рецепта борща. Однако, в чем мы убедились окончательно — незаурядный вкус борщу придают традиции или отдельной семьи, или даже народа. Кажется, это и есть главное правило – блюдо несет в себе историю. Попробуем в ней разобраться, а потом и приготовить борщ!";
                paragraph2.Inlines.Add(fig);
                paragraph2.Inlines.Add(run2);

                Run run3 = new Run();

                run3.Text = "С уверенностью можем сказать, что классического рецепта борща – нет. Единственное, что имеем – это семейные рецепты, которые иногда объединяют по региональному признаку. Так, родители учат своих детей, как лучше готовить борщ, ведь блюдо считается действительно сложным из-за многообразия ингредиентов. Поэтому наиболее любимый и привычный рецепт передается по наследству от поколения к поколению. И остается только догадываться, сколько всего рецептов насчитывает это блюдо по всему миру или хотя бы на территории Украины.";
                Paragraph paragraph3 = new Paragraph(run3);

                //ссылки
                Run run4 = new Run("Матеріал взято з ");
                Hyperlink hp = new Hyperlink(new Run("https://klopotenko.com/ru/pelmeni-so-svininoj/"));
                hp.NavigateUri = new Uri("https://klopotenko.com/ru/pelmeni-so-svininoj/");
                Paragraph paragraph4 = new Paragraph();
                paragraph4.Inlines.Add(run4);
                paragraph4.Inlines.Add(hp);

                FlowDocument doc = new FlowDocument();
                doc.Blocks.Add(paragraph1);
                doc.Blocks.Add(paragraph2);
                doc.Blocks.Add(paragraph3);
                doc.Blocks.Add(paragraph4);
                docs.Add(new Tuple<string, FlowDocument>(run1.Text, doc));
               
            }
            catch
            {

            }
            try
            {
                Run run1 = new Run("КОНСЕРВИРОВАННЫЕ ОГУРЦЫ НА ЗИМУ: РЕЦЕПТ С КЕТЧУПОМ ЧИЛИ");
                Paragraph paragraph1 = new Paragraph(new Bold(run1));
                paragraph1.FontSize = 30;
                paragraph1.TextAlignment = TextAlignment.Center;
                paragraph1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                Paragraph paragraph2 = new Paragraph();
                //картинка
                Image img = new Image();
                BitmapImage bimg = new BitmapImage();
                bimg.BeginInit();
                bimg.UriSource = new Uri("Ogurec.jpg", UriKind.Relative);
                bimg.EndInit();
                img.Source = bimg;
                BlockUIContainer block = new BlockUIContainer(img);
                Figure fig = new Figure(block);
                fig.Width = new FigureLength(200);
                fig.HorizontalAnchor = FigureHorizontalAnchor.ContentRight;

                //текст
                Run run2 = new Run();
                run2.Text = "Нет ничего лучше зимой или осенью, чем открыть баночку хрустящих соленых огурчиков или томатов. Я просто обожаю все эти вкусные летние запасы. Икра из запеченных овощей, консервированные огурцы или салат из кабачков – все это просто божественно вкусно. Сегодня же дам вам рецепт консервированных огурцов. Таких рецептов очень и очень много, делают консервированные огурцы с лимонной кислотой, по-корейски, с чесноком, с кетчупом. Я остановился на последнем варианте. Чтобы вкус был немного пикантнее, я выбрал кетчуп чили, но вы можете взять и обычный. Еще вкуснее, если сделать домашний кетчуп самостоятельно.";
                paragraph2.Inlines.Add(fig);
                paragraph2.Inlines.Add(run2);

                Run run3 = new Run();

                run3.Text = "Советую закрывать огурцы в литровых банках, это наиболее удобный объем, чтобы открыть и съесть. Потому что, если закрывать в трехлитровых банках, часто огурцы остаются и портятся в холодильнике. Конечно, если у вас большая семья, которая очень любит огурчики, то такого не случится. Сами огурцы лучше выбирать небольшие, они будут более хрустящими. Итак, консервируйте огурцы по моему рецепту и наслаждайтесь вкусом лета зимой.";
                
                Paragraph paragraph3 = new Paragraph(run3);

                //ссылки
                Run run4 = new Run("Матеріал взято з ");
                Hyperlink hp = new Hyperlink(new Run("https://klopotenko.com/ru/pelmeni-so-svininoj/"));
                hp.NavigateUri = new Uri("https://klopotenko.com/ru/pelmeni-so-svininoj/");
                Paragraph paragraph4 = new Paragraph();
                paragraph4.Inlines.Add(run4);
                paragraph4.Inlines.Add(hp);

                FlowDocument doc = new FlowDocument();
                doc.Blocks.Add(paragraph1);
                doc.Blocks.Add(paragraph2);
                doc.Blocks.Add(paragraph3);
                doc.Blocks.Add(paragraph4);
                docs.Add(new Tuple<string, FlowDocument>(run1.Text, doc));
            }
            catch
            {

            }
        }

     
       

        private void GridSplitter_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            GridLength a = new GridLength(0);
            
            if (list_grid.Width.Value <= 150)
            {
                GridLength b = new GridLength(40);
                But_grid.Width = b;
                list_grid.Width = a;
                Butt.Content = "-->";
                Butt.Visibility = Visibility.Visible;
               
            }

            
        }

        private void Butt_Click(object sender, RoutedEventArgs e)
        {
            GridLength a = new GridLength(150);
            list_grid.Width = a;
            Butt.Visibility = Visibility.Hidden;
            GridLength b = new GridLength(0);
            But_grid.Width = b;
        }

        private void ls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ls.SelectedItem != null)
            {
                DocReader.Document = docs[ls.SelectedIndex].Item2;

            }
        }
    }
}
