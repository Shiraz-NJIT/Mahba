using Njit.ImageListView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace NjitSoftware.ImageListViewRenderers
{
    public class MahbaRenderer : ImageListView.ImageListViewRenderer
    {
        public override void DrawBackground(Graphics g, Rectangle bounds)
        {
            base.DrawBackground(g, bounds);
            using (Pen pGray64 = new Pen(Color.FromArgb(64, SystemColors.GrayText)))
                Utility.DrawRoundedRectangle(g, pGray64, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1, 4);
        }

        public override void DrawItem(Graphics g, ImageListViewItem item, ItemState state, Rectangle bounds)
        {
            if (ImageListView.View == Njit.ImageListView.View.Details)
                base.DrawItem(g, item, state, bounds);
            else
            {
                Size itemPadding = new Size(4, 4);
                using (Brush backColorBrush = new SolidBrush(item.BackColor))
                    g.FillRectangle(backColorBrush, bounds);
                if ((ImageListView.Focused && ((state & ItemState.Selected) != ItemState.None)) || (!ImageListView.Focused && ((state & ItemState.Selected) != ItemState.None) && ((state & ItemState.Hovered) != ItemState.None)))
                {
                    using (Brush bSelected = new LinearGradientBrush(bounds, Color.FromArgb(16, SystemColors.Highlight), Color.FromArgb(64, SystemColors.Highlight), LinearGradientMode.Vertical))
                        Utility.FillRoundedRectangle(g, bSelected, bounds, 4);
                }
                else if (!ImageListView.Focused && ((state & ItemState.Selected) != ItemState.None))
                {
                    using (Brush bGray64 = new LinearGradientBrush(bounds, Color.FromArgb(16, SystemColors.GrayText), Color.FromArgb(64, SystemColors.GrayText), LinearGradientMode.Vertical))
                        Utility.FillRoundedRectangle(g, bGray64, bounds, 4);
                }
                if ((state & ItemState.Hovered) != ItemState.None)
                {
                    using (Brush bHovered = new LinearGradientBrush(bounds, Color.FromArgb(8, SystemColors.Highlight), Color.FromArgb(32, SystemColors.Highlight), LinearGradientMode.Vertical))
                        Utility.FillRoundedRectangle(g, bHovered, bounds, 4);
                }

                Model.Archive.Document document = item.VirtualItemKey as Model.Archive.Document;

                Image img = item.ThumbnailImage;
                if (img != null)
                {
                    Rectangle pos = Utility.GetSizedImageBounds(img, new Rectangle(bounds.Location + itemPadding, ImageListView.ThumbnailSize));
                    if (!object.ReferenceEquals(img, this.ImageListView.DefaultImage) && document != null && Controller.Archive.DocumentController.GetChildDocumentsCount(document.ID) > 0)
                    {
                        pos.Width -= 9;
                        pos.Height -= 9;

                        g.DrawImage(img, pos);
                        DrawImageBorder(g, pos);

                        g.DrawImage(img, pos.X += 3, pos.Y += 3, pos.Width, pos.Height);
                        DrawImageBorder(g, pos);

                        g.DrawImage(img, pos.X += 3, pos.Y += 3, pos.Width, pos.Height);
                        DrawImageBorder(g, pos);

                        g.DrawImage(img, pos.X += 3, pos.Y += 3, pos.Width, pos.Height);
                        DrawImageBorder(g, pos);
                    }
                    else
                    {
                        try
                        {
                            g.DrawImage(img, pos);
                            DrawImageBorder(g, pos);
                        }
                        catch { }
                    }
                }

                if (document != null)
                {
                    if (document.AttachedToDossier || document.ParentDocumentID.HasValue)
                    {
                        Rectangle pos = new Rectangle(bounds.Location + itemPadding, Properties.Resources.Paperclip.Size);
                        g.DrawImage(Properties.Resources.Paperclip, pos);
                    }
                }

                // Draw item text
                SizeF textSize = System.Windows.Forms.TextRenderer.MeasureText(item.Text, ImageListView.Font);
                RectangleF textRectangle;
                using (StringFormat sf = new StringFormat())
                {
                    textRectangle = new RectangleF(bounds.Left + itemPadding.Width, bounds.Top + 2 * itemPadding.Height + ImageListView.ThumbnailSize.Height, ImageListView.ThumbnailSize.Width, textSize.Height);
                    sf.Alignment = StringAlignment.Center;
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    if (ImageListView.RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                        sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                    using (Brush foreColorBrush = new SolidBrush(item.ForeColor))
                        g.DrawString(item.Text, ImageListView.Font, foreColorBrush, textRectangle, sf);
                }
                if (!string.IsNullOrEmpty(item.Caption))
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        textRectangle = new RectangleF(bounds.Left + itemPadding.Width, bounds.Top + itemPadding.Height, ImageListView.ThumbnailSize.Width, textSize.Height);
                        sf.Alignment = StringAlignment.Center;
                        sf.FormatFlags = StringFormatFlags.NoWrap;
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Trimming = StringTrimming.EllipsisCharacter;
                        if (ImageListView.RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                            sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                        using (Brush foreColorBrush = new SolidBrush(item.ForeColor))
                            g.DrawString(item.Caption, ImageListView.Font, foreColorBrush, textRectangle, sf);
                    }
                }

                // Item border
                using (Pen pWhite128 = new Pen(Color.FromArgb(128, Color.White)))
                    Utility.DrawRoundedRectangle(g, pWhite128, bounds.Left + 1, bounds.Top + 1, bounds.Width - 3, bounds.Height - 3, 4);
                if (ImageListView.Focused && ((state & ItemState.Selected) != ItemState.None))
                {
                    using (Pen pHighlight128 = new Pen(Color.FromArgb(128, SystemColors.Highlight)))
                        Utility.DrawRoundedRectangle(g, pHighlight128, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1, 4);
                }
                else if (!ImageListView.Focused && ((state & ItemState.Selected) != ItemState.None))
                {
                    using (Pen pGray128 = new Pen(Color.FromArgb(128, SystemColors.GrayText)))
                        Utility.DrawRoundedRectangle(g, pGray128, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1, 4);
                }
                else if (ImageListView.View == Njit.ImageListView.View.Thumbnails && (state & ItemState.Selected) == ItemState.None)
                {
                    using (Pen pGray64 = new Pen(Color.FromArgb(64, SystemColors.GrayText)))
                        Utility.DrawRoundedRectangle(g, pGray64, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1, 4);
                }

                if (ImageListView.Focused && ((state & ItemState.Hovered) != ItemState.None))
                {
                    using (Pen pHighlight64 = new Pen(Color.FromArgb(64, SystemColors.Highlight)))
                        Utility.DrawRoundedRectangle(g, pHighlight64, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1, 4);
                }

                if (ImageListView.Focused && ((state & ItemState.Focused) != ItemState.None))
                    System.Windows.Forms.ControlPaint.DrawFocusRectangle(g, bounds);
            }
        }

        private void DrawImageBorder(Graphics g, Rectangle pos)
        {
            if (Math.Min(pos.Width, pos.Height) > 32)
            {
                using (Pen pGray128 = new Pen(Color.FromArgb(128, Color.Gray)))
                    g.DrawRectangle(pGray128, pos);
                if (System.Math.Min(ImageListView.ThumbnailSize.Width, ImageListView.ThumbnailSize.Height) > 32)
                {
                    using (Pen pWhite128 = new Pen(Color.FromArgb(128, Color.White)))
                        g.DrawRectangle(pWhite128, Rectangle.Inflate(pos, -1, -1));
                }
            }
        }
    }
}
