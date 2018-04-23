using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication5.MVVM.Service {
    public class CustomDialogService : ViewServiceBase, IDialogService {
        Func<Action<IDialogForm>, IDialogForm> getForm;
        IWin32Window owner;
        string title;
        protected CustomDialogService(IWin32Window owner, string title, Func<Action<IDialogForm>, IDialogForm> getForm) {
            this.owner = owner;
            this.title = title;
            this.getForm = getForm;
        }
        public static CustomDialogService Create(IWin32Window owner, string title = null) {
            return new CustomDialogService(owner, title, onFormCustomization => new DialogFormWithCustomButtons(onFormCustomization));
        }
        public UICommand ShowDialog(IEnumerable<UICommand> dialogCommands, string title, string documentType, object viewModel, object parameter, object parentViewModel) {
            DialogResult[] results = GetResults(dialogCommands);
            DialogResult result = results.FirstOrDefault();
            if (getForm != null && !DevExpress.Utils.Design.DesignTimeTools.IsDesignMode) {
                using (var dialogForm = getForm(f =>
                {
                    DialogFormWithCustomButtons form = f as DialogFormWithCustomButtons;
                    for (int i = 0; i < form.Buttons.Length; i++) {
                        SimpleButton btn = form.Buttons[i];
                        UICommand command = dialogCommands.ElementAt(i);
                        btn.Text = command.Caption == null ? string.Empty : command.Caption.ToString();
                        btn.BindCommand(command.Command);
                        if (command.IsDefault)
                            form.AcceptButton = btn;
                        if (command.IsCancel)
                            form.CancelButton = btn;
                    }
                })) {
                    dialogForm.Closing += DialogForm_Closing;
                    dialogForm.Closed += DialogForm_Closed;
                    Control content = CreateAndInitializeView(documentType, viewModel, parameter, parentViewModel);
                    string caption = !string.IsNullOrEmpty(title) ? title : MVVMContext.GetTitle(content) as string;
                    result = dialogForm.ShowDialog(owner, content, caption, results);
                    dialogForm.Closing -= DialogForm_Closing;
                    dialogForm.Closed -= DialogForm_Closed;
                }
            }
            int resultIndex = Array.IndexOf(results, result);
            return (resultIndex != -1 && dialogCommands.Count() > 0) ? dialogCommands.ElementAt(resultIndex) : null;
        }
        DialogResult[] GetResults(IEnumerable<UICommand> dialogCommands) {
            return dialogCommands.Select(c => (DialogResult)c.Tag).ToArray();
        }
        void DialogForm_Closing(object sender, CancelEventArgs e) {
            var dialogForm = (IDialogForm)sender;
            MVVMContext.OnClose(dialogForm.Content, e);
        }
        void DialogForm_Closed(object sender, EventArgs e) {
            var dialogForm = (IDialogForm)sender;
            dialogForm.Closing -= DialogForm_Closing;
            dialogForm.Closed -= DialogForm_Closed;
            MVVMContext.OnDestroy(dialogForm.Content);
        }

        class DialogFormWithCustomButtons : XtraDialogForm, IDialogForm {
            Action<IDialogForm> onFormCustomization;
            public DialogFormWithCustomButtons(Action<IDialogForm> onFormCustomization = null) {
                this.onFormCustomization = onFormCustomization;
            }
            internal new SimpleButton[] Buttons {
                get { return base.Buttons; }
            }
            Control IDialogForm.Content {
                get { return Message.Content; }
            }
            DialogResult IDialogForm.ShowDialog(IWin32Window owner, Control content, string caption, DialogResult[] buttons) {
                XtraDialogArgs args = new XtraDialogArgs() { Owner = owner, Content = content, Caption = caption, Buttons = buttons };
                args.Showing += BeforeFormShowing;
                return ShowMessageBoxDialog(args);
            }
            void BeforeFormShowing(object sender, XtraMessageShowingArgs e) {
                if (onFormCustomization != null) {
                    onFormCustomization(this);
                }
            }
        }
    }
}
