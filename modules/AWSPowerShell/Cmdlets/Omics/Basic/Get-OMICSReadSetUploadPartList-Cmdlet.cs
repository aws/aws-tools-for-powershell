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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// This operation will list all parts in a requested multipart upload for a sequence
    /// store.
    /// </summary>
    [Cmdlet("Get", "OMICSReadSetUploadPartList")]
    [OutputType("Amazon.Omics.Model.ReadSetUploadPartListItem")]
    [AWSCmdlet("Calls the Amazon Omics ListReadSetUploadParts API operation.", Operation = new[] {"ListReadSetUploadParts"}, SelectReturnType = typeof(Amazon.Omics.Model.ListReadSetUploadPartsResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.ReadSetUploadPartListItem or Amazon.Omics.Model.ListReadSetUploadPartsResponse",
        "This cmdlet returns a collection of Amazon.Omics.Model.ReadSetUploadPartListItem objects.",
        "The service call response (type Amazon.Omics.Model.ListReadSetUploadPartsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetOMICSReadSetUploadPartListCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_CreatedAfter
        /// <summary>
        /// <para>
        /// <para> Filters for read set uploads after a specified time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedBefore
        /// <summary>
        /// <para>
        /// <para> Filters for read set part uploads before a specified time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter PartSource
        /// <summary>
        /// <para>
        /// <para>The source file for the upload part.</para>
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
        
        #region Parameter SequenceStoreId
        /// <summary>
        /// <para>
        /// <para>The Sequence Store ID used for the multipart uploads.</para>
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of read set upload parts returned in a page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Next token returned in the response of a previous ListReadSetUploadPartsRequest call.
        /// Used to get the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Parts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.ListReadSetUploadPartsResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.ListReadSetUploadPartsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Parts";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.ListReadSetUploadPartsResponse, GetOMICSReadSetUploadPartListCmdlet>(Select) ??
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
            context.Filter_CreatedAfter = this.Filter_CreatedAfter;
            context.Filter_CreatedBefore = this.Filter_CreatedBefore;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PartSource = this.PartSource;
            #if MODULAR
            if (this.PartSource == null && ParameterWasBound(nameof(this.PartSource)))
            {
                WriteWarning("You are passing $null as a value for parameter PartSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Omics.Model.ListReadSetUploadPartsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Omics.Model.ReadSetUploadPartListFilter();
            System.DateTime? requestFilter_filter_CreatedAfter = null;
            if (cmdletContext.Filter_CreatedAfter != null)
            {
                requestFilter_filter_CreatedAfter = cmdletContext.Filter_CreatedAfter.Value;
            }
            if (requestFilter_filter_CreatedAfter != null)
            {
                request.Filter.CreatedAfter = requestFilter_filter_CreatedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreatedBefore = null;
            if (cmdletContext.Filter_CreatedBefore != null)
            {
                requestFilter_filter_CreatedBefore = cmdletContext.Filter_CreatedBefore.Value;
            }
            if (requestFilter_filter_CreatedBefore != null)
            {
                request.Filter.CreatedBefore = requestFilter_filter_CreatedBefore.Value;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PartSource != null)
            {
                request.PartSource = cmdletContext.PartSource;
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
        
        private Amazon.Omics.Model.ListReadSetUploadPartsResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.ListReadSetUploadPartsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "ListReadSetUploadParts");
            try
            {
                #if DESKTOP
                return client.ListReadSetUploadParts(request);
                #elif CORECLR
                return client.ListReadSetUploadPartsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? Filter_CreatedAfter { get; set; }
            public System.DateTime? Filter_CreatedBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Omics.ReadSetPartSource PartSource { get; set; }
            public System.String SequenceStoreId { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.Omics.Model.ListReadSetUploadPartsResponse, GetOMICSReadSetUploadPartListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Parts;
        }
        
    }
}
