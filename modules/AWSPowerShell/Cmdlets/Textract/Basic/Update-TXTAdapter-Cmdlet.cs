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
using Amazon.Textract;
using Amazon.Textract.Model;

namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Update the configuration for an adapter. FeatureTypes configurations cannot be updated.
    /// At least one new parameter must be specified as an argument.
    /// </summary>
    [Cmdlet("Update", "TXTAdapter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Textract.Model.UpdateAdapterResponse")]
    [AWSCmdlet("Calls the Amazon Textract UpdateAdapter API operation.", Operation = new[] {"UpdateAdapter"}, SelectReturnType = typeof(Amazon.Textract.Model.UpdateAdapterResponse))]
    [AWSCmdletOutput("Amazon.Textract.Model.UpdateAdapterResponse",
        "This cmdlet returns an Amazon.Textract.Model.UpdateAdapterResponse object containing multiple properties."
    )]
    public partial class UpdateTXTAdapterCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdapterId
        /// <summary>
        /// <para>
        /// <para>A string containing a unique ID for the adapter that will be updated.</para>
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
        public System.String AdapterId { get; set; }
        #endregion
        
        #region Parameter AdapterName
        /// <summary>
        /// <para>
        /// <para>The new name to be applied to the adapter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdapterName { get; set; }
        #endregion
        
        #region Parameter AutoUpdate
        /// <summary>
        /// <para>
        /// <para>The new auto-update status to be applied to the adapter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Textract.AutoUpdate")]
        public Amazon.Textract.AutoUpdate AutoUpdate { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description to be applied to the adapter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.UpdateAdapterResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.UpdateAdapterResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AdapterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TXTAdapter (UpdateAdapter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.UpdateAdapterResponse, UpdateTXTAdapterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdapterId = this.AdapterId;
            #if MODULAR
            if (this.AdapterId == null && ParameterWasBound(nameof(this.AdapterId)))
            {
                WriteWarning("You are passing $null as a value for parameter AdapterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AdapterName = this.AdapterName;
            context.AutoUpdate = this.AutoUpdate;
            context.Description = this.Description;
            
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
            var request = new Amazon.Textract.Model.UpdateAdapterRequest();
            
            if (cmdletContext.AdapterId != null)
            {
                request.AdapterId = cmdletContext.AdapterId;
            }
            if (cmdletContext.AdapterName != null)
            {
                request.AdapterName = cmdletContext.AdapterName;
            }
            if (cmdletContext.AutoUpdate != null)
            {
                request.AutoUpdate = cmdletContext.AutoUpdate;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
        
        private Amazon.Textract.Model.UpdateAdapterResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.UpdateAdapterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "UpdateAdapter");
            try
            {
                return client.UpdateAdapterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AdapterId { get; set; }
            public System.String AdapterName { get; set; }
            public Amazon.Textract.AutoUpdate AutoUpdate { get; set; }
            public System.String Description { get; set; }
            public System.Func<Amazon.Textract.Model.UpdateAdapterResponse, UpdateTXTAdapterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
