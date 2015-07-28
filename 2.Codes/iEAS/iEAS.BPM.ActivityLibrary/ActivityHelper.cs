using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.ActivityLibrary
{
    public static class ActivityFactory
    {
        public static Activity GetActivity(ActivityMetadata metadata)
        {
            Activity activity = null;
            if (metadata.ApproveType == ApproveType.Sequence)
            {
                activity = CreateSequenceActivity(metadata);
            }
            else if (metadata.ApproveType == ApproveType.Parallel)
            {
                activity = CreateSequenceActivity(metadata);
            }

            return activity;
        }

        public static DynamicActivity CreateSequenceActivity(ActivityMetadata metadata)
        {
            DynamicActivity activity = new DynamicActivity();
            activity.DisplayName = activity.Name = metadata.ActivityName;
            activity.Properties.Clear();
            activity.Properties.Add(new DynamicActivityProperty
            {
                Name = "Approvers",
                Type = typeof(InArgument<List<string>>),
                Value = new List<string>
                {
                    "A",
                    "B",
                    "C",
                    "D"
                }
            });
            activity.Implementation = () =>
            {
                Sequence seq = new Sequence();
                seq.Activities.Clear();
                seq.Activities.Add(new WriteLine { Text = "Hello World!" });
                return seq;
            };
            return activity;
        }
    }
}
