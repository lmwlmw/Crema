﻿//Released under the MIT License.
//
//Copyright (c) 2018 Ntreev Soft co., Ltd.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//documentation files (the "Software"), to deal in the Software without restriction, including without limitation the 
//rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
//persons to whom the Software is furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
//Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
//OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using Ntreev.Crema.Client.Framework.Properties;
using Ntreev.ModernUI.Framework;
using Ntreev.ModernUI.Framework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Ntreev.Crema.Client.Framework.MenuItems.Permissions
{
    [Export(typeof(IMenuItem))]
    [ParentType(typeof(TableTreeItemBase))]
    [ParentType(typeof(TableCategoryTreeItemBase))]
    [ParentType(typeof(TableListItemBase))]
    [ParentType(typeof(TypeTreeItemBase))]
    [ParentType(typeof(TypeCategoryTreeItemBase))]
    [ParentType(typeof(TypeListItemBase))]
    [ParentType(typeof(DataBaseListItemBase))]
    [Category("Permissions")]
    class LockMenuItem : MenuItemBase
    {
        [Import]
        private Authenticator authenticator = null;

        public LockMenuItem()
        {
            this.Icon = "/Ntreev.Crema.Client.Framework;component/Images/lock.png";
            this.DisplayName = Resources.MenuItem_Lock;
            this.HideOnDisabled = true;
        }

        protected override bool OnCanExecute(object parameter)
        {
            if (parameter is ILockableDescriptor descriptor)
            {
                return descriptor.IsLocked == false || descriptor.IsLockInherited;
            }
            return false;
        }

        protected async override void OnExecute(object parameter)
        {
            if (parameter is ILockableDescriptor descriptor)
            {
                await LockableDescriptorUtility.LockAsync(this.authenticator, descriptor);
            }
        }
    }
}
