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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Adds one or more JSON Line entries to a dataset. A JSON Line includes information
    /// about an image used for training or testing an Amazon Lookout for Vision model. The
    /// following is an example JSON Line.
    /// 
    ///  
    /// <para>
    /// Updating a dataset might take a while to complete. To check the current status, call
    /// <a>DescribeDataset</a> and check the <code>Status</code> field in the response.
    /// </para><para>
    /// This operation requires permissions to perform the <code>lookoutvision:UpdateDatasetEntries</code>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LFVDatasetEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutforVision.DatasetStatus")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision UpdateDatasetEntries API operation.", Operation = new[] {"UpdateDatasetEntries"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.UpdateDatasetEntriesResponse))]
    [AWSCmdletOutput("Amazon.LookoutforVision.DatasetStatus or Amazon.LookoutforVision.Model.UpdateDatasetEntriesResponse",
        "This cmdlet returns an Amazon.LookoutforVision.DatasetStatus object.",
        "The service call response (type Amazon.LookoutforVision.Model.UpdateDatasetEntriesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLFVDatasetEntryCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        #region Parameter Change
        /// <summary>
        /// <para>
        /// <para>The entries to add to the dataset.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Changes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Change { get; set; }
        #endregion
        
        #region Parameter DatasetType
        /// <summary>
        /// <para>
        /// <para>The type of the dataset that you want to update. Specify <code>train</code> to update
        /// the training dataset. Specify <code>test</code> to update the test dataset. If you
        /// have a single dataset project, specify <code>train</code>.</para>
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
        public System.String DatasetType { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project that contains the dataset that you want to update.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>ClientToken is an idempotency token that ensures a call to <code>UpdateDatasetEntries</code>
        /// completes only once. You choose the value to pass. For example, An issue, such as
        /// an network outage, might prevent you from getting a response from <code>UpdateDatasetEntries</code>.
        /// In this case, safely retry your call to <code>UpdateDatasetEntries</code> by using
        /// the same <code>ClientToken</code> parameter value. An error occurs if the other input
        /// parameters are not the same as in the first request. Using a different value for <code>ClientToken</code>
        /// is considered a new call to <code>UpdateDatasetEntries</code>. An idempotency token
        /// is active for 8 hours. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.UpdateDatasetEntriesResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.UpdateDatasetEntriesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LFVDatasetEntry (UpdateDatasetEntries)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.UpdateDatasetEntriesResponse, UpdateLFVDatasetEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Change = this.Change;
            #if MODULAR
            if (this.Change == null && ParameterWasBound(nameof(this.Change)))
            {
                WriteWarning("You are passing $null as a value for parameter Change which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DatasetType = this.DatasetType;
            #if MODULAR
            if (this.DatasetType == null && ParameterWasBound(nameof(this.DatasetType)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _ChangeStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.LookoutforVision.Model.UpdateDatasetEntriesRequest();
                
                if (cmdletContext.Change != null)
                {
                    _ChangeStream = new System.IO.MemoryStream(cmdletContext.Change);
                    request.Changes = _ChangeStream;
                }
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                if (cmdletContext.DatasetType != null)
                {
                    request.DatasetType = cmdletContext.DatasetType;
                }
                if (cmdletContext.ProjectName != null)
                {
                    request.ProjectName = cmdletContext.ProjectName;
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
            finally
            {
                if( _ChangeStream != null)
                {
                    _ChangeStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LookoutforVision.Model.UpdateDatasetEntriesResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.UpdateDatasetEntriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "UpdateDatasetEntries");
            try
            {
                #if DESKTOP
                return client.UpdateDatasetEntries(request);
                #elif CORECLR
                return client.UpdateDatasetEntriesAsync(request).GetAwaiter().GetResult();
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
            public byte[] Change { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DatasetType { get; set; }
            public System.String ProjectName { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.UpdateDatasetEntriesResponse, UpdateLFVDatasetEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
