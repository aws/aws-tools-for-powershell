/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Starts the specified capacity task. You can have one active capacity task for each
    /// order and each Outpost.
    /// </summary>
    [Cmdlet("Start", "OUTPCapacityTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.StartCapacityTaskResponse")]
    [AWSCmdlet("Calls the AWS Outposts StartCapacityTask API operation.", Operation = new[] {"StartCapacityTask"}, SelectReturnType = typeof(Amazon.Outposts.Model.StartCapacityTaskResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.StartCapacityTaskResponse",
        "This cmdlet returns an Amazon.Outposts.Model.StartCapacityTaskResponse object containing multiple properties."
    )]
    public partial class StartOUTPCapacityTaskCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstancesToExclude_AccountId
        /// <summary>
        /// <para>
        /// <para>IDs of the accounts that own each instance that must not be stopped.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstancesToExclude_AccountIds")]
        public System.String[] InstancesToExclude_AccountId { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>You can request a dry run to determine if the instance type and instance size changes
        /// is above or below available instance capacity. Requesting a dry run does not make
        /// any changes to your plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter InstancePool
        /// <summary>
        /// <para>
        /// <para>The instance pools specified in the capacity task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstancePools")]
        public Amazon.Outposts.Model.InstanceTypeCapacity[] InstancePool { get; set; }
        #endregion
        
        #region Parameter InstancesToExclude_Instance
        /// <summary>
        /// <para>
        /// <para>List of user-specified instances that must not be stopped.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstancesToExclude_Instances")]
        public System.String[] InstancesToExclude_Instance { get; set; }
        #endregion
        
        #region Parameter OrderId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Outposts order associated with the specified capacity
        /// task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrderId { get; set; }
        #endregion
        
        #region Parameter OutpostIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the Outposts associated with the specified capacity task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OutpostIdentifier { get; set; }
        #endregion
        
        #region Parameter InstancesToExclude_Service
        /// <summary>
        /// <para>
        /// <para>Names of the services that own each instance that must not be stopped in order to
        /// free up the capacity needed to run the capacity task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstancesToExclude_Services")]
        public System.String[] InstancesToExclude_Service { get; set; }
        #endregion
        
        #region Parameter TaskActionOnBlockingInstance
        /// <summary>
        /// <para>
        /// <para>Specify one of the following options in case an instance is blocking the capacity
        /// task from running.</para><ul><li><para><c>WAIT_FOR_EVACUATION</c> - Checks every 10 minutes over 48 hours to determine if
        /// instances have stopped and capacity is available to complete the task.</para></li><li><para><c>FAIL_TASK</c> - The capacity task fails.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskActionOnBlockingInstances")]
        [AWSConstantClassSource("Amazon.Outposts.TaskActionOnBlockingInstances")]
        public Amazon.Outposts.TaskActionOnBlockingInstances TaskActionOnBlockingInstance { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.StartCapacityTaskResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.StartCapacityTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutpostIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-OUTPCapacityTask (StartCapacityTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.StartCapacityTaskResponse, StartOUTPCapacityTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            if (this.InstancePool != null)
            {
                context.InstancePool = new List<Amazon.Outposts.Model.InstanceTypeCapacity>(this.InstancePool);
            }
            #if MODULAR
            if (this.InstancePool == null && ParameterWasBound(nameof(this.InstancePool)))
            {
                WriteWarning("You are passing $null as a value for parameter InstancePool which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InstancesToExclude_AccountId != null)
            {
                context.InstancesToExclude_AccountId = new List<System.String>(this.InstancesToExclude_AccountId);
            }
            if (this.InstancesToExclude_Instance != null)
            {
                context.InstancesToExclude_Instance = new List<System.String>(this.InstancesToExclude_Instance);
            }
            if (this.InstancesToExclude_Service != null)
            {
                context.InstancesToExclude_Service = new List<System.String>(this.InstancesToExclude_Service);
            }
            context.OrderId = this.OrderId;
            context.OutpostIdentifier = this.OutpostIdentifier;
            #if MODULAR
            if (this.OutpostIdentifier == null && ParameterWasBound(nameof(this.OutpostIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OutpostIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskActionOnBlockingInstance = this.TaskActionOnBlockingInstance;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Outposts.Model.StartCapacityTaskRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.InstancePool != null)
            {
                request.InstancePools = cmdletContext.InstancePool;
            }
            
             // populate InstancesToExclude
            var requestInstancesToExcludeIsNull = true;
            request.InstancesToExclude = new Amazon.Outposts.Model.InstancesToExclude();
            List<System.String> requestInstancesToExclude_instancesToExclude_AccountId = null;
            if (cmdletContext.InstancesToExclude_AccountId != null)
            {
                requestInstancesToExclude_instancesToExclude_AccountId = cmdletContext.InstancesToExclude_AccountId;
            }
            if (requestInstancesToExclude_instancesToExclude_AccountId != null)
            {
                request.InstancesToExclude.AccountIds = requestInstancesToExclude_instancesToExclude_AccountId;
                requestInstancesToExcludeIsNull = false;
            }
            List<System.String> requestInstancesToExclude_instancesToExclude_Instance = null;
            if (cmdletContext.InstancesToExclude_Instance != null)
            {
                requestInstancesToExclude_instancesToExclude_Instance = cmdletContext.InstancesToExclude_Instance;
            }
            if (requestInstancesToExclude_instancesToExclude_Instance != null)
            {
                request.InstancesToExclude.Instances = requestInstancesToExclude_instancesToExclude_Instance;
                requestInstancesToExcludeIsNull = false;
            }
            List<System.String> requestInstancesToExclude_instancesToExclude_Service = null;
            if (cmdletContext.InstancesToExclude_Service != null)
            {
                requestInstancesToExclude_instancesToExclude_Service = cmdletContext.InstancesToExclude_Service;
            }
            if (requestInstancesToExclude_instancesToExclude_Service != null)
            {
                request.InstancesToExclude.Services = requestInstancesToExclude_instancesToExclude_Service;
                requestInstancesToExcludeIsNull = false;
            }
             // determine if request.InstancesToExclude should be set to null
            if (requestInstancesToExcludeIsNull)
            {
                request.InstancesToExclude = null;
            }
            if (cmdletContext.OrderId != null)
            {
                request.OrderId = cmdletContext.OrderId;
            }
            if (cmdletContext.OutpostIdentifier != null)
            {
                request.OutpostIdentifier = cmdletContext.OutpostIdentifier;
            }
            if (cmdletContext.TaskActionOnBlockingInstance != null)
            {
                request.TaskActionOnBlockingInstances = cmdletContext.TaskActionOnBlockingInstance;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Outposts.Model.StartCapacityTaskResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.StartCapacityTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "StartCapacityTask");
            try
            {
                #if DESKTOP
                return client.StartCapacityTask(request);
                #elif CORECLR
                return client.StartCapacityTaskAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Boolean? DryRun { get; set; }
            public List<Amazon.Outposts.Model.InstanceTypeCapacity> InstancePool { get; set; }
            public List<System.String> InstancesToExclude_AccountId { get; set; }
            public List<System.String> InstancesToExclude_Instance { get; set; }
            public List<System.String> InstancesToExclude_Service { get; set; }
            public System.String OrderId { get; set; }
            public System.String OutpostIdentifier { get; set; }
            public Amazon.Outposts.TaskActionOnBlockingInstances TaskActionOnBlockingInstance { get; set; }
            public System.Func<Amazon.Outposts.Model.StartCapacityTaskResponse, StartOUTPCapacityTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
