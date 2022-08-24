using NextDesign.Desktop;
using NextDesign.Desktop.ExtensionPoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using NextDesign.Core;

namespace AchievementAmount.Commands
{
    /// <summary>
    /// 差分成果量計算コマンドの実装です。
    /// </summary>
    public class DiffCalculationCommand : CommandHandlerBase
    {
        /// <summary>
        /// コマンドの実行
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        protected override void OnExecute(ICommandContext c, ICommandParams p)
        {
            // 現在のプロジェクトの比較結果を取得します
            var project = c.App.Workspace.CurrentProject;
            IModelComparison comparison = c.App.Diff.GetComparison(project);

            if (comparison == null)
            {
                c.App.Window.UI.ShowMessageBox("プロジェクト差分をとった状態で実行してください。");
                return;
            }

            // 現在のモデル以下の差分情報を集計します
            var amount = 0;
            var model = c.App.Workspace.CurrentModel;

            IMatch match = comparison.GetMatch(model);
            if (match.HasDifference) amount++;

            var children = model.GetAllChildren();
            foreach (IModel child in children)
            {
                match = comparison.GetMatch(child);
                if (match.HasDifference) amount++;
            }

            // 集計結果の表示
            c.App.Output.Clear(ExtensionName);
            c.App.Output.WriteLine(ExtensionName, $"差分モデル数={amount}");
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
