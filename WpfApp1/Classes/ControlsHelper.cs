using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using TicketSystem.Classes.Enums;
using TicketSystem.Classes.Items;
using TicketSystem.Classes.MagazineProducts;
using TicketSystem.Classes.ViewModels;
using TicketSystem.Controls;
using TicketSystem.Controls.Dialogs;

namespace TicketSystem.Classes
{
    internal static class ControlsHelper
    {
        public static async Task LoadControl(MainWindow rootWindow, MainViewModel vm, ControlsEnum ctrl, object param)
        {
            try
            {
                ShowDashboard(rootWindow, ctrl);
                switch (ctrl)
                {
                    case ControlsEnum.MainView:
                    case ControlsEnum.Back:
                    case ControlsEnum.BarEditViewAccept:
                    case ControlsEnum.BarEditViewCancel:
                        {
                        rootWindow.container.Children.Clear();
                        var view = new MainView {DataContext = vm};
                        rootWindow.container.Children.Add(view);
                    }
                        return;

                    case ControlsEnum.GroupsView:
                    {
                        rootWindow.container.Children.Clear();
                        var view = new TicketGroupsView {DataContext = vm};
                        rootWindow.container.Children.Add(view);
                    }
                        return;

                    case ControlsEnum.ChartsView:
                    {
                        rootWindow.container.Children.Clear();
                        var view = new ChartsView {DataContext = vm};
                        rootWindow.container.Children.Add(view);
                    }
                        return;

                    case ControlsEnum.UserWorkingTimeView:
                    {
                        rootWindow.container.Children.Clear();
                        vm.UpdateWorkTimesList();
                        var view = new WorkTimesView {DataContext = vm};
                        rootWindow.container.Children.Add(view);
                    }
                        return;

                    case ControlsEnum.ItemsView:
                    {
                        rootWindow.container.Children.Clear();
                        vm.UpdateItemsList();
                        var view = new ItemsView {DataContext = vm};
                        rootWindow.container.Children.Add(view);
                    }
                        return;

                    case ControlsEnum.WorkItemsPrint:
                    {
                        var dataGrid = ((WorkTimesView) rootWindow.container.Children[0]).dataGrid;
                        var printdlg = new System.Windows.Controls.PrintDialog();
                        if (printdlg.ShowDialog().GetValueOrDefault())
                        {
                            var pageSize = new Size(printdlg.PrintableAreaWidth, printdlg.PrintableAreaHeight);
                            // sizing of the element.
                            dataGrid.Measure(pageSize);
                            dataGrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                            printdlg.PrintVisual(dataGrid, "DataGrid Print");
                        }
                    }
                        return;

                    case ControlsEnum.BackToUsers:
                    case ControlsEnum.UsersView:
                    {
                        rootWindow.container.Children.Clear();
                        var view = new UsersView {DataContext = vm};
                        rootWindow.container.Children.Add(view);
                    }
                        return;
                   
                    case ControlsEnum.GroupCreate:
                    case ControlsEnum.GroupEdit:
                    case ControlsEnum.TicketCreate:
                    case ControlsEnum.TicketEdit:
                    case ControlsEnum.UserCreate:
                    case ControlsEnum.UserEdit:
                    case ControlsEnum.ItemCreate:
                    case ControlsEnum.ItemEdit:
                    case ControlsEnum.ProductCreate:
                    case ControlsEnum.ProductEdit:
                    case ControlsEnum.RegisterView:
                    case ControlsEnum.MagazineDocuments:
                    
                        {
                        LoadDialog(rootWindow, vm, ctrl);
                    }
                        return;

                    case ControlsEnum.GroupDelete:
                    {
                        if (!vm.CanDeleteGroup())
                        {
                            await rootWindow.ShowMessageAsync("Warning", "Cannot delete group because it has referenced tickets!");
                            return;
                        }
                        if(await rootWindow.ShowMessageAsync("Confirmation", "Delete selected group?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                            vm.RemoveGroup();
                    }
                        return;

                    case ControlsEnum.ItemDelete:
                    {
                        if (!vm.CanDeleteItem())
                        {
                            await rootWindow.ShowMessageAsync("Warning", "Cannot delete item because it has referenced tickets!");
                            return;
                        }
                        if(await rootWindow.ShowMessageAsync("Confirmation", "Delete selected item?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                            vm.RemoveItem();
                    }
                        return;

                    case ControlsEnum.UserDelete:
                    {
                        if (!vm.CanDeleteUser())
                        {
                            await rootWindow.ShowMessageAsync("Warning", "Cannot delete user because it has referenced entries!");
                            return;
                        }
                        if(await rootWindow.ShowMessageAsync("Confirmation", "Delete selected user?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                            vm.RemoveUser();
                    }
                        return;

                    case ControlsEnum.GroupDuplicate:
                    {
                        vm.DuplicateGroup();
                    }
                        return;

                    case ControlsEnum.ItemDuplicate:
                    {
                        vm.DuplicateItem();
                    }
                        return;

                    case ControlsEnum.UserDuplicate:
                    {
                        vm.DuplicateUser();
                    }
                        return;

                    case ControlsEnum.BackToTickets:
                    case ControlsEnum.TicketsView:
                    {
                        rootWindow.container.Children.Clear();
                        var view = new TicketsView {DataContext = vm};
                        rootWindow.container.Children.Add(view);
                    }
                        return;

                    case ControlsEnum.TicketDelete:
                    {
                        if (!vm.CanDeleteTicket())
                        {
                            await rootWindow.ShowMessageAsync("Warning", "Cannot delete ticket because it has referenced entries!");
                            return;
                        }
                        if(await rootWindow.ShowMessageAsync("Confirmation", "Delete selected ticket?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                            vm.RemoveTicket();
                    }
                        return;

                    case ControlsEnum.TicketDuplicate:
                    {
                        vm.DuplicateTicket();
                    }
                        return;

                    case ControlsEnum.Exit:
                    {
                        rootWindow.container.Children.Clear();
                        vm.LogOutUser();
                        await ProcessLoginControls(rootWindow, vm);
                    }
                        return;

                    case ControlsEnum.TicketHelp:
                    {
                        Process.Start("http://www.google.com/search?q=help&oq=help");
                    }
                        return;

                    case ControlsEnum.ExitEntry:
                    {
                        if(await rootWindow.ShowMessageAsync("Confirmation", "Commit exit for selected entry?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                            vm.ExitEntry();
                    }
                        return;

                   
                    case ControlsEnum.ProductCancel:
                    case ControlsEnum.ProductAccept:
                    case ControlsEnum.Magazine:
                        {
                            rootWindow.container.Children.Clear();
                            var view = new MagazineView { DataContext = vm };
                            rootWindow.container.Children.Add(view);
                            // Show the dialog
                            if (ctrl == ControlsEnum.ProductAccept) LoadDialog(rootWindow, vm, ctrl);
                        }break;

                    case ControlsEnum.ProductDelete:
                        {
                            if (await rootWindow.ShowMessageAsync("Confirmation", "Delete selected Product?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                                vm.RemoveProduct();
                        }
                        return;
                    case ControlsEnum.ProductDuplicate:
                        {
                            vm.DuplicateProduct();
                        }
                        return;
                    case ControlsEnum.MagazineAddProduct:
                        {
                            rootWindow.container.Children.Clear();
                            var view = new ProductView { DataContext = vm };
                            rootWindow.container.Children.Add(view);
                        }
                        break;

                    case ControlsEnum.ProductBuy:
                        {
                            rootWindow.container.Children.Clear();
                            var view = new BarEditView { DataContext = vm };
                            rootWindow.container.Children.Add(view);
                        }
                        break;                    
                    default:
                        throw new Exception($"Unknown control type: {ctrl}");
                }
            }
            catch (Exception ex)
            {
                await LogHelper.LogEx(nameof(LoadControl), ex);
            }
        }

        internal static void LoadDialog(MainWindow rootWindow, MainViewModel vm, ControlsEnum ctrl)
        {
            switch (ctrl)
            {
                case ControlsEnum.ProductCreate:
                case ControlsEnum.ProductEdit: {
                        rootWindow.blackPanel.Visibility = Visibility.Visible;
                        var model = new ProductCrudModel((ctrl == ControlsEnum.ProductCreate)? new ProductItem() : vm.SelectedProduct);
                        var view = new CreateProduct { DataContext = model };
                        rootWindow.containerGrid.IsEnabled = false;

                        model.Closed += (sender, item) =>
                        {
                            if (item != null)
                            {
                                if (ctrl == ControlsEnum.ProductCreate)
                                {
                                    vm.AddProduct(item);
                                    // After Create the product, check out if there is one Magazine
                                    if (vm.SelectedMagazine != null)
                                    {
                                        vm.AddMagazineProduct(new MagazineProduct { MagazineId = vm.SelectedMagazine.Id, ProductId = item.Id, Description = "Not implemented", Quantity = 100 });
                                    }
                                    else
                                    {
                                        // if there is not one Magazine, we created one
                                        var mg = new MagazineItem
                                        {
                                            DocumentTypeId = 1
                                        };
                                        vm.AddMagazine(mg);
                                        vm.AddMagazineProduct(new MagazineProduct { MagazineId = mg.Id, ProductId = item.Id, Description = "Not implemented", Quantity = 100 });
                                    }
                                }
                                else vm.UpdateProduct(item);
                            }

                            ClearDialog(rootWindow);
                        };
                        rootWindow.dialogContainer.Children.Add(view);

                    } break;

                case ControlsEnum.ProductAccept:
                    {
                        rootWindow.blackPanel.Visibility = Visibility.Visible;
                        var model = new MagazineModel(vm.SelectedProduct, vm.SelectedMagazine ?? new MagazineItem());
                        var view = new CreateProductMagazine { DataContext = model };
                        rootWindow.containerGrid.IsEnabled = false;

                        model.Closed += (sender, item) =>
                        {
                            if (item != null)
                            {
                                // First Create the Magazine.

                                // After create the relation with the products

                            }

                            ClearDialog(rootWindow);
                        };

                        rootWindow.dialogContainer.Children.Add(view);
                    }
                    break;

                case ControlsEnum.MagazineDocuments:
                    {
                        rootWindow.blackPanel.Visibility = Visibility.Visible;
                        var model = new MagazineDocumentModel();
                        var view = new CreateMagazineDocument { DataContext = model };
                        rootWindow.containerGrid.IsEnabled = false;

                        model.Closed += (sender, item) =>
                        {
                            if (item != null)
                            {
                                if (vm.SelectedMagazine == null)
                                {
                                    vm.SelectedMagazine = new MagazineItem
                                    {
                                        DocumentType = new MagazineDocumentType
                                        {
                                            Id = item.Id
                                        }
                                    };

                                    vm.AddMagazine(vm.SelectedMagazine);
                                }
                            }

                            ClearDialog(rootWindow);
                        };
                        rootWindow.dialogContainer.Children.Add(view);

                    }
                    break;
                case ControlsEnum.GroupCreate:
                case ControlsEnum.GroupEdit:
                {
                    rootWindow.blackPanel.Visibility = Visibility.Visible;
                    var model = new TicketGroupViewModel(ctrl == ControlsEnum.GroupCreate ? new TicketGroupItem() : vm.SelectedGroup);
                    var view = new CreateTicketGroupView {DataContext = model};
                    rootWindow.containerGrid.IsEnabled = false;
                    model.Closed += (sender, item) =>
                    {
                        if (item != null)
                        {
                            if (ctrl == ControlsEnum.GroupCreate)
                                vm.AddGroup(item);
                            else vm.UpdateGroup(item);
                        }

                        ClearDialog(rootWindow);
                    };
                    rootWindow.dialogContainer.Children.Add(view);
                }
                    return;

                case ControlsEnum.TicketCreate:
                case ControlsEnum.TicketEdit:
                {
                    rootWindow.blackPanel.Visibility = Visibility.Visible;
                    var model = new TicketViewModel(ctrl == ControlsEnum.TicketCreate ? new TicketItem() : vm.SelectedTicket, ctrl == ControlsEnum.TicketCreate, vm.GroupsList);
                    var view = new CreateTicketView {DataContext = model};
                    rootWindow.containerGrid.IsEnabled = false;
                    model.Closed += (sender, item) =>
                    {
                        if (item != null)
                        {
                            if (ctrl == ControlsEnum.TicketCreate)
                                vm.AddTicket(item);
                            else vm.UpdateTicket(item);
                        }

                        ClearDialog(rootWindow);
                    };
                    rootWindow.dialogContainer.Children.Add(view);
                }
                    return;

                case ControlsEnum.UserCreate:
                case ControlsEnum.UserEdit:
                {
                    rootWindow.blackPanel.Visibility = Visibility.Visible;
                    var model = new UserViewModel(ctrl == ControlsEnum.UserCreate ? new UserItem() : vm.SelectedViewUser, ctrl == ControlsEnum.UserCreate);
                    var view = new CreateUserView { DataContext = model };
                    rootWindow.containerGrid.IsEnabled = false;
                    model.Closed += (sender, item) =>
                    {
                        if (item != null)
                        {
                            if (ctrl == ControlsEnum.UserCreate)
                                vm.AddUser(item);
                            else vm.UpdateUser(item);
                        }

                        ClearDialog(rootWindow);
                    };
                    model.WarningMessage += async (sender, s) => { await rootWindow.ShowMessageAsync("Error", s);  };
                    rootWindow.dialogContainer.Children.Add(view);
                }
                    return;

                case ControlsEnum.ItemCreate:
                case ControlsEnum.ItemEdit:
                {
                    rootWindow.blackPanel.Visibility = Visibility.Visible;
                    var model = new ItemViewModel(ctrl == ControlsEnum.ItemCreate ? new ItemItem() : vm.SelectedViewItem, ctrl == ControlsEnum.ItemCreate);
                    var view = new CreateItemView { DataContext = model };
                    rootWindow.containerGrid.IsEnabled = false;
                    model.Closed += (sender, item) =>
                    {
                        if (item != null)
                        {
                            if (ctrl == ControlsEnum.ItemCreate)
                                vm.AddItem(item);
                            else vm.UpdateItem(item);
                        }

                        ClearDialog(rootWindow);
                    };
                    model.WarningMessage += async (sender, s) => { await rootWindow.ShowMessageAsync("Error", s);  };
                    rootWindow.dialogContainer.Children.Add(view);
                }
                    return;

                case ControlsEnum.RegisterView:
                {
                    rootWindow.blackPanel.Visibility = Visibility.Visible;
                    var model = new RegisterViewModel(vm.GroupsList, vm.TicketsList, vm.ItemsList, vm.CurrentUser);
                    var view = new RegisterView {DataContext = model};
                    rootWindow.containerGrid.IsEnabled = false;
                    model.Closed += (sender, item) =>
                    {
                        if (item != null)
                            vm.AddMonitoringItem(item);

                        ClearDialog(rootWindow);
                    };
                    rootWindow.dialogContainer.Children.Add(view);
                }
                    return;                    
            }
        }

        internal static async Task ProcessLoginControls(MainWindow root, MainViewModel vm)
        {
            if (await ShowLoginDialog(root, vm))
                await LoadControl(root, vm,ControlsEnum.MainView, null);
        }

        private static async Task<bool> ShowLoginDialog(MetroWindow root, MainViewModel vm)
        {
            try
            {
                var errorText = string.Empty;
                var initialView = true;
                while (true)
                {
                    var data = await root.ShowLoginAsync("Login", errorText, new LoginDialogSettings
                    {
                        AffirmativeButtonText = "Accept",
                        InitialUsername = SettingsManager.LastUserName ?? "user",
                        AnimateHide = false,
                        AnimateShow = initialView,
                        NegativeButtonText = "Cancel",
                        NegativeButtonVisibility = Visibility.Visible,
                        DialogMessageFontSize = 14
                    });
                    initialView = false;
                    if (data == null)
                    {
                        Application.Current.Shutdown();
                        return false;
                    }

                    if (!vm.Authenticate(data.Username, data.Password))
                    {
                        errorText = "Invalid username or password!";
                        continue;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                await LogHelper.LogEx(nameof(ShowLoginDialog), ex);
                Application.Current.Shutdown();
                return false;
            }
        }

        private static void ShowDashboard(MainWindow root, ControlsEnum ctrl)
        {
            var _dashVisibility = new Dictionary<ControlsEnum, System.Windows.Controls.DockPanel>
            {
                { ControlsEnum.MainView, root.dashboard },
                { ControlsEnum.Back, root.dashboard },
                { ControlsEnum.BarEditViewAccept, root.dashboard },
                { ControlsEnum.BarEditViewCancel, root.dashboard },
                { ControlsEnum.GroupsView, root.dashboardGroups },
                { ControlsEnum.BackToTickets, root.dashboardTickets },
                { ControlsEnum.TicketsView, root.dashboardTickets },
                { ControlsEnum.UsersView, root.dashboardUsers },
                { ControlsEnum.BackToUsers, root.dashboardUsers },
                { ControlsEnum.UserWorkingTimeView, root.dashboardWorkTimes },
                { ControlsEnum.ItemsView, root.dashboardItems },
                { ControlsEnum.ChartsView, root.dashboardCharts },
                { ControlsEnum.Exit, null },
                { ControlsEnum.Magazine, root.dashboardMagazine },
                { ControlsEnum.ProductCancel, root.dashboardMagazine },
                { ControlsEnum.ProductAccept, root.dashboardMagazine },
                { ControlsEnum.MagazineAddProduct, root.dashboardProduct },
                { ControlsEnum.ProductBuy, root.dashboardProductBuy },
                
            };
            // Default behaviour
            if (!_dashVisibility.ContainsKey(ctrl)) return;


            foreach (var dashb in _dashVisibility)
            {
                if (dashb.Value != null) dashb.Value.Visibility = Visibility.Collapsed;
            }

            if (_dashVisibility[ctrl] != null) _dashVisibility[ctrl].Visibility = Visibility.Visible;
        }

        private static void ClearDialog(MainWindow root)
        {
            root.blackPanel.Visibility = Visibility.Collapsed;
            root.dialogContainer.Children.Clear();
            root.containerGrid.IsEnabled = true;
        }
    }
}
