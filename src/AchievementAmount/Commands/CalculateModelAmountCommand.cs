using NextDesign.Desktop;
using NextDesign.Desktop.ExtensionPoints;
using System;
using System.Collections.Generic;
using System.Text;
using NextDesign.Core;

namespace AchievementAmount.Commands
{
    class CalculateModelAmountCommand : CommandHandlerBase
    {
        /// <summary>
        /// コマンドの実行
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        protected override void OnExecute(ICommandContext c, ICommandParams p)
        {
            // 現在のモデル以下のモデル数を集計します
            var model = c.App.Workspace.CurrentModel;
            var amount = model.GetAllChildren().Count + 1;

            // 集計結果の表示
            c.App.Output.Clear(ExtensionName);
            c.App.Output.WriteLine(ExtensionName, $"モデル数={amount}");
            c.App.Window.IsInformationPaneVisible = true; // 情報ペインを表示します
            c.App.Window.ActiveInfoWindow = "Output"; // 出力タブをアクティブにします
            c.App.Window.CurrentOutputCategory = ExtensionName; // カテゴリを選択します
        }

        /// <summary>
        /// コマンド実行可否の実装（任意です）
        /// </summary>
        /// <returns></returns>
        protected override bool OnCanExecute()
        {
            return true;
        }
    }
}
