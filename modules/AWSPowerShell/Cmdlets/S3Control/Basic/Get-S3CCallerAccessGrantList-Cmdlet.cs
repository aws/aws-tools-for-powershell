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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// Use this API to list the access grants that grant the caller access to Amazon S3 data
    /// through S3 Access Grants. The caller (grantee) can be an Identity and Access Management
    /// (IAM) identity or Amazon Web Services Identity Center corporate directory identity.
    /// You must pass the Amazon Web Services account of the S3 data owner (grantor) in the
    /// request. You can, optionally, narrow the results by <c>GrantScope</c>, using a fragment
    /// of the data's S3 path, and S3 Access Grants will return only the grants with a path
    /// that contains the path fragment. You can also pass the <c>AllowedByApplication</c>
    /// filter in the request, which returns only the grants authorized for applications,
    /// whether the application is the caller's Identity Center application or any other application
    /// (<c>ALL</c>). For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-grants-list-grants.html">List
    /// the caller's access grants</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3:ListCallerAccessGrants</c> permission to use this operation.
    /// 
    /// </para></dd></dl><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "S3CCallerAccessGrantList")]
    [OutputType("Amazon.S3Control.Model.ListCallerAccessGrantsEntry")]
    [AWSCmdlet("Calls the Amazon S3 Control ListCallerAccessGrants API operation.", Operation = new[] {"ListCallerAccessGrants"}, SelectReturnType = typeof(Amazon.S3Control.Model.ListCallerAccessGrantsResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.ListCallerAccessGrantsEntry or Amazon.S3Control.Model.ListCallerAccessGrantsResponse",
        "This cmdlet returns a collection of Amazon.S3Control.Model.ListCallerAccessGrantsEntry objects.",
        "The service call response (type Amazon.S3Control.Model.ListCallerAccessGrantsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3CCallerAccessGrantListCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the S3 Access Grants instance.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AllowedByApplication
        /// <summary>
        /// <para>
        /// <para>If this optional parameter is passed in the request, a filter is applied to the results.
        /// The results will include only the access grants for the caller's Identity Center application
        /// or for any other applications (<c>ALL</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowedByApplication { get; set; }
        #endregion
        
        #region Parameter GrantScope
        /// <summary>
        /// <para>
        /// <para>The S3 path of the data that you would like to access. Must start with <c>s3://</c>.
        /// You can optionally pass only the beginning characters of a path, and S3 Access Grants
        /// will search for all applicable grants for the path fragment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantScope { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of access grants that you would like returned in the <c>List Caller
        /// Access Grants</c> response. If the results include the pagination token <c>NextToken</c>,
        /// make another call using the <c>NextToken</c> to determine if there are more results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token to request the next page of results. Pass this value into a subsequent
        /// <c>List Caller Access Grants</c> request in order to retrieve the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CallerAccessGrantsList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.ListCallerAccessGrantsResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.ListCallerAccessGrantsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CallerAccessGrantsList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.ListCallerAccessGrantsResponse, GetS3CCallerAccessGrantListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AllowedByApplication = this.AllowedByApplication;
            context.GrantScope = this.GrantScope;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.S3Control.Model.ListCallerAccessGrantsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.AllowedByApplication != null)
            {
                request.AllowedByApplication = cmdletContext.AllowedByApplication.Value;
            }
            if (cmdletContext.GrantScope != null)
            {
                request.GrantScope = cmdletContext.GrantScope;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.S3Control.Model.ListCallerAccessGrantsResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.ListCallerAccessGrantsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "ListCallerAccessGrants");
            try
            {
                #if DESKTOP
                return client.ListCallerAccessGrants(request);
                #elif CORECLR
                return client.ListCallerAccessGrantsAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.Boolean? AllowedByApplication { get; set; }
            public System.String GrantScope { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.S3Control.Model.ListCallerAccessGrantsResponse, GetS3CCallerAccessGrantListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CallerAccessGrantsList;
        }
        
    }
}
