using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRPG.View
{
    public class TestSheet
    {
        private ElementReference spriteSheetImage;

        public TestSheet(ElementReference spriteSheetImage)
        {
            this.spriteSheetImage = spriteSheetImage;
        }

        public async Task DrawFloor(Canvas2DContext context, int X, int Y, int Width, int Height)
        {
            await context.DrawImageAsync(spriteSheetImage, 0, 0, 128, 128, X, Y, Width, Height);
        }

        public async Task DrawPlayer(Canvas2DContext context, int X, int Y, int Width, int Height)
        {
            await context.DrawImageAsync(spriteSheetImage, 0, 9 * 128, 128, 128, X, Y, Width, Height);
        }
    }
}
