using Android.Support.V7.Widget;

namespace NativeCodeLog.Droid
{
    public interface IOnStartDragListener
    {
        /**
     * Called when a view is requesting a start of a drag.
     *
     * @param viewHolder The holder of the view to drag.
     */
        void OnStartDrag(RecyclerView.ViewHolder viewHolder);
    }
}
