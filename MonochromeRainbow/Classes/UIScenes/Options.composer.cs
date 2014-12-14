// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Screen
{
    partial class Options
    {
        Label volumeControl;
        Slider volumeSlider;
        Label volumeFull;
        Label volumeZero;
        Label deleteHighScores;
        Button deleteHighScoresButton;
        Button mainMenuButton;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            volumeControl = new Label();
            volumeControl.Name = "volumeControl";
            volumeSlider = new Slider();
            volumeSlider.Name = "volumeSlider";
            volumeFull = new Label();
            volumeFull.Name = "volumeFull";
            volumeZero = new Label();
            volumeZero.Name = "volumeZero";
            deleteHighScores = new Label();
            deleteHighScores.Name = "deleteHighScores";
            deleteHighScoresButton = new Button();
            deleteHighScoresButton.Name = "deleteHighScoresButton";
            mainMenuButton = new Button();
            mainMenuButton.Name = "mainMenuButton";

            // Options
            this.RootWidget.AddChildLast(volumeControl);
            this.RootWidget.AddChildLast(volumeSlider);
            this.RootWidget.AddChildLast(volumeFull);
            this.RootWidget.AddChildLast(volumeZero);
            this.RootWidget.AddChildLast(deleteHighScores);
            this.RootWidget.AddChildLast(deleteHighScoresButton);
            this.RootWidget.AddChildLast(mainMenuButton);

            // volumeControl
            volumeControl.TextColor = new UIColor(206f / 255f, 206f / 255f, 206f / 255f, 255f / 255f);
            volumeControl.Font = new UIFont(FontAlias.System, 30, FontStyle.Bold);
            volumeControl.LineBreak = LineBreak.Character;
            volumeControl.HorizontalAlignment = HorizontalAlignment.Center;

            // volumeSlider
            volumeSlider.MinValue = 0;
            volumeSlider.MaxValue = 100;
            volumeSlider.Value = 100;
            volumeSlider.Step = 1;

            // volumeFull
            volumeFull.TextColor = new UIColor(206f / 255f, 206f / 255f, 206f / 255f, 255f / 255f);
            volumeFull.Font = new UIFont(FontAlias.System, 30, FontStyle.Bold);
            volumeFull.LineBreak = LineBreak.Character;
            volumeFull.HorizontalAlignment = HorizontalAlignment.Center;

            // volumeZero
            volumeZero.TextColor = new UIColor(206f / 255f, 206f / 255f, 206f / 255f, 255f / 255f);
            volumeZero.Font = new UIFont(FontAlias.System, 30, FontStyle.Bold);
            volumeZero.LineBreak = LineBreak.Character;
            volumeZero.HorizontalAlignment = HorizontalAlignment.Center;

            // deleteHighScores
            deleteHighScores.TextColor = new UIColor(206f / 255f, 206f / 255f, 206f / 255f, 255f / 255f);
            deleteHighScores.Font = new UIFont(FontAlias.System, 30, FontStyle.Bold);
            deleteHighScores.LineBreak = LineBreak.Character;
            deleteHighScores.HorizontalAlignment = HorizontalAlignment.Center;

            // deleteHighScoresButton
            deleteHighScoresButton.TextColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            deleteHighScoresButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            deleteHighScoresButton.BackgroundFilterColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 191f / 255f);

            // mainMenuButton
            mainMenuButton.TextColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            mainMenuButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            mainMenuButton.BackgroundFilterColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 191f / 255f);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 544;
                    this.DesignHeight = 960;

                    volumeControl.SetPosition(199, 202);
                    volumeControl.SetSize(214, 36);
                    volumeControl.Anchors = Anchors.None;
                    volumeControl.Visible = true;

                    volumeSlider.SetPosition(358, 291);
                    volumeSlider.SetSize(362, 58);
                    volumeSlider.Anchors = Anchors.Height;
                    volumeSlider.Visible = true;

                    volumeFull.SetPosition(197, 536);
                    volumeFull.SetSize(214, 36);
                    volumeFull.Anchors = Anchors.None;
                    volumeFull.Visible = true;

                    volumeZero.SetPosition(83, 266);
                    volumeZero.SetSize(214, 36);
                    volumeZero.Anchors = Anchors.None;
                    volumeZero.Visible = true;

                    deleteHighScores.SetPosition(50, 402);
                    deleteHighScores.SetSize(214, 36);
                    deleteHighScores.Anchors = Anchors.None;
                    deleteHighScores.Visible = true;

                    deleteHighScoresButton.SetPosition(264, 438);
                    deleteHighScoresButton.SetSize(214, 56);
                    deleteHighScoresButton.Anchors = Anchors.None;
                    deleteHighScoresButton.Visible = true;

                    mainMenuButton.SetPosition(358, 346);
                    mainMenuButton.SetSize(214, 56);
                    mainMenuButton.Anchors = Anchors.None;
                    mainMenuButton.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    volumeControl.SetPosition(380, 75);
                    volumeControl.SetSize(200, 50);
                    volumeControl.Anchors = Anchors.None;
                    volumeControl.Visible = true;

                    volumeSlider.SetPosition(280, 151);
                    volumeSlider.SetSize(400, 58);
                    volumeSlider.Anchors = Anchors.Height;
                    volumeSlider.Visible = true;

                    volumeFull.SetPosition(670, 130);
                    volumeFull.SetSize(100, 100);
                    volumeFull.Anchors = Anchors.None;
                    volumeFull.Visible = true;

                    volumeZero.SetPosition(190, 130);
                    volumeZero.SetSize(100, 100);
                    volumeZero.Anchors = Anchors.None;
                    volumeZero.Visible = true;

                    deleteHighScores.SetPosition(330, 235);
                    deleteHighScores.SetSize(300, 50);
                    deleteHighScores.Anchors = Anchors.None;
                    deleteHighScores.Visible = true;

                    deleteHighScoresButton.SetPosition(380, 310);
                    deleteHighScoresButton.SetSize(200, 60);
                    deleteHighScoresButton.Anchors = Anchors.None;
                    deleteHighScoresButton.Visible = true;

                    mainMenuButton.SetPosition(380, 430);
                    mainMenuButton.SetSize(200, 60);
                    mainMenuButton.Anchors = Anchors.None;
                    mainMenuButton.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            volumeControl.Text = "Volume";

            volumeFull.Text = "100%";

            volumeZero.Text = "0%";

            deleteHighScores.Text = "Delete High Scores";

            deleteHighScoresButton.Text = ":(";

            mainMenuButton.Text = "Main Menu";
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

    }
}
