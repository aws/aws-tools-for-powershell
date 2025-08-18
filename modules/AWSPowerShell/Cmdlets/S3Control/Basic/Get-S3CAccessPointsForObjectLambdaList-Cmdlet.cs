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
    /// <note><para>
    /// This operation is not supported by directory buckets.
    /// </para></note><para>
    /// Returns some or all (up to 1,000) access points associated with the Object Lambda
    /// Access Point per call. If there are more access points than what can be returned in
    /// one call, the response will include a continuation token that you can use to list
    /// the additional access points.
    /// </para><para>
    /// The following actions are related to <c>ListAccessPointsForObjectLambda</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_CreateAccessPointForObjectLambda.html">CreateAccessPointForObjectLambda</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DeleteAccessPointForObjectLambda.html">DeleteAccessPointForObjectLambda</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetAccessPointForObjectLambda.html">GetAccessPointForObjectLambda</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "S3CAccessPointsForObjectLambdaList")]
    [OutputType("Amazon.S3Control.Model.ObjectLambdaAccessPoint")]
    [AWSCmdlet("Calls the Amazon S3 Control ListAccessPointsForObjectLambda API operation.", Operation = new[] {"ListAccessPointsForObjectLambda"}, SelectReturnType = typeof(Amazon.S3Control.Model.ListAccessPointsForObjectLambdaResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.ObjectLambdaAccessPoint or Amazon.S3Control.Model.ListAccessPointsForObjectLambdaResponse",
        "This cmdlet returns a collection of Amazon.S3Control.Model.ObjectLambdaAccessPoint objects.",
        "The service call response (type Amazon.S3Control.Model.ListAccessPointsForObjectLambdaResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3CAccessPointsForObjectLambdaListCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID for the account that owns the specified Object Lambda Access Point.</para>
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of access points that you want to include in the list. The response
        /// may contain fewer access points but will never contain more. If there are more than
        /// this number of access points, then the response will include a continuation token
        /// in the <c>NextToken</c> field that you can use to retrieve the next page of access
        /// points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the list has more access points than can be returned in one call to this API, this
        /// field contains a continuation token that you can provide in subsequent calls to this
        /// API to retrieve additional access points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ObjectLambdaAccessPointList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.ListAccessPointsForObjectLambdaResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.ListAccessPointsForObjectLambdaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ObjectLambdaAccessPointList";
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
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.ListAccessPointsForObjectLambdaResponse, GetS3CAccessPointsForObjectLambdaListCmdlet>(Select) ??
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
            var request = new Amazon.S3Control.Model.ListAccessPointsForObjectLambdaRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
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
        
        private Amazon.S3Control.Model.ListAccessPointsForObjectLambdaResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.ListAccessPointsForObjectLambdaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "ListAccessPointsForObjectLambda");
            try
            {
                #if DESKTOP
                return client.ListAccessPointsForObjectLambda(request);
                #elif CORECLR
                return client.ListAccessPointsForObjectLambdaAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.S3Control.Model.ListAccessPointsForObjectLambdaResponse, GetS3CAccessPointsForObjectLambdaListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ObjectLambdaAccessPointList;
        }
        
    }
}
