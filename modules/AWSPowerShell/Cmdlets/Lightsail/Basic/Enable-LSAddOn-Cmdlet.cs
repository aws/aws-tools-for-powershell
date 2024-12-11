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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Enables or modifies an add-on for an Amazon Lightsail resource. For more information,
    /// see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-configuring-automatic-snapshots">Amazon
    /// Lightsail Developer Guide</a>.
    /// </summary>
    [Cmdlet("Enable", "LSAddOn", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail EnableAddOn API operation.", Operation = new[] {"EnableAddOn"}, SelectReturnType = typeof(Amazon.Lightsail.Model.EnableAddOnResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.EnableAddOnResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.EnableAddOnResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableLSAddOnCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddOnRequest_AddOnType
        /// <summary>
        /// <para>
        /// <para>The add-on type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.AddOnType")]
        public Amazon.Lightsail.AddOnType AddOnRequest_AddOnType { get; set; }
        #endregion
        
        #region Parameter StopInstanceOnIdleRequest_Duration
        /// <summary>
        /// <para>
        /// <para>The amount of idle time in minutes after which your virtual computer will automatically
        /// stop.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddOnRequest_StopInstanceOnIdleRequest_Duration")]
        public System.String StopInstanceOnIdleRequest_Duration { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the source resource for which to enable or modify the add-on.</para>
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
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter AutoSnapshotAddOnRequest_SnapshotTimeOfDay
        /// <summary>
        /// <para>
        /// <para>The daily time when an automatic snapshot will be created.</para><para>Constraints:</para><ul><li><para>Must be in <c>HH:00</c> format, and in an hourly increment.</para></li><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>The snapshot will be automatically created between the time specified and up to 45
        /// minutes after.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddOnRequest_AutoSnapshotAddOnRequest_SnapshotTimeOfDay")]
        public System.String AutoSnapshotAddOnRequest_SnapshotTimeOfDay { get; set; }
        #endregion
        
        #region Parameter StopInstanceOnIdleRequest_Threshold
        /// <summary>
        /// <para>
        /// <para>The value to compare with the duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddOnRequest_StopInstanceOnIdleRequest_Threshold")]
        public System.String StopInstanceOnIdleRequest_Threshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.EnableAddOnResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.EnableAddOnResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-LSAddOn (EnableAddOn)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.EnableAddOnResponse, EnableLSAddOnCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AddOnRequest_AddOnType = this.AddOnRequest_AddOnType;
            #if MODULAR
            if (this.AddOnRequest_AddOnType == null && ParameterWasBound(nameof(this.AddOnRequest_AddOnType)))
            {
                WriteWarning("You are passing $null as a value for parameter AddOnRequest_AddOnType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoSnapshotAddOnRequest_SnapshotTimeOfDay = this.AutoSnapshotAddOnRequest_SnapshotTimeOfDay;
            context.StopInstanceOnIdleRequest_Duration = this.StopInstanceOnIdleRequest_Duration;
            context.StopInstanceOnIdleRequest_Threshold = this.StopInstanceOnIdleRequest_Threshold;
            context.ResourceName = this.ResourceName;
            #if MODULAR
            if (this.ResourceName == null && ParameterWasBound(nameof(this.ResourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.EnableAddOnRequest();
            
            
             // populate AddOnRequest
            var requestAddOnRequestIsNull = true;
            request.AddOnRequest = new Amazon.Lightsail.Model.AddOnRequest();
            Amazon.Lightsail.AddOnType requestAddOnRequest_addOnRequest_AddOnType = null;
            if (cmdletContext.AddOnRequest_AddOnType != null)
            {
                requestAddOnRequest_addOnRequest_AddOnType = cmdletContext.AddOnRequest_AddOnType;
            }
            if (requestAddOnRequest_addOnRequest_AddOnType != null)
            {
                request.AddOnRequest.AddOnType = requestAddOnRequest_addOnRequest_AddOnType;
                requestAddOnRequestIsNull = false;
            }
            Amazon.Lightsail.Model.AutoSnapshotAddOnRequest requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest = null;
            
             // populate AutoSnapshotAddOnRequest
            var requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequestIsNull = true;
            requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest = new Amazon.Lightsail.Model.AutoSnapshotAddOnRequest();
            System.String requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest_autoSnapshotAddOnRequest_SnapshotTimeOfDay = null;
            if (cmdletContext.AutoSnapshotAddOnRequest_SnapshotTimeOfDay != null)
            {
                requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest_autoSnapshotAddOnRequest_SnapshotTimeOfDay = cmdletContext.AutoSnapshotAddOnRequest_SnapshotTimeOfDay;
            }
            if (requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest_autoSnapshotAddOnRequest_SnapshotTimeOfDay != null)
            {
                requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest.SnapshotTimeOfDay = requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest_autoSnapshotAddOnRequest_SnapshotTimeOfDay;
                requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequestIsNull = false;
            }
             // determine if requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest should be set to null
            if (requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequestIsNull)
            {
                requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest = null;
            }
            if (requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest != null)
            {
                request.AddOnRequest.AutoSnapshotAddOnRequest = requestAddOnRequest_addOnRequest_AutoSnapshotAddOnRequest;
                requestAddOnRequestIsNull = false;
            }
            Amazon.Lightsail.Model.StopInstanceOnIdleRequest requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest = null;
            
             // populate StopInstanceOnIdleRequest
            var requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequestIsNull = true;
            requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest = new Amazon.Lightsail.Model.StopInstanceOnIdleRequest();
            System.String requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest_stopInstanceOnIdleRequest_Duration = null;
            if (cmdletContext.StopInstanceOnIdleRequest_Duration != null)
            {
                requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest_stopInstanceOnIdleRequest_Duration = cmdletContext.StopInstanceOnIdleRequest_Duration;
            }
            if (requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest_stopInstanceOnIdleRequest_Duration != null)
            {
                requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest.Duration = requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest_stopInstanceOnIdleRequest_Duration;
                requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequestIsNull = false;
            }
            System.String requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest_stopInstanceOnIdleRequest_Threshold = null;
            if (cmdletContext.StopInstanceOnIdleRequest_Threshold != null)
            {
                requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest_stopInstanceOnIdleRequest_Threshold = cmdletContext.StopInstanceOnIdleRequest_Threshold;
            }
            if (requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest_stopInstanceOnIdleRequest_Threshold != null)
            {
                requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest.Threshold = requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest_stopInstanceOnIdleRequest_Threshold;
                requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequestIsNull = false;
            }
             // determine if requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest should be set to null
            if (requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequestIsNull)
            {
                requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest = null;
            }
            if (requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest != null)
            {
                request.AddOnRequest.StopInstanceOnIdleRequest = requestAddOnRequest_addOnRequest_StopInstanceOnIdleRequest;
                requestAddOnRequestIsNull = false;
            }
             // determine if request.AddOnRequest should be set to null
            if (requestAddOnRequestIsNull)
            {
                request.AddOnRequest = null;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
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
        
        private Amazon.Lightsail.Model.EnableAddOnResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.EnableAddOnRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "EnableAddOn");
            try
            {
                #if DESKTOP
                return client.EnableAddOn(request);
                #elif CORECLR
                return client.EnableAddOnAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Lightsail.AddOnType AddOnRequest_AddOnType { get; set; }
            public System.String AutoSnapshotAddOnRequest_SnapshotTimeOfDay { get; set; }
            public System.String StopInstanceOnIdleRequest_Duration { get; set; }
            public System.String StopInstanceOnIdleRequest_Threshold { get; set; }
            public System.String ResourceName { get; set; }
            public System.Func<Amazon.Lightsail.Model.EnableAddOnResponse, EnableLSAddOnCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
