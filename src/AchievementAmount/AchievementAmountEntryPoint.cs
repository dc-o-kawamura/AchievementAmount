using AchievementAmount.Commands;
using AchievementAmount.Events;
using NextDesign.Desktop;
using NextDesign.Desktop.ExtensionPoints;
using NextDesign.Extension;
using System;
using System.Windows;

namespace AchievementAmount
{
    /// <summary>
    /// エクステンションのエントリポイントです
    /// </summary>
    public class AchievementAmountEntryPoint : ExtensionBase
    {
        /// <summary>
        /// アクティベート時の処理です。
        /// </summary>
        protected override void OnActivate()
        {
            // リボン
            RibbonGroup group = ExtensionPoints.Ribbon.AddTab("成果量").AddGroup("集計");
            group.AddLargeButton<CalculateModelAmountCommand>("モデル数集計");
            group.AddLargeButton<DiffCalculationCommand>("差分モデル数集計");

            // イベント
            ExtensionPoints.Events.Application.RegisterOnAfterStart<ApplicationAfterStart>();
        }
    }
}
