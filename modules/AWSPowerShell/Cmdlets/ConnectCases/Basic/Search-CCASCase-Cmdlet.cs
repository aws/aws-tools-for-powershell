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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Searches for cases within their associated Cases domain. Search results are returned
    /// as a paginated list of abridged case documents.
    /// 
    ///  <note><para>
    /// For <c>customer_id</c> you must provide the full customer profile ARN in this format:
    /// <c> arn:aws:profile:your AWS Region:your AWS account ID:domains/profiles domain name/profiles/profile
    /// ID</c>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Search", "CCASCase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCases.Model.SearchCasesResponseItem")]
    [AWSCmdlet("Calls the Amazon Connect Cases SearchCases API operation.", Operation = new[] {"SearchCases"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.SearchCasesResponse))]
    [AWSCmdletOutput("Amazon.ConnectCases.Model.SearchCasesResponseItem or Amazon.ConnectCases.Model.SearchCasesResponse",
        "This cmdlet returns a collection of Amazon.ConnectCases.Model.SearchCasesResponseItem objects.",
        "The service call response (type Amazon.ConnectCases.Model.SearchCasesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchCCASCaseCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Cases domain. </para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter Field
        /// <summary>
        /// <para>
        /// <para>The list of field identifiers to be returned as part of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Fields")]
        public Amazon.ConnectCases.Model.FieldIdentifier[] Field { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A list of filter objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ConnectCases.Model.CaseFilter Filter { get; set; }
        #endregion
        
        #region Parameter SearchTerm
        /// <summary>
        /// <para>
        /// <para>A word or phrase used to perform a quick search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchTerm { get; set; }
        #endregion
        
        #region Parameter Sort
        /// <summary>
        /// <para>
        /// <para>A list of sorts where each sort specifies a field and their sort order to be applied
        /// to the results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sorts")]
        public Amazon.ConnectCases.Model.Sort[] Sort { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of cases to return. When no value is provided, 25 is the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cases'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.SearchCasesResponse).
        /// Specifying the name of a property of type Amazon.ConnectCases.Model.SearchCasesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cases";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-CCASCase (SearchCases)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.SearchCasesResponse, SearchCCASCaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Field != null)
            {
                context.Field = new List<Amazon.ConnectCases.Model.FieldIdentifier>(this.Field);
            }
            context.Filter = this.Filter;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SearchTerm = this.SearchTerm;
            if (this.Sort != null)
            {
                context.Sort = new List<Amazon.ConnectCases.Model.Sort>(this.Sort);
            }
            
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
            var request = new Amazon.ConnectCases.Model.SearchCasesRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.Field != null)
            {
                request.Fields = cmdletContext.Field;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SearchTerm != null)
            {
                request.SearchTerm = cmdletContext.SearchTerm;
            }
            if (cmdletContext.Sort != null)
            {
                request.Sorts = cmdletContext.Sort;
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
        
        private Amazon.ConnectCases.Model.SearchCasesResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.SearchCasesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "SearchCases");
            try
            {
                #if DESKTOP
                return client.SearchCases(request);
                #elif CORECLR
                return client.SearchCasesAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public List<Amazon.ConnectCases.Model.FieldIdentifier> Field { get; set; }
            public Amazon.ConnectCases.Model.CaseFilter Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SearchTerm { get; set; }
            public List<Amazon.ConnectCases.Model.Sort> Sort { get; set; }
            public System.Func<Amazon.ConnectCases.Model.SearchCasesResponse, SearchCCASCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cases;
        }
        
    }
}
