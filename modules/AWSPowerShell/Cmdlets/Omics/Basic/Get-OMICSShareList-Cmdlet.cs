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
    /// Retrieves the resource shares associated with an account. Use the filter parameter
    /// to retrieve a specific subset of the shares.
    /// </summary>
    [Cmdlet("Get", "OMICSShareList")]
    [OutputType("Amazon.Omics.Model.ShareDetails")]
    [AWSCmdlet("Calls the Amazon Omics ListShares API operation.", Operation = new[] {"ListShares"}, SelectReturnType = typeof(Amazon.Omics.Model.ListSharesResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.ShareDetails or Amazon.Omics.Model.ListSharesResponse",
        "This cmdlet returns a collection of Amazon.Omics.Model.ShareDetails objects.",
        "The service call response (type Amazon.Omics.Model.ListSharesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOMICSShareListCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_ResourceArn
        /// <summary>
        /// <para>
        /// <para>Filter based on the Amazon Resource Number (ARN) of the resource. You can specify
        /// up to 10 values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ResourceArns")]
        public System.String[] Filter_ResourceArn { get; set; }
        #endregion
        
        #region Parameter ResourceOwner
        /// <summary>
        /// <para>
        /// <para>The account that owns the resource shares.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Omics.ResourceOwner")]
        public Amazon.Omics.ResourceOwner ResourceOwner { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>Filter based on the resource status. You can specify up to 10 values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filter_Status { get; set; }
        #endregion
        
        #region Parameter Filter_Type
        /// <summary>
        /// <para>
        /// <para>The type of resources to be filtered. You can specify one or more of the resource
        /// types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filter_Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of shares to return in one page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Shares'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.ListSharesResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.ListSharesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Shares";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceOwner parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceOwner' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceOwner' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.ListSharesResponse, GetOMICSShareListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceOwner;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter_ResourceArn != null)
            {
                context.Filter_ResourceArn = new List<System.String>(this.Filter_ResourceArn);
            }
            if (this.Filter_Status != null)
            {
                context.Filter_Status = new List<System.String>(this.Filter_Status);
            }
            if (this.Filter_Type != null)
            {
                context.Filter_Type = new List<System.String>(this.Filter_Type);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceOwner = this.ResourceOwner;
            #if MODULAR
            if (this.ResourceOwner == null && ParameterWasBound(nameof(this.ResourceOwner)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceOwner which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Omics.Model.ListSharesRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Omics.Model.Filter();
            List<System.String> requestFilter_filter_ResourceArn = null;
            if (cmdletContext.Filter_ResourceArn != null)
            {
                requestFilter_filter_ResourceArn = cmdletContext.Filter_ResourceArn;
            }
            if (requestFilter_filter_ResourceArn != null)
            {
                request.Filter.ResourceArns = requestFilter_filter_ResourceArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Type = null;
            if (cmdletContext.Filter_Type != null)
            {
                requestFilter_filter_Type = cmdletContext.Filter_Type;
            }
            if (requestFilter_filter_Type != null)
            {
                request.Filter.Type = requestFilter_filter_Type;
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
            if (cmdletContext.ResourceOwner != null)
            {
                request.ResourceOwner = cmdletContext.ResourceOwner;
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
        
        private Amazon.Omics.Model.ListSharesResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.ListSharesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "ListShares");
            try
            {
                #if DESKTOP
                return client.ListShares(request);
                #elif CORECLR
                return client.ListSharesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filter_ResourceArn { get; set; }
            public List<System.String> Filter_Status { get; set; }
            public List<System.String> Filter_Type { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Omics.ResourceOwner ResourceOwner { get; set; }
            public System.Func<Amazon.Omics.Model.ListSharesResponse, GetOMICSShareListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Shares;
        }
        
    }
}
