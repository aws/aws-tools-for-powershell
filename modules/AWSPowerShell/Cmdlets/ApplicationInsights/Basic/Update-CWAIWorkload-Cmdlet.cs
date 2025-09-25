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
using Amazon.ApplicationInsights;
using Amazon.ApplicationInsights.Model;

namespace Amazon.PowerShell.Cmdlets.CWAI
{
    /// <summary>
    /// Adds a workload to a component. Each component can have at most five workloads.
    /// </summary>
    [Cmdlet("Update", "CWAIWorkload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationInsights.Model.UpdateWorkloadResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Insights UpdateWorkload API operation.", Operation = new[] {"UpdateWorkload"}, SelectReturnType = typeof(Amazon.ApplicationInsights.Model.UpdateWorkloadResponse))]
    [AWSCmdletOutput("Amazon.ApplicationInsights.Model.UpdateWorkloadResponse",
        "This cmdlet returns an Amazon.ApplicationInsights.Model.UpdateWorkloadResponse object containing multiple properties."
    )]
    public partial class UpdateCWAIWorkloadCmdlet : AmazonApplicationInsightsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComponentName
        /// <summary>
        /// <para>
        /// <para> The name of the component. </para>
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
        public System.String ComponentName { get; set; }
        #endregion
        
        #region Parameter WorkloadConfiguration_Configuration
        /// <summary>
        /// <para>
        /// <para>The configuration settings of the workload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkloadConfiguration_Configuration { get; set; }
        #endregion
        
        #region Parameter ResourceGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the resource group.</para>
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
        public System.String ResourceGroupName { get; set; }
        #endregion
        
        #region Parameter WorkloadConfiguration_Tier
        /// <summary>
        /// <para>
        /// <para>The configuration of the workload tier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationInsights.Tier")]
        public Amazon.ApplicationInsights.Tier WorkloadConfiguration_Tier { get; set; }
        #endregion
        
        #region Parameter WorkloadId
        /// <summary>
        /// <para>
        /// <para>The ID of the workload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkloadId { get; set; }
        #endregion
        
        #region Parameter WorkloadConfiguration_WorkloadName
        /// <summary>
        /// <para>
        /// <para>The name of the workload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkloadConfiguration_WorkloadName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationInsights.Model.UpdateWorkloadResponse).
        /// Specifying the name of a property of type Amazon.ApplicationInsights.Model.UpdateWorkloadResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWAIWorkload (UpdateWorkload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationInsights.Model.UpdateWorkloadResponse, UpdateCWAIWorkloadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComponentName = this.ComponentName;
            #if MODULAR
            if (this.ComponentName == null && ParameterWasBound(nameof(this.ComponentName)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceGroupName = this.ResourceGroupName;
            #if MODULAR
            if (this.ResourceGroupName == null && ParameterWasBound(nameof(this.ResourceGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkloadConfiguration_Configuration = this.WorkloadConfiguration_Configuration;
            context.WorkloadConfiguration_Tier = this.WorkloadConfiguration_Tier;
            context.WorkloadConfiguration_WorkloadName = this.WorkloadConfiguration_WorkloadName;
            context.WorkloadId = this.WorkloadId;
            
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
            var request = new Amazon.ApplicationInsights.Model.UpdateWorkloadRequest();
            
            if (cmdletContext.ComponentName != null)
            {
                request.ComponentName = cmdletContext.ComponentName;
            }
            if (cmdletContext.ResourceGroupName != null)
            {
                request.ResourceGroupName = cmdletContext.ResourceGroupName;
            }
            
             // populate WorkloadConfiguration
            var requestWorkloadConfigurationIsNull = true;
            request.WorkloadConfiguration = new Amazon.ApplicationInsights.Model.WorkloadConfiguration();
            System.String requestWorkloadConfiguration_workloadConfiguration_Configuration = null;
            if (cmdletContext.WorkloadConfiguration_Configuration != null)
            {
                requestWorkloadConfiguration_workloadConfiguration_Configuration = cmdletContext.WorkloadConfiguration_Configuration;
            }
            if (requestWorkloadConfiguration_workloadConfiguration_Configuration != null)
            {
                request.WorkloadConfiguration.Configuration = requestWorkloadConfiguration_workloadConfiguration_Configuration;
                requestWorkloadConfigurationIsNull = false;
            }
            Amazon.ApplicationInsights.Tier requestWorkloadConfiguration_workloadConfiguration_Tier = null;
            if (cmdletContext.WorkloadConfiguration_Tier != null)
            {
                requestWorkloadConfiguration_workloadConfiguration_Tier = cmdletContext.WorkloadConfiguration_Tier;
            }
            if (requestWorkloadConfiguration_workloadConfiguration_Tier != null)
            {
                request.WorkloadConfiguration.Tier = requestWorkloadConfiguration_workloadConfiguration_Tier;
                requestWorkloadConfigurationIsNull = false;
            }
            System.String requestWorkloadConfiguration_workloadConfiguration_WorkloadName = null;
            if (cmdletContext.WorkloadConfiguration_WorkloadName != null)
            {
                requestWorkloadConfiguration_workloadConfiguration_WorkloadName = cmdletContext.WorkloadConfiguration_WorkloadName;
            }
            if (requestWorkloadConfiguration_workloadConfiguration_WorkloadName != null)
            {
                request.WorkloadConfiguration.WorkloadName = requestWorkloadConfiguration_workloadConfiguration_WorkloadName;
                requestWorkloadConfigurationIsNull = false;
            }
             // determine if request.WorkloadConfiguration should be set to null
            if (requestWorkloadConfigurationIsNull)
            {
                request.WorkloadConfiguration = null;
            }
            if (cmdletContext.WorkloadId != null)
            {
                request.WorkloadId = cmdletContext.WorkloadId;
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
        
        private Amazon.ApplicationInsights.Model.UpdateWorkloadResponse CallAWSServiceOperation(IAmazonApplicationInsights client, Amazon.ApplicationInsights.Model.UpdateWorkloadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Insights", "UpdateWorkload");
            try
            {
                #if DESKTOP
                return client.UpdateWorkload(request);
                #elif CORECLR
                return client.UpdateWorkloadAsync(request).GetAwaiter().GetResult();
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
            public System.String ComponentName { get; set; }
            public System.String ResourceGroupName { get; set; }
            public System.String WorkloadConfiguration_Configuration { get; set; }
            public Amazon.ApplicationInsights.Tier WorkloadConfiguration_Tier { get; set; }
            public System.String WorkloadConfiguration_WorkloadName { get; set; }
            public System.String WorkloadId { get; set; }
            public System.Func<Amazon.ApplicationInsights.Model.UpdateWorkloadResponse, UpdateCWAIWorkloadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
