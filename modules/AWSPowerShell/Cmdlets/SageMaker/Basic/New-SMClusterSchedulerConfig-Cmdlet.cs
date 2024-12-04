/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Create cluster policy configuration. This policy is used for task prioritization and
    /// fair-share allocation of idle compute. This helps prioritize critical workloads and
    /// distributes idle compute across entities.
    /// </summary>
    [Cmdlet("New", "SMClusterSchedulerConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateClusterSchedulerConfig API operation.", Operation = new[] {"CreateClusterSchedulerConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse object containing multiple properties."
    )]
    public partial class NewSMClusterSchedulerConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>ARN of the cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the cluster policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SchedulerConfig_FairShare
        /// <summary>
        /// <para>
        /// <para>When enabled, entities borrow idle compute based on their assigned <c>FairShareWeight</c>.</para><para>When disabled, entities borrow idle compute based on a first-come first-serve basis.</para><para>Default is <c>Enabled</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.FairShare")]
        public Amazon.SageMaker.FairShare SchedulerConfig_FairShare { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name for the cluster policy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SchedulerConfig_PriorityClass
        /// <summary>
        /// <para>
        /// <para>List of the priority classes, <c>PriorityClass</c>, of the cluster policy. When specified,
        /// these class configurations define how tasks are queued.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchedulerConfig_PriorityClasses")]
        public Amazon.SageMaker.Model.PriorityClass[] SchedulerConfig_PriorityClass { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags of the cluster policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMClusterSchedulerConfig (CreateClusterSchedulerConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse, NewSMClusterSchedulerConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SchedulerConfig_FairShare = this.SchedulerConfig_FairShare;
            if (this.SchedulerConfig_PriorityClass != null)
            {
                context.SchedulerConfig_PriorityClass = new List<Amazon.SageMaker.Model.PriorityClass>(this.SchedulerConfig_PriorityClass);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.SageMaker.Model.CreateClusterSchedulerConfigRequest();
            
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SchedulerConfig
            var requestSchedulerConfigIsNull = true;
            request.SchedulerConfig = new Amazon.SageMaker.Model.SchedulerConfig();
            Amazon.SageMaker.FairShare requestSchedulerConfig_schedulerConfig_FairShare = null;
            if (cmdletContext.SchedulerConfig_FairShare != null)
            {
                requestSchedulerConfig_schedulerConfig_FairShare = cmdletContext.SchedulerConfig_FairShare;
            }
            if (requestSchedulerConfig_schedulerConfig_FairShare != null)
            {
                request.SchedulerConfig.FairShare = requestSchedulerConfig_schedulerConfig_FairShare;
                requestSchedulerConfigIsNull = false;
            }
            List<Amazon.SageMaker.Model.PriorityClass> requestSchedulerConfig_schedulerConfig_PriorityClass = null;
            if (cmdletContext.SchedulerConfig_PriorityClass != null)
            {
                requestSchedulerConfig_schedulerConfig_PriorityClass = cmdletContext.SchedulerConfig_PriorityClass;
            }
            if (requestSchedulerConfig_schedulerConfig_PriorityClass != null)
            {
                request.SchedulerConfig.PriorityClasses = requestSchedulerConfig_schedulerConfig_PriorityClass;
                requestSchedulerConfigIsNull = false;
            }
             // determine if request.SchedulerConfig should be set to null
            if (requestSchedulerConfigIsNull)
            {
                request.SchedulerConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateClusterSchedulerConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateClusterSchedulerConfig");
            try
            {
                #if DESKTOP
                return client.CreateClusterSchedulerConfig(request);
                #elif CORECLR
                return client.CreateClusterSchedulerConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Amazon.SageMaker.FairShare SchedulerConfig_FairShare { get; set; }
            public List<Amazon.SageMaker.Model.PriorityClass> SchedulerConfig_PriorityClass { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateClusterSchedulerConfigResponse, NewSMClusterSchedulerConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
