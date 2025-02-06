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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// This operation uploads a specific part of a read set. If you upload a new part using
    /// a previously used part number, the previously uploaded part will be overwritten.
    /// </summary>
    [Cmdlet("Set", "OMICSReadSetPart", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Omics UploadReadSetPart API operation.", Operation = new[] {"UploadReadSetPart"}, SelectReturnType = typeof(Amazon.Omics.Model.UploadReadSetPartResponse))]
    [AWSCmdletOutput("System.String or Amazon.Omics.Model.UploadReadSetPartResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Omics.Model.UploadReadSetPartResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetOMICSReadSetPartCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PartNumber
        /// <summary>
        /// <para>
        /// <para>The number of the part being uploaded.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? PartNumber { get; set; }
        #endregion
        
        #region Parameter PartSource
        /// <summary>
        /// <para>
        /// <para>The source file for an upload part.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Omics.ReadSetPartSource")]
        public Amazon.Omics.ReadSetPartSource PartSource { get; set; }
        #endregion
        
        #region Parameter Payload
        /// <summary>
        /// <para>
        /// <para>The read set data to upload for a part.</para>
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public object Payload { get; set; }
        #endregion
        
        #region Parameter SequenceStoreId
        /// <summary>
        /// <para>
        /// <para>The Sequence Store ID used for the multipart upload.</para>
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
        public System.String SequenceStoreId { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// <para>The ID for the initiated multipart upload.</para>
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
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Checksum'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.UploadReadSetPartResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.UploadReadSetPartResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Checksum";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UploadId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-OMICSReadSetPart (UploadReadSetPart)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.UploadReadSetPartResponse, SetOMICSReadSetPartCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PartNumber = this.PartNumber;
            #if MODULAR
            if (this.PartNumber == null && ParameterWasBound(nameof(this.PartNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter PartNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartSource = this.PartSource;
            #if MODULAR
            if (this.PartSource == null && ParameterWasBound(nameof(this.PartSource)))
            {
                WriteWarning("You are passing $null as a value for parameter PartSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Payload = this.Payload;
            #if MODULAR
            if (this.Payload == null && ParameterWasBound(nameof(this.Payload)))
            {
                WriteWarning("You are passing $null as a value for parameter Payload which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SequenceStoreId = this.SequenceStoreId;
            #if MODULAR
            if (this.SequenceStoreId == null && ParameterWasBound(nameof(this.SequenceStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter SequenceStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UploadId = this.UploadId;
            #if MODULAR
            if (this.UploadId == null && ParameterWasBound(nameof(this.UploadId)))
            {
                WriteWarning("You are passing $null as a value for parameter UploadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.Stream _PayloadStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Omics.Model.UploadReadSetPartRequest();
                
                if (cmdletContext.PartNumber != null)
                {
                    request.PartNumber = cmdletContext.PartNumber.Value;
                }
                if (cmdletContext.PartSource != null)
                {
                    request.PartSource = cmdletContext.PartSource;
                }
                if (cmdletContext.Payload != null)
                {
                    _PayloadStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.Payload);
                    request.Payload = _PayloadStream;
                }
                if (cmdletContext.SequenceStoreId != null)
                {
                    request.SequenceStoreId = cmdletContext.SequenceStoreId;
                }
                if (cmdletContext.UploadId != null)
                {
                    request.UploadId = cmdletContext.UploadId;
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
                if( _PayloadStream != null)
                {
                    _PayloadStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Omics.Model.UploadReadSetPartResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.UploadReadSetPartRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "UploadReadSetPart");
            try
            {
                #if DESKTOP
                return client.UploadReadSetPart(request);
                #elif CORECLR
                return client.UploadReadSetPartAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? PartNumber { get; set; }
            public Amazon.Omics.ReadSetPartSource PartSource { get; set; }
            public object Payload { get; set; }
            public System.String SequenceStoreId { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.Omics.Model.UploadReadSetPartResponse, SetOMICSReadSetPartCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Checksum;
        }
        
    }
}
