using Android.Views;
using System.Collections.ObjectModel;
using Android.Support.V7.Widget; 
using Android.Widget;
using static Android.Views.View;

namespace NativeCodeLog.Droid
{
    public class ReOrderAdapters : RecyclerView.Adapter, ITemTouchHelperAdapter, IOnLongClickListener
    {
        private readonly ObservableCollection<string> _itemList;
        private readonly IOnStartDragListener _mDragStartListener;
        private ReOrderViewHolder _reOrderViewHolder;

        public ReOrderAdapters(ObservableCollection<string> list, IOnStartDragListener mDragStartListener)
        {
            _itemList = list;
            _mDragStartListener = mDragStartListener;
        }

        public override int ItemCount => _itemList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as ReOrderViewHolder;
            if (viewHolder == null) return;

            _reOrderViewHolder = viewHolder;
            viewHolder.ReorderView.SetOnLongClickListener(this);
            viewHolder.ResourceName.Text = (_itemList[position]); 
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var itemView = inflater.Inflate(Resource.Layout.CustomListItemReorder, parent, false);
            return new ReOrderViewHolder(itemView);
        }

        public void OnItemDismiss(int position)
        {
            var item = _itemList[position];
            _itemList.Remove(item);
            NotifyItemRemoved(position);
        }

        public bool OnItemMove(int fromPosition, int toPosition)
        {
            var tempPlanResource = _itemList[fromPosition];
            _itemList[fromPosition] = _itemList[toPosition];
            _itemList[toPosition] = tempPlanResource;

            ReOrderActivity.ResourceList = _itemList;
            NotifyItemMoved(fromPosition, toPosition);
            return true;
        }

        public bool OnLongClick(View v)
        {
            _mDragStartListener.OnStartDrag(_reOrderViewHolder);
            return true;
        }
    }

    public class ReOrderViewHolder : RecyclerView.ViewHolder
    { 
        public LinearLayout ReorderView;
        public ImageView ReorderIcon;
        public TextView ResourceName; 

        public ReOrderViewHolder(View view) : base(view)
        {
            ResourceName = view.FindViewById<TextView>(Resource.Id.mTVResourceName);
            ReorderView = view.FindViewById<LinearLayout>(Resource.Id.ReorderView);
            ReorderIcon = view.FindViewById<ImageView>(Resource.Id.mTvReorderIcon); 
        }
    } 
}
