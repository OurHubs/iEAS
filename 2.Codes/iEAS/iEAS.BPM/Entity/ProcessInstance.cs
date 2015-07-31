﻿using System;
using System.Activities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class ProcessInstance
    {
        private int _State = -1;

        internal ProcessInstance()
        {
        }

        #region 属性
        public int Id { get; set; }
        /// <summary>
        /// 流程Id
        /// </summary>
        public int ProcessId { get; set; }
        /// <summary>
        /// 应用实例Id
        /// </summary>
        public Guid ApplicationId { get; internal set; }
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// 流程发起人
        /// </summary>
        public string Originator { get; set; }
        /// <summary>
        /// 完成状态
        /// -1:未发起，0：运转中,1：已完成,2:取消,3:终止,4:异常
        /// </summary>
        public int State
        {
            get { return _State; }
            set { _State = value; }
        }
        /// <summary>
        /// 流程信息
        /// </summary>
        public Process Process { get; internal set; }
        /// <summary>
        /// 流程活动的节点实例
        /// </summary>
        public List<ActivityInstance> Activities { get; internal set; }
        #endregion

        #region 方法

        /// <summary>
        /// 发起流程
        /// </summary>
        public void Start()
        {
            WorkflowApplication workflowApplication = CreateApplication();
            RegisterEvents(workflowApplication);           
            using(var rep=new BPMRepository())
            {
                rep.Entry(this).State = EntityState.Modified;
                this.State = 0;
                this.ApplicationId = workflowApplication.Id;               
                rep.SaveChanges();
            }
            workflowApplication.Run();
        }

        private WorkflowApplication CreateApplication()
        {
            System.Activities.Activity activity = new Test();
            return new WorkflowApplication(activity);
        }

        private void RegisterEvents(WorkflowApplication application)
        {
            application.Completed += OnCompleted;
        }

        private void OnCompleted(WorkflowApplicationCompletedEventArgs args)
        {
            using (var rep=new BPMRepository())
            {
                rep.Entry(this).State = EntityState.Modified;
                this.State = 2;
                rep.SaveChanges();
            }

            Console.WriteLine("============================Begin===================================");

            Console.WriteLine("完成:");
            Console.WriteLine("Id:{0}", args.InstanceId);
            Console.WriteLine("完成状态:{0}", args.CompletionState);

            Console.WriteLine("============================End===================================");
        }



        #endregion
    }
}