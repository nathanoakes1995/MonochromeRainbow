// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Screen
{
    partial class HighScores
    {
        Button mainMenuButton;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            mainMenuButton = new Button();
            mainMenuButton.Name = "mainMenuButton";

            // HighScores
            this.RootWidget.AddChildLast(mainMenuButton);

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

                    mainMenuButton.SetPosition(358, 346);
                    mainMenuButton.SetSize(214, 56);
                    mainMenuButton.Anchors = Anchors.None;
                    mainMenuButton.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

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
