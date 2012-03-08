using System;
using DataTables.Mvc.Core;
using FluentAssertions;
using NUnit.Framework;

namespace DataTables.Mvc.Test
{
    [TestFixture]
    public class ColumnFixture
    {
        [Test]
        public void CanCreateColoum()
        {
            //Setup

            
            //Act
            var result = new Column();

            //Assert
            result.ToString().Should().NotBeNullOrEmpty();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Column_with_explicitly_set_sorting_should_contain_sorting(bool sortable)
        {
            //Setup
            var expectedString = String.Format("bSortable: {0}", sortable.AsLower());

            //Act
            var result = new Column().Sortable(sortable);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Column_with_explicitly_set_sorting_should_contain_visible(bool visible)
        {
            //Setup
            var expectedString = String.Format("bVisible: {0}", visible.AsLower());

            //Act
            var result = new Column().Visible(visible);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_title_set_should_have_title()
        {
            //Setup
            var title = "Column1";
            var expectedString = string.Format("sTitle: '{0}'", title);

            //Act
            var result = new Column().Title(title);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_class_should_have_class()
        {
            //Setup
            var c = "class1";
            var expectedString = string.Format("sClass: '{0}'", c);

            //Act
            var result = new Column().Class(c);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_width_set_should_have_width()
        {
            //Setup
            var width = "100px";
            var expectedString = string.Format("sWidth: '{0}'", width);

            //Act
            var result = new Column().Width(width);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_defaultContent_set_should_have_defaultContent()
        {
            //Setup
            var defaultContent = "Empty";
            var expectedString = string.Format("sDefaultContent: '{0}'", defaultContent);

            //Act
            var result = new Column().DefaultContent(defaultContent);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_int_for_dataProperty_should_contain_nonstringified_integer()
        {
            //Setup
            var dataProp = "1";
            var expectedString = string.Format("mDataProp: {0}", dataProp);

            //Act
            var result = new Column().DataProperty(dataProp);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_string_for_dataProperty_should_contain_string()
        {
            //Setup
            var dataProp = "FirstName";
            var expectedString = string.Format("mDataProp: '{0}'", dataProp);

            //Act
            var result = new Column().DataProperty(dataProp);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_function_for_dataProperty_should_contain_an_unwrapped_function()
        {
            //Setup
            var dataProp = "return 'Hello World';";
            var expectedString = string.Format("mDataProp: function(source, type, val) {{{0}}}", dataProp);

            //Act
            var result = new Column().DataProperty(dataProp, true);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_function_for_dataProperty_should_contain_an_unwrapped_function_calling_another_function()
        {
            //Setup
            var dataProp = "return doWork(source, type, val);";
            var expectedString = string.Format("mDataProp: function(source, type, val) {{{0}}}", dataProp);

            //Act
            var result = new Column().DataProperty(dataProp, true);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }

        [Test]
        public void Column_with_render_function_should_return_an_unwrapped_function()
        {
            //Setup
            var function = "return 'Hello World';";
            var expectedString = string.Format("fnRender: function(row, val) {{{0}}}", function);

            //Act
            var result = new Column().RenderFunction(function);

            //Assert
            result.ToString().Should().Contain(expectedString);
        }
    }
}
