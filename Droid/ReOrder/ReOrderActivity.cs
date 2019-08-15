using System.Collections.ObjectModel;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper; 

namespace NativeCodeLog.Droid
{
    [Activity(Label = "ReOrderListItem")]
    public class ReOrderActivity : Activity, IOnStartDragListener
    { 
        private ItemTouchHelper _mItemTouchHelper;
        public static ObservableCollection<string> ResourceList;
        private RecyclerView _resourceReorderRecyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ReOrderLayout);
            GetCollection();

            var resourceAdapter = new ReOrderAdapters(ResourceList, this);

            // Initialize the recycler view.
            _resourceReorderRecyclerView = FindViewById<RecyclerView>(Resource.Id.ResourceReorderRecyclerView);
            _resourceReorderRecyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Vertical, false));
            _resourceReorderRecyclerView.SetAdapter(resourceAdapter);
            _resourceReorderRecyclerView.HasFixedSize = true; 

            ItemTouchHelper.Callback callback = new SimpleItemTouchHelperCallback(resourceAdapter);
            _mItemTouchHelper = new ItemTouchHelper(callback);
            _mItemTouchHelper.AttachToRecyclerView(_resourceReorderRecyclerView);
        }

        public void OnStartDrag(RecyclerView.ViewHolder viewHolder)
        {
            _mItemTouchHelper.StartDrag(viewHolder);
        }

        //Added sample data record here
        public void GetCollection()
        {
            ResourceList = new ObservableCollection<string>();
            ResourceList.Add("OnPause()");
            ResourceList.Add("OnStart()");
            ResourceList.Add("OnCreate()");
        }
    }
}
