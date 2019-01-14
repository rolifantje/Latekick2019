using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Latekick.Forms
{
    internal static class ComponentUtility
    {
        internal static bool DesignMode()
        {
            return DesignMode(null);
        }

        internal static bool DesignMode(Control control)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return true;
            else
            {
                if (control != null)
                {
                    Control newParent = control.Parent;
                    IComponent parent = null;

                    while (1 == 1)
                    {
                        parent = newParent;
                        if (parent == null) break;
                        if (parent.Site != null) break;

                        newParent = newParent.Parent;
                        if (newParent == null) break;
                    }

                    if (parent != null && parent.Site != null)
                        return parent.Site.DesignMode;
                }
            }
            return false;
        }

        internal static void DisableControl(Control control)
        {
            if (control.HasChildren && !(control is DataGridView))
                foreach (Control child in control.Controls)
                    DisableControl(child);
            else if (control is DataGridView)
                //Disable editing but leave the control enabled so it can be scrolled
                ((DataGridView)control).ReadOnly = true;
            else
                control.Enabled = false;
        }
    }
}
