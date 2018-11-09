using DragDropAdornerPoC.Adorners;
using DragDropAdornerPoC.Commands.RelayCommand;
using DragDropAdornerPoC.CustomEventArgs;
using DragDropAdornerPoC.Helpers;
using DragDropAdornerPoC.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace DragDropAdornerPoC.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields & Properties
        private Point _startingPoint;
        private CarretAdorner _adorner;
        private ListViewItem _currentListViewItem;
        private int _currentIndex;
        private int _startingIndex;

        private ObservableCollection<ECigarette> _eCigarettes = new ObservableCollection<ECigarette>();
        public ObservableCollection<ECigarette> ECigarettes
        {
            get
            {
                return _eCigarettes;
            }
            set
            {
                _eCigarettes = value;
                OnPropertyChanged(nameof(ECigarettes));
            }
        }
        #endregion

        #region Commands  
        private ICommand _listViewPreviewMouseLeftButtonDownCommand;
        public ICommand ListViewPreviewMouseLeftButtonDownCommand
        {
            get
            {
                return _listViewPreviewMouseLeftButtonDownCommand ?? (_listViewPreviewMouseLeftButtonDownCommand = new RelayCommand<object>(x =>
                {
                    ListView_PreviewMouseLeftButtonDown(x);
                }));
            }
        }

        private ICommand _listViewPreviewMouseMoveCommand;
        public ICommand ListViewPreviewMouseMoveCommand
        {
            get
            {
                return _listViewPreviewMouseMoveCommand ?? (_listViewPreviewMouseMoveCommand = new RelayCommand<object>(x =>
                {
                    ListView_PreviewMouseMove(x);
                }));
            }
        }

        private ICommand _listViewPreviewMouseLeftButtonUpCommand;
        public ICommand ListViewPreviewMouseLeftButtonUpCommand
        {
            get
            {
                return _listViewPreviewMouseLeftButtonUpCommand ?? (_listViewPreviewMouseLeftButtonUpCommand = new RelayCommand<object>(x =>
                {
                    ListView_PreviewMouseLeftButtonUp(x);
                }));
            }
        }

        private ICommand _listViewDragOverCommand;
        public ICommand ListViewDragOverCommand
        {
            get
            {
                return _listViewDragOverCommand ?? (_listViewDragOverCommand = new RelayCommand<object>(x =>
                {
                    ListView_DragOver(x);
                }));
            }
        }

        private ICommand _listViewDropCommand;
        public ICommand ListViewDropCommand
        {
            get
            {
                return _listViewDropCommand ?? (_listViewDropCommand = new RelayCommand<object>(x =>
                {
                    ListView_Drop(x);
                }));
            }
        }

        private ICommand _listViewDragEnterCommand;
        public ICommand ListViewDragEnterCommand
        {
            get
            {
                return _listViewDragEnterCommand ?? (_listViewDragEnterCommand = new RelayCommand<object>(x =>
                {
                    ListView_DragEnter(x);
                }));
            }
        }

        private ICommand _listViewDragLeaveCommand;
        public ICommand ListViewDragLeaveCommand
        {
            get
            {
                return _listViewDragLeaveCommand ?? (_listViewDragLeaveCommand = new RelayCommand<object>(x =>
                {
                    ListView_DragLeave(x);
                }));
            }
        }
        #endregion

        #region Ctor
        public MainWindowViewModel()
        {
            SetupCigarettes();
        }
        #endregion

        #region Private Methods
        private void SetupCigarettes()
        {
            ECigarettes.Add(new ECigarette("Admiral Vape", "RDA"));
            ECigarettes.Add(new ECigarette("Artisan Vapor Company", "RDA"));
            ECigarettes.Add(new ECigarette("Cigoteket AB", "RDTA"));
            ECigarettes.Add(new ECigarette("Cloud 90 Ltd", "RTA"));
            ECigarettes.Add(new ECigarette("Celtic Vapours Ltd", "RTA"));
            ECigarettes.Add(new ECigarette("Dr Vapor Ltd", "RDTA"));
            ECigarettes.Add(new ECigarette("Admiral Vape", "RDA"));
            ECigarettes.Add(new ECigarette("Artisan Vapor Company", "RDA"));
            ECigarettes.Add(new ECigarette("Cigoteket AB", "RDTA"));
            ECigarettes.Add(new ECigarette("Cloud 90 Ltd", "RTA"));
            ECigarettes.Add(new ECigarette("Celtic Vapours Ltd", "RTA"));
            ECigarettes.Add(new ECigarette("Dr Vapor Ltd", "RDTA"));
        }
        #endregion

        #region Events
        private void ListView_PreviewMouseLeftButtonDown(object x)
        {
            if (x is MouseEventArguments mouseArgs)
            {
                _startingPoint = mouseArgs.E.GetPosition(null);
            }
        }

        private void ListView_PreviewMouseMove(object x)
        {
            if (x is MouseEventArguments mouseArgs)
            {
                if (mouseArgs.E.LeftButton == MouseButtonState.Pressed)
                {
                    var mousePos = mouseArgs.E.GetPosition(null);
                    var diff = _startingPoint - mousePos;

                    if (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                        Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
                    {
                        if (mouseArgs.Sender is ListView listView)
                        {
                            var listViewItem = TreeHelper.FindAnchestor<ListViewItem>((DependencyObject)mouseArgs.E.OriginalSource);
                            if (listViewItem != null)
                            {
                                var eCigarette = (ECigarette)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                                if (eCigarette != null)
                                {
                                    _startingIndex = ECigarettes.IndexOf(eCigarette);
                                    DataObject dragData = new DataObject("CustomFormat", eCigarette);
                                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ListView_PreviewMouseLeftButtonUp(object x)
        {
            if (_currentListViewItem != null)
            {
                AdornerLayer.GetAdornerLayer(_currentListViewItem).Remove(_adorner);
            }
        }

        private void ListView_Drop(object x)
        {
            if (x is DragEventArguments dragArgs)
            {
                if (dragArgs.E.Data.GetDataPresent("CustomFormat"))
                {
                    if (dragArgs.E.Data.GetData("CustomFormat") is ECigarette eCigarette)
                    {
                        if (dragArgs.Sender is ListView listView)
                        {
                            var currentListViewItem = TreeHelper.FindAnchestor<ListViewItem>((DependencyObject)dragArgs.E.OriginalSource);
                            if (currentListViewItem != null)
                            {
                                if (listView.ItemContainerGenerator.ItemFromContainer(currentListViewItem) is ECigarette currentItem)
                                {
                                    int indexOfCurrentItem = listView.Items.IndexOf(currentItem);

                                    if (_currentListViewItem != null)
                                    {
                                        AdornerLayer.GetAdornerLayer(_currentListViewItem).Remove(_adorner);
                                    }

                                    ECigarettes.Remove(eCigarette);
                                    ECigarettes.Insert(indexOfCurrentItem, eCigarette);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ListView_DragEnter(object x)
        {
            if (x is DragEventArguments dragArgs)
            {
                if (!dragArgs.E.Data.GetDataPresent("CustomFormat") || dragArgs.Sender == dragArgs.E.Source)
                {
                    dragArgs.E.Effects = DragDropEffects.None;

                    if (dragArgs.Sender is ListView listView)
                    {
                        var currentListViewItem = TreeHelper.FindAnchestor<ListViewItem>((DependencyObject)dragArgs.E.OriginalSource);
                        if (currentListViewItem != null)
                        {
                            _currentIndex = ECigarettes.IndexOf(currentListViewItem.Content as ECigarette);
                            int lengthOfCollection = ECigarettes.Count - 1;

                            if (_currentIndex > _startingIndex && _currentIndex != 0 && _currentIndex + 1 <= lengthOfCollection)
                            {
                                var nextContainer = (ListViewItem)listView.ItemContainerGenerator.ContainerFromIndex(_currentIndex + 1);
                                _currentListViewItem = nextContainer;

                                _adorner = new CarretAdorner(_currentListViewItem);
                                AdornerLayer.GetAdornerLayer(_currentListViewItem).Add(_adorner);
                            }
                            else
                            {
                                _currentListViewItem = currentListViewItem;
                                _adorner = new CarretAdorner(currentListViewItem);
                                AdornerLayer.GetAdornerLayer(_currentListViewItem).Add(_adorner);
                            }
                        }
                    }
                }
            }
        }

        private void ListView_DragOver(object x)
        {
            if (x is DragEventArguments dragArgs)
            {
                dragArgs.E.Effects = DragDropEffects.None;

                if (dragArgs.Sender is ListView listView)
                {
                    var currentListViewItem = TreeHelper.FindAnchestor<ListViewItem>((DependencyObject)dragArgs.E.OriginalSource);
                    if (currentListViewItem != null)
                    {
                        dragArgs.E.Effects = DragDropEffects.Move;
                    }
                    else
                    {
                        dragArgs.E.Effects = DragDropEffects.None;
                        dragArgs.E.Handled = true;
                    }
                }
            }
        }

        private void ListView_DragLeave(object x)
        {
            if (_currentListViewItem != null)
            {
                AdornerLayer.GetAdornerLayer(_currentListViewItem).Remove(_adorner);
            }
        }
        #endregion
    }
}
