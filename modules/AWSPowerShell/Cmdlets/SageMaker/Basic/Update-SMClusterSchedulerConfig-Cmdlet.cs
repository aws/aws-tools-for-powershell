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
using System.Threading;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Update the cluster policy configuration.
    /// </summary>
    [Cmdlet("Update", "SMClusterSchedulerConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateClusterSchedulerConfig API operation.", Operation = new[] {"UpdateClusterSchedulerConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse object containing multiple properties."
    )]
    public partial class UpdateSMClusterSchedulerConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterSchedulerConfigId
        /// <summary>
        /// <para>
        /// <para>ID of the cluster policy.</para>
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
        public System.String ClusterSchedulerConfigId { get; set; }
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
        
        #region Parameter SchedulerConfig_PriorityClass
        /// <summary>
        /// <para>
        /// <para>List of the priority classes, <c>PriorityClass</c>, of the cluster policy. When specified,
        /// these class configurations define how tasks are queued.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchedulerConfig_PriorityClasses")]
        public Amazon.SageMaker.Model.PriorityClass[] SchedulerConfig_PriorityClass { get; set; }
        #endregion
        
        #region Parameter TargetVersion
        /// <summary>
        /// <para>
        /// <para>Target version.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TargetVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterSchedulerConfigId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMClusterSchedulerConfig (UpdateClusterSchedulerConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse, UpdateSMClusterSchedulerConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterSchedulerConfigId = this.ClusterSchedulerConfigId;
            #if MODULAR
            if (this.ClusterSchedulerConfigId == null && ParameterWasBound(nameof(this.ClusterSchedulerConfigId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterSchedulerConfigId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.SchedulerConfig_FairShare = this.SchedulerConfig_FairShare;
            if (this.SchedulerConfig_PriorityClass != null)
            {
                context.SchedulerConfig_PriorityClass = new List<Amazon.SageMaker.Model.PriorityClass>(this.SchedulerConfig_PriorityClass);
            }
            context.TargetVersion = this.TargetVersion;
            #if MODULAR
            if (this.TargetVersion == null && ParameterWasBound(nameof(this.TargetVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SageMaker.Model.UpdateClusterSchedulerConfigRequest();
            
            if (cmdletContext.ClusterSchedulerConfigId != null)
            {
                request.ClusterSchedulerConfigId = cmdletContext.ClusterSchedulerConfigId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
            if (cmdletContext.TargetVersion != null)
            {
                request.TargetVersion = cmdletContext.TargetVersion.Value;
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
        
        private Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateClusterSchedulerConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateClusterSchedulerConfig");
            try
            {
                return client.UpdateClusterSchedulerConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterSchedulerConfigId { get; set; }
            public System.String Description { get; set; }
            public Amazon.SageMaker.FairShare SchedulerConfig_FairShare { get; set; }
            public List<Amazon.SageMaker.Model.PriorityClass> SchedulerConfig_PriorityClass { get; set; }
            public System.Int32? TargetVersion { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateClusterSchedulerConfigResponse, UpdateSMClusterSchedulerConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
