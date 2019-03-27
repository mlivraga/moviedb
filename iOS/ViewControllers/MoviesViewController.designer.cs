// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace moviedb.iOS
{
    [Register ("MoviesViewController")]
    partial class MoviesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView FirstTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FirstTable != null) {
                FirstTable.Dispose ();
                FirstTable = null;
            }
        }
    }
}