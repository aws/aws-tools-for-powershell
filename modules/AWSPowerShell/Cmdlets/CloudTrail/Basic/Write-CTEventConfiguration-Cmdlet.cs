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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Updates the event configuration settings for the specified event data store. You can
    /// update the maximum event size and context key selectors.
    /// </summary>
    [Cmdlet("Write", "CTEventConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.PutEventConfigurationResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail PutEventConfiguration API operation.", Operation = new[] {"PutEventConfiguration"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.PutEventConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.PutEventConfigurationResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.PutEventConfigurationResponse object containing multiple properties."
    )]
    public partial class WriteCTEventConfigurationCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContextKeySelector
        /// <summary>
        /// <para>
        /// <para>A list of context key selectors that will be included to provide enriched event data.</para>
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
        [Alias("ContextKeySelectors")]
        public Amazon.CloudTrail.Model.ContextKeySelector[] ContextKeySelector { get; set; }
        #endregion
        
        #region Parameter EventDataStore
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or ID suffix of the ARN of the event data store for
        /// which you want to update event configuration settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventDataStore { get; set; }
        #endregion
        
        #region Parameter MaxEventSize
        /// <summary>
        /// <para>
        /// <para>The maximum allowed size for events to be stored in the specified event data store.
        /// If you are using context key selectors, MaxEventSize must be set to Large.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudTrail.MaxEventSize")]
        public Amazon.CloudTrail.MaxEventSize MaxEventSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.PutEventConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.PutEventConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MaxEventSize), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CTEventConfiguration (PutEventConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.PutEventConfigurationResponse, WriteCTEventConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ContextKeySelector != null)
            {
                context.ContextKeySelector = new List<Amazon.CloudTrail.Model.ContextKeySelector>(this.ContextKeySelector);
            }
            #if MODULAR
            if (this.ContextKeySelector == null && ParameterWasBound(nameof(this.ContextKeySelector)))
            {
                WriteWarning("You are passing $null as a value for parameter ContextKeySelector which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventDataStore = this.EventDataStore;
            context.MaxEventSize = this.MaxEventSize;
            #if MODULAR
            if (this.MaxEventSize == null && ParameterWasBound(nameof(this.MaxEventSize)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxEventSize which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudTrail.Model.PutEventConfigurationRequest();
            
            if (cmdletContext.ContextKeySelector != null)
            {
                request.ContextKeySelectors = cmdletContext.ContextKeySelector;
            }
            if (cmdletContext.EventDataStore != null)
            {
                request.EventDataStore = cmdletContext.EventDataStore;
            }
            if (cmdletContext.MaxEventSize != null)
            {
                request.MaxEventSize = cmdletContext.MaxEventSize;
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
        
        private Amazon.CloudTrail.Model.PutEventConfigurationResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.PutEventConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "PutEventConfiguration");
            try
            {
                return client.PutEventConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CloudTrail.Model.ContextKeySelector> ContextKeySelector { get; set; }
            public System.String EventDataStore { get; set; }
            public Amazon.CloudTrail.MaxEventSize MaxEventSize { get; set; }
            public System.Func<Amazon.CloudTrail.Model.PutEventConfigurationResponse, WriteCTEventConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
