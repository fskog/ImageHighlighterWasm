using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageHighlighterWasm.Models
{
    public class HighlightItem
    {
        public bool Active { get; set; } = false;
        public string Header { get; set; }
        public string Text { get; set; }
        public string LinkUrl { get; set; }
        public RelativePosition Dot;
        public RelativePosition Position;

        public HighlightItem()
        {

        }

        public HighlightItem(string header, string text, string linkUrl, int dotX, int dotY, int? posX = null, int? posY = null, string positionPreference = "")
        {
            Header = header;
            Text = text;
            LinkUrl = linkUrl;
            Dot = new RelativePosition(dotX, dotY);
            Position = new RelativePosition(Dot.X, Dot.Y);
            if (posX.HasValue && posY.HasValue)
            {
                Position = new RelativePosition(posX.Value, posY.Value);
            }
            else if (!string.IsNullOrWhiteSpace(positionPreference))
            {
                switch (positionPreference.ToLower())
                {
                    case "left":
                        Position = new RelativePosition(Dot.X - 10, Dot.Y);
                        break;
                    case "right":
                        Position = new RelativePosition(Dot.X + 3, Dot.Y);
                        break;
                    case "top":
                        Position = new RelativePosition(Dot.X - 5, Dot.Y - 10);
                        break;
                    case "bottom":
                        Position = new RelativePosition(Dot.X - 5, Dot.Y + 1);
                        break;
                    default:
                        Position = new RelativePosition(Dot.X, Dot.Y);
                        break;
                }
            }
            else
            {
                new RelativePosition(Dot.X, Dot.Y);
            }
        }


    }



    public class RelativePosition
    {
        private int _x = 0;
        private int _y = 0;

        public RelativePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get { return _x; }
            set
            {
                _x = Math.Min(value, 100);
            }
        }
        public int Y
        {
            get { return _y; }
            set
            {
                _y = Math.Min(value, 100);
            }
        }
    }
}
