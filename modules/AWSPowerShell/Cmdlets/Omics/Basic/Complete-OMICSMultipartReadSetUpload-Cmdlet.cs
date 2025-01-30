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
    /// Concludes a multipart upload once you have uploaded all the components.
    /// </summary>
    [Cmdlet("Complete", "OMICSMultipartReadSetUpload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Omics CompleteMultipartReadSetUpload API operation.", Operation = new[] {"CompleteMultipartReadSetUpload"}, SelectReturnType = typeof(Amazon.Omics.Model.CompleteMultipartReadSetUploadResponse))]
    [AWSCmdletOutput("System.String or Amazon.Omics.Model.CompleteMultipartReadSetUploadResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Omics.Model.CompleteMultipartReadSetUploadResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CompleteOMICSMultipartReadSetUploadCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Part
        /// <summary>
        /// <para>
        /// <para>The individual uploads or parts of a multipart upload.</para>
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
        [Alias("Parts")]
        public Amazon.Omics.Model.CompleteReadSetUploadPartListItem[] Part { get; set; }
        #endregion
        
        #region Parameter SequenceStoreId
        /// <summary>
        /// <para>
        /// <para>The sequence store ID for the store involved in the multipart upload.</para>
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
        /// <para>The ID for the multipart upload.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReadSetId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CompleteMultipartReadSetUploadResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CompleteMultipartReadSetUploadResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReadSetId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UploadId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UploadId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UploadId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-OMICSMultipartReadSetUpload (CompleteMultipartReadSetUpload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CompleteMultipartReadSetUploadResponse, CompleteOMICSMultipartReadSetUploadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UploadId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Part != null)
            {
                context.Part = new List<Amazon.Omics.Model.CompleteReadSetUploadPartListItem>(this.Part);
            }
            #if MODULAR
            if (this.Part == null && ParameterWasBound(nameof(this.Part)))
            {
                WriteWarning("You are passing $null as a value for parameter Part which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Omics.Model.CompleteMultipartReadSetUploadRequest();
            
            if (cmdletContext.Part != null)
            {
                request.Parts = cmdletContext.Part;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Omics.Model.CompleteMultipartReadSetUploadResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CompleteMultipartReadSetUploadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CompleteMultipartReadSetUpload");
            try
            {
                #if DESKTOP
                return client.CompleteMultipartReadSetUpload(request);
                #elif CORECLR
                return client.CompleteMultipartReadSetUploadAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Omics.Model.CompleteReadSetUploadPartListItem> Part { get; set; }
            public System.String SequenceStoreId { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.Omics.Model.CompleteMultipartReadSetUploadResponse, CompleteOMICSMultipartReadSetUploadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReadSetId;
        }
        
    }
}
