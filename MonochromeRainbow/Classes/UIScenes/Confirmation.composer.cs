// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Screen
{
    partial class Confirmation
    {
        Label areYouSure;
        Button yesButton;
        Button noButton;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            areYouSure = new Label();
            areYouSure.Name = "areYouSure";
            yesButton = new Button();
            yesButton.Name = "yesButton";
            noButton = new Button();
            noButton.Name = "noButton";

            // Confirmation
            this.RootWidget.AddChildLast(areYouSure);
            this.RootWidget.AddChildLast(yesButton);
            this.RootWidget.AddChildLast(noButton);

            // areYouSure
            areYouSure.TextColor = new UIColor(206f / 255f, 206f / 255f, 206f / 255f, 255f / 255f);
            areYouSure.Font = new UIFont(FontAlias.System, 30, FontStyle.Bold);
            areYouSure.LineBreak = LineBreak.Character;
            areYouSure.HorizontalAlignment = HorizontalAlignment.Center;

            // yesButton
            yesButton.TextColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            yesButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            yesButton.BackgroundFilterColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 191f / 255f);

            // noButton
            noButton.TextColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            noButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            noButton.BackgroundFilterColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 191f / 255f);

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

                    areYouSure.SetPosition(288, 148);
                    areYouSure.SetSize(214, 36);
                    areYouSure.Anchors = Anchors.None;
                    areYouSure.Visible = true;

                    yesButton.SetPosition(288, 254);
                    yesButton.SetSize(214, 56);
                    yesButton.Anchors = Anchors.None;
                    yesButton.Visible = true;

                    noButton.SetPosition(310, 430);
                    noButton.SetSize(214, 56);
                    noButton.Anchors = Anchors.None;
                    noButton.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    areYouSure.SetPosition(370, 147);
                    areYouSure.SetSize(220, 50);
                    areYouSure.Anchors = Anchors.None;
                    areYouSure.Visible = true;

                    yesButton.SetPosition(330, 244);
                    yesButton.SetSize(300, 60);
                    yesButton.Anchors = Anchors.None;
                    yesButton.Visible = true;

                    noButton.SetPosition(330, 344);
                    noButton.SetSize(300, 56);
                    noButton.Anchors = Anchors.None;
                    noButton.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            areYouSure.Text = "Are you sure?";

            yesButton.Text = "Yes I suck";

            noButton.Text = "NO7 MY L337 $C0R3$";
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
