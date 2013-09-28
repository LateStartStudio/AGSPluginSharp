﻿namespace AGSPluginSharp
{
    using System.Collections.Generic;

    internal class Font : Dictionary<char, byte[]>
    {
        #region Constructors

        public Font()
        {
            this.Add(
                'A', new byte[]
                     {
                         0, 1, 1, 1, 0,
                         1, 0, 0, 0, 1,
                         1, 1, 1, 1, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1
                     }
                );
            this.Add(
                'B', new byte[]
                     {
                         1, 1, 1, 1, 0,
                         1, 0, 0, 0, 1,
                         1, 1, 1, 1, 0,
                         1, 0, 0, 0, 1,
                         1, 1, 1, 1, 0
                     }
                );
            this.Add(
                'C', new byte[]
                     {
                         0, 1, 1, 1, 1,
                         1, 0, 0, 0, 0,
                         1, 0, 0, 0, 0,
                         1, 0, 0, 0, 0,
                         0, 1, 1, 1, 1
                     }
                );
            this.Add(
                'D', new byte[]
                     {
                         1, 1, 1, 1, 0,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 1, 1, 1, 0
                     }
                );
            this.Add(
                'E', new byte[]
                     {
                         1, 1, 1, 1, 1,
                         1, 0, 0, 0, 0,
                         1, 1, 1, 1, 1,
                         1, 0, 0, 0, 0,
                         1, 1, 1, 1, 1
                     }
                );
            this.Add(
                'F', new byte[]
                     {
                         1, 1, 1, 1, 1,
                         1, 0, 0, 0, 0,
                         1, 1, 1, 1, 1,
                         1, 0, 0, 0, 0,
                         1, 0, 0, 0, 0
                     }
                );
            this.Add(
                'G', new byte[]
                     {
                         0, 1, 1, 1, 1,
                         1, 0, 0, 0, 0,
                         1, 0, 1, 1, 1,
                         1, 0, 0, 0, 1,
                         0, 1, 1, 1, 1
                     }
                );
            this.Add(
                'H', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 1, 1, 1, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1
                     }
                );
            this.Add(
                'I', new byte[]
                     {
                         1, 1, 1, 1, 1,
                         0, 0, 1, 0, 0,
                         0, 0, 1, 0, 0,
                         0, 0, 1, 0, 0,
                         1, 1, 1, 1, 1
                     }
                );
            this.Add(
                'J', new byte[]
                     {
                         1, 1, 1, 1, 1,
                         0, 0, 0, 0, 1,
                         0, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         0, 1, 1, 1, 0
                     }
                );
            this.Add(
                'K', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         1, 0, 0, 1, 0,
                         1, 1, 1, 0, 0,
                         1, 0, 0, 1, 0,
                         1, 0, 0, 0, 1
                     }
                );
            this.Add(
                'L', new byte[]
                     {
                         1, 0, 0, 0, 0,
                         1, 0, 0, 0, 0,
                         1, 0, 0, 0, 0,
                         1, 0, 0, 0, 0,
                         1, 1, 1, 1, 1
                     }
                );
            this.Add(
                'M', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         1, 1, 0, 1, 1,
                         1, 0, 1, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1
                     }
                );
            this.Add(
                'N', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         1, 1, 0, 0, 1,
                         1, 0, 1, 0, 1,
                         1, 0, 0, 1, 1,
                         1, 0, 0, 0, 1
                     }
                );
            this.Add(
                'O', new byte[]
                     {
                         0, 1, 1, 1, 0,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         0, 1, 1, 1, 0
                     }
                );
            this.Add(
                'P', new byte[]
                     {
                         1, 1, 1, 1, 0,
                         1, 0, 0, 0, 1,
                         1, 1, 1, 1, 0,
                         1, 0, 0, 0, 0,
                         1, 0, 0, 0, 0
                     }
                );
            this.Add(
                'Q', new byte[]
                     {
                         0, 1, 1, 1, 0,
                         1, 0, 0, 0, 1,
                         1, 0, 1, 0, 1,
                         1, 0, 0, 1, 1,
                         0, 1, 1, 1, 1
                     }
                );
            this.Add(
                'R', new byte[]
                     {
                         1, 1, 1, 1, 0,
                         1, 0, 0, 0, 1,
                         1, 1, 1, 1, 0,
                         1, 0, 0, 1, 0,
                         1, 0, 0, 0, 1
                     }
                );
            this.Add(
                'S', new byte[]
                     {
                         0, 1, 1, 1, 1,
                         1, 0, 0, 0, 0,
                         0, 1, 1, 1, 0,
                         0, 0, 0, 0, 1,
                         1, 1, 1, 1, 0
                     }
                );
            this.Add(
                'T', new byte[]
                     {
                         1, 1, 1, 1, 1,
                         0, 0, 1, 0, 0,
                         0, 0, 1, 0, 0,
                         0, 0, 1, 0, 0,
                         0, 0, 1, 0, 0
                     }
                );
            this.Add(
                'U', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         0, 1, 1, 1, 0
                     }
                );
            this.Add(
                'V', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         0, 1, 0, 1, 0,
                         0, 0, 1, 0, 0
                     }
                );
            this.Add(
                'W', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         1, 0, 0, 0, 1,
                         1, 0, 1, 0, 1,
                         1, 1, 0, 1, 1,
                         1, 0, 0, 0, 1
                     }
                );
            this.Add(
                'X', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         0, 1, 0, 1, 0,
                         0, 0, 1, 0, 0,
                         0, 1, 0, 1, 0,
                         1, 0, 0, 0, 1
                     }
                );
            this.Add(
                'Y', new byte[]
                     {
                         1, 0, 0, 0, 1,
                         0, 1, 0, 1, 0,
                         0, 0, 1, 0, 0,
                         0, 0, 1, 0, 0,
                         0, 0, 1, 0, 0
                     }
                );
            this.Add(
                'Z', new byte[]
                     {
                         1, 1, 1, 1, 1,
                         0, 0, 0, 1, 0,
                         0, 0, 1, 0, 0,
                         0, 1, 0, 0, 0,
                         1, 1, 1, 1, 1
                     }
                );
        }

        #endregion Constructors
    }
}