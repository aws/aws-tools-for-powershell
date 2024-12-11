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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// <note><para>
    /// This operation applies only to Amazon Rekognition Custom Labels.
    /// </para></note><para>
    /// Adds or updates one or more entries (images) in a dataset. An entry is a JSON Line
    /// which contains the information for a single image, including the image location, assigned
    /// labels, and object location bounding boxes. For more information, see Image-Level
    /// labels in manifest files and Object localization in manifest files in the <i>Amazon
    /// Rekognition Custom Labels Developer Guide</i>. 
    /// </para><para>
    /// If the <c>source-ref</c> field in the JSON line references an existing image, the
    /// existing image in the dataset is updated. If <c>source-ref</c> field doesn't reference
    /// an existing image, the image is added as a new image to the dataset. 
    /// </para><para>
    /// You specify the changes that you want to make in the <c>Changes</c> input parameter.
    /// There isn't a limit to the number JSON Lines that you can change, but the size of
    /// <c>Changes</c> must be less than 5MB.
    /// </para><para><c>UpdateDatasetEntries</c> returns immediatly, but the dataset update might take
    /// a while to complete. Use <a>DescribeDataset</a> to check the current status. The dataset
    /// updated successfully if the value of <c>Status</c> is <c>UPDATE_COMPLETE</c>. 
    /// </para><para>
    /// To check if any non-terminal errors occured, call <a>ListDatasetEntries</a> and check
    /// for the presence of <c>errors</c> lists in the JSON Lines.
    /// </para><para>
    /// Dataset update fails if a terminal error occurs (<c>Status</c> = <c>UPDATE_FAILED</c>).
    /// Currently, you can't access the terminal error information from the Amazon Rekognition
    /// Custom Labels SDK. 
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:UpdateDatasetEntries</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "REKDatasetEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Rekognition UpdateDatasetEntries API operation.", Operation = new[] {"UpdateDatasetEntries"}, SelectReturnType = typeof(Amazon.Rekognition.Model.UpdateDatasetEntriesResponse))]
    [AWSCmdletOutput("None or Amazon.Rekognition.Model.UpdateDatasetEntriesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Rekognition.Model.UpdateDatasetEntriesResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateREKDatasetEntryCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatasetArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the dataset that you want to update. </para>
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
        public System.String DatasetArn { get; set; }
        #endregion
        
        #region Parameter Changes_GroundTruth
        /// <summary>
        /// <para>
        /// <para>A Base64-encoded binary data object containing one or JSON lines that either update
        /// the dataset or are additions to the dataset. You change a dataset by calling <a>UpdateDatasetEntries</a>.
        /// If you are using an AWS SDK to call <c>UpdateDatasetEntries</c>, you don't need to
        /// encode <c>Changes</c> as the SDK encodes the data for you. </para><para>For example JSON lines, see Image-Level labels in manifest files and and Object localization
        /// in manifest files in the <i>Amazon Rekognition Custom Labels Developer Guide</i>.
        /// </para>
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
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Changes_GroundTruth { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.UpdateDatasetEntriesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-REKDatasetEntry (UpdateDatasetEntries)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.UpdateDatasetEntriesResponse, UpdateREKDatasetEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Changes_GroundTruth = this.Changes_GroundTruth;
            #if MODULAR
            if (this.Changes_GroundTruth == null && ParameterWasBound(nameof(this.Changes_GroundTruth)))
            {
                WriteWarning("You are passing $null as a value for parameter Changes_GroundTruth which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetArn = this.DatasetArn;
            #if MODULAR
            if (this.DatasetArn == null && ParameterWasBound(nameof(this.DatasetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _Changes_GroundTruthStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Rekognition.Model.UpdateDatasetEntriesRequest();
                
                
                 // populate Changes
                var requestChangesIsNull = true;
                request.Changes = new Amazon.Rekognition.Model.DatasetChanges();
                System.IO.MemoryStream requestChanges_changes_GroundTruth = null;
                if (cmdletContext.Changes_GroundTruth != null)
                {
                    _Changes_GroundTruthStream = new System.IO.MemoryStream(cmdletContext.Changes_GroundTruth);
                    requestChanges_changes_GroundTruth = _Changes_GroundTruthStream;
                }
                if (requestChanges_changes_GroundTruth != null)
                {
                    request.Changes.GroundTruth = requestChanges_changes_GroundTruth;
                    requestChangesIsNull = false;
                }
                 // determine if request.Changes should be set to null
                if (requestChangesIsNull)
                {
                    request.Changes = null;
                }
                if (cmdletContext.DatasetArn != null)
                {
                    request.DatasetArn = cmdletContext.DatasetArn;
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
                if( _Changes_GroundTruthStream != null)
                {
                    _Changes_GroundTruthStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Rekognition.Model.UpdateDatasetEntriesResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.UpdateDatasetEntriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "UpdateDatasetEntries");
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
            public byte[] Changes_GroundTruth { get; set; }
            public System.String DatasetArn { get; set; }
            public System.Func<Amazon.Rekognition.Model.UpdateDatasetEntriesResponse, UpdateREKDatasetEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
