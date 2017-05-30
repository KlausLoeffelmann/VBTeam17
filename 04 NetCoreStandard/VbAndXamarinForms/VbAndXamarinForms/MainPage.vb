'Beta Issue? Property page of Project not working in 15.3PV.
Option Strict On
Option Infer On

Imports Xamarin.Forms

Public Class MainPage
    Inherits ContentPage

    Dim myDecimalEntry As New Entry With
        {.Placeholder = "Enter decimal number",
         .Margin = New Thickness(5, 5, 5, 5),
         .VerticalOptions = LayoutOptions.CenterAndExpand,
         .FontSize = 24}

    Dim myConvertButton As New Button With
        {.Text = "Convert!",
         .VerticalOptions = LayoutOptions.CenterAndExpand,
         .HorizontalOptions = LayoutOptions.CenterAndExpand,
         .FontSize = 24}

    Dim myResultLabel As New Label With
        {.Text = "- - -",
         .FontSize = 36,
         .VerticalOptions = LayoutOptions.CenterAndExpand,
         .HorizontalOptions = LayoutOptions.CenterAndExpand}

    Public Sub New()

        AddHandler myConvertButton.Clicked,
            Sub()
                myResultLabel.Text = RomanNumerals.
                    RomanNumeralFromValue(Integer.Parse(myDecimalEntry.Text))
            End Sub

        Padding = New Thickness(0, 10, 0, 10)
        Me.BackgroundColor = Color.CornflowerBlue

        Dim grid = New Grid With {
            .HorizontalOptions = LayoutOptions.FillAndExpand,
            .VerticalOptions = LayoutOptions.FillAndExpand,
            .RowDefinitions = New RowDefinitionCollection From
            {
                New RowDefinition With {.Height = 80},
                New RowDefinition With {.Height = GridLength.Star},
                New RowDefinition With {.Height = GridLength.Star},
                New RowDefinition With {.Height = New GridLength(2, GridUnitType.Star)}
            }
        }

        grid.Children.Add(New Label With {
                            .Text = "Roman Numerals",
                            .VerticalOptions = LayoutOptions.CenterAndExpand,
                            .HorizontalOptions = LayoutOptions.CenterAndExpand,
                            .FontSize = 36,
                            .FontAttributes = FontAttributes.Bold
                          }, 0, 0)

        grid.Children.Add(myDecimalEntry, 0, 1)
        grid.Children.Add(myConvertButton, 0, 2)
        grid.Children.Add(myResultLabel, 0, 3)
        Content = grid
    End Sub
End Class
