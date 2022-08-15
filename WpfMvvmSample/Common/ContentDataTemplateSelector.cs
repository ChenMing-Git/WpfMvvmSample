using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WpfMvvmSample
{
    class ContentDataTemplateSelector : DataTemplateSelector
    {
        //用来标示一下已经创建过的类型
        private readonly static Queue<Type> ViewModelQueue = new Queue<Type>();

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            do
            {
                if (item == null || item is UIElement)
                {
                    break;
                }

                // item 就是你的ViewModel的类型，在这主要就是找到ViewModel对应的View
                // 好多框架中会在启动时构建自己的Map，来对应ViewModel
                // 比如 Caliburn.Micro 框架中默认 是以名称对应的 XXXViewModel 和 XXXView,来构建Map的
                //      MvvmCross 框架中不仅提供了 名称，还提供了 Attribute的对应方式

                // 在这为了演示方便，我就直接反射对应名称的 View了。

                var viewModelType = item.GetType();
                if (ViewModelQueue.Contains(viewModelType))
                {
                    break;
                }
                var viewModelName = viewModelType.Name;
                string name = null;
                var index = viewModelName.LastIndexOf("ViewModel", StringComparison.OrdinalIgnoreCase);
                if (index > 0)
                {
                    name = viewModelName.Substring(0, index);
                }
                if (string.IsNullOrEmpty(name))
                {
                    break;
                }
                var viewName = string.Format("{0}.{1}{2}", viewModelType.Namespace.Replace("ViewModel", "View"), name, "View");
                var view = viewModelType.Assembly.GetType(viewName, false, true);
                if (view != null)
                {
                    var dataTemplate = CreateDataTemplate(view, viewModelType);
                    var dtkey = dataTemplate.DataTemplateKey;
                    if (dtkey != null)
                    {
                        Application.Current.Resources.Add(dtkey, dataTemplate);
                        ViewModelQueue.Enqueue(viewModelType);
                    }
                    return dataTemplate;
                }
            } while (false);

            return base.SelectTemplate(item, container);
        }

        /// <summary>
        /// 创建DataTemplate
        /// </summary>
        /// <param name="viewType"></param>
        /// <param name="viewModelType"></param>
        /// <returns></returns>
        private DataTemplate CreateDataTemplate(Type viewType, Type viewModelType)
        {
            const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
            var xaml = String.Format(xamlTemplate, viewModelType.Name, viewType.Name);

            var context = new ParserContext();

            context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
            context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
            context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);

            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            var template = (DataTemplate)XamlReader.Parse(xaml, context);
            return template;
        }
    }
}
