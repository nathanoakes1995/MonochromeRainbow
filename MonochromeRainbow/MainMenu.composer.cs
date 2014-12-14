// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Screen
{
    partial class MainMenu
    {
        ImageBox ImageBox_1;
        Button startButton;
        Button tutorialButton;
        Button optionsButton;
        Button highScoresButton;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            ImageBox_1 = new ImageBox();
            ImageBox_1.Name = "ImageBox_1";
            startButton = new Button();
            startButton.Name = "startButton";
            tutorialButton = new Button();
            tutorialButton.Name = "tutorialButton";
            optionsButton = new Button();
            optionsButton.Name = "optionsButton";
            highScoresButton = new Button();
            highScoresButton.Name = "highScoresButton";

            // MainMenu
            this.RootWidget.AddChildLast(ImageBox_1);
            this.RootWidget.AddChildLast(startButton);
            this.RootWidget.AddChildLast(tutorialButton);
            this.RootWidget.AddChildLast(optionsButton);
            this.RootWidget.AddChildLast(highScoresButton);
            this.Showing += new EventHandler(onShowing);
            this.Shown += new EventHandler(onShown);

            // ImageBox_1
            ImageBox_1.Image = null;
            ImageBox_1.ImageScaleType = ImageScaleType.Center;

            // startButton
            startButton.TextColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            startButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            startButton.BackgroundFilterColor = new UIColor(255f / 255f, 0f / 255f, 0f / 255f, 191f / 255f);

            // tutorialButton
            tutorialButton.TextColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            tutorialButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            tutorialButton.BackgroundFilterColor = new UIColor(255f / 255f, 255f / 255f, 0f / 255f, 191f / 255f);

            // optionsButton
            optionsButton.TextColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            optionsButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            optionsButton.BackgroundFilterColor = new UIColor(0f / 255f, 255f / 255f, 0f / 255f, 191f / 255f);

            // highScoresButton
            highScoresButton.TextColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            highScoresButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            highScoresButton.BackgroundFilterColor = new UIColor(0f / 255f, 0f / 255f, 255f / 255f, 191f / 255f);

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

                    ImageBox_1.SetPosition(315, 12);
                    ImageBox_1.SetSize(200, 200);
                    ImageBox_1.Anchors = Anchors.None;
                    ImageBox_1.Visible = true;

                    startButton.SetPosition(339, 240);
                    startButton.SetSize(214, 56);
                    startButton.Anchors = Anchors.None;
                    startButton.Visible = true;

                    tutorialButton.SetPosition(339, 240);
                    tutorialButton.SetSize(214, 56);
                    tutorialButton.Anchors = Anchors.None;
                    tutorialButton.Visible = true;

                    optionsButton.SetPosition(339, 332);
                    optionsButton.SetSize(214, 56);
                    optionsButton.Anchors = Anchors.None;
                    optionsButton.Visible = true;

                    highScoresButton.SetPosition(339, 429);
                    highScoresButton.SetSize(214, 56);
                    highScoresButton.Anchors = Anchors.None;
                    highScoresButton.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    ImageBox_1.SetPosition(230, 50);
                    ImageBox_1.SetSize(500, 100);
                    ImageBox_1.Anchors = Anchors.None;
                    ImageBox_1.Visible = true;

                    startButton.SetPosition(380, 190);
                    startButton.SetSize(200, 60);
                    startButton.Anchors = Anchors.None;
                    startButton.Visible = true;

                    tutorialButton.SetPosition(380, 270);
                    tutorialButton.SetSize(200, 60);
                    tutorialButton.Anchors = Anchors.None;
                    tutorialButton.Visible = true;

                    optionsButton.SetPosition(380, 350);
                    optionsButton.SetSize(200, 60);
                    optionsButton.Anchors = Anchors.None;
                    optionsButton.Visible = true;

                    highScoresButton.SetPosition(380, 430);
                    highScoresButton.SetSize(200, 60);
                    highScoresButton.Anchors = Anchors.None;
                    highScoresButton.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            startButton.Text = "Start";

            tutorialButton.Text = "Tutorial";

            optionsButton.Text = "Options";

            highScoresButton.Text = "High Scores";
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    ImageBox_1.Visible = false;
                    break;

                default:
                    ImageBox_1.Visible = false;
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    new FadeInEffect()
                    {
                        Widget = ImageBox_1,
                    }.Start();
                    break;

                default:
                    new FadeInEffect()
                    {
                        Widget = ImageBox_1,
                    }.Start();
                    break;
            }
        }

    }
}
