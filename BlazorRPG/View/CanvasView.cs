using Blazor.Extensions.Canvas.Canvas2D;
using BlazorRPG.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRPG.View
{
    public class CanvasView
    {
        private Player player;
        private Canvas2DContext context;
        private TestSheet testSheet;

        public CanvasView(Player player, Canvas2DContext context, TestSheet testSheet)
        {
            this.player = player;
            this.context = context;
            this.testSheet = testSheet;
        }

        public async Task RenderFrame(int viewWidth, int viewHeight)
        {
            await context.BeginBatchAsync();

            await testSheet.DrawFloor(context, 0, 0, viewWidth, viewHeight);

            await context.EndBatchAsync();
        }
    }
}
