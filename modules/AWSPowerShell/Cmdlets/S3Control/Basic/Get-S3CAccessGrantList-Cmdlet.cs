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
    /// Returns the list of access grants in your S3 Access Grants instance.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3:ListAccessGrants</c> permission to use this operation. 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Get", "S3CAccessGrantList")]
    [OutputType("Amazon.S3Control.Model.ListAccessGrantEntry")]
    [AWSCmdlet("Calls the Amazon S3 Control ListAccessGrants API operation.", Operation = new[] {"ListAccessGrants"}, SelectReturnType = typeof(Amazon.S3Control.Model.ListAccessGrantsResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.ListAccessGrantEntry or Amazon.S3Control.Model.ListAccessGrantsResponse",
        "This cmdlet returns a collection of Amazon.S3Control.Model.ListAccessGrantEntry objects.",
        "The service call response (type Amazon.S3Control.Model.ListAccessGrantsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3CAccessGrantListCmdlet : AmazonS3ControlClientCmdlet, IExecutor
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
        
        #region Parameter ApplicationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Web Services IAM Identity Center application
        /// associated with your Identity Center instance. If the grant includes an application
        /// ARN, the grantee can only access the S3 data through this application. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationArn { get; set; }
        #endregion
        
        #region Parameter GranteeIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifer of the <c>Grantee</c>. If the grantee type is <c>IAM</c>, the
        /// identifier is the IAM Amazon Resource Name (ARN) of the user or role. If the grantee
        /// type is a directory user or group, the identifier is 128-bit universally unique identifier
        /// (UUID) in the format <c>a1b2c3d4-5678-90ab-cdef-EXAMPLE11111</c>. You can obtain this
        /// UUID from your Amazon Web Services IAM Identity Center instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GranteeIdentifier { get; set; }
        #endregion
        
        #region Parameter GranteeType
        /// <summary>
        /// <para>
        /// <para>The type of the grantee to which access has been granted. It can be one of the following
        /// values:</para><ul><li><para><c>IAM</c> - An IAM user or role.</para></li><li><para><c>DIRECTORY_USER</c> - Your corporate directory user. You can use this option if
        /// you have added your corporate identity directory to IAM Identity Center and associated
        /// the IAM Identity Center instance with your S3 Access Grants instance.</para></li><li><para><c>DIRECTORY_GROUP</c> - Your corporate directory group. You can use this option
        /// if you have added your corporate identity directory to IAM Identity Center and associated
        /// the IAM Identity Center instance with your S3 Access Grants instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.GranteeType")]
        public Amazon.S3Control.GranteeType GranteeType { get; set; }
        #endregion
        
        #region Parameter GrantScope
        /// <summary>
        /// <para>
        /// <para>The S3 path of the data to which you are granting access. It is the result of appending
        /// the <c>Subprefix</c> to the location scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantScope { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>The type of permission granted to your S3 data, which can be set to one of the following
        /// values:</para><ul><li><para><c>READ</c> – Grant read-only access to the S3 data.</para></li><li><para><c>WRITE</c> – Grant write-only access to the S3 data.</para></li><li><para><c>READWRITE</c> – Grant both read and write access to the S3 data.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.Permission")]
        public Amazon.S3Control.Permission Permission { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of access grants that you would like returned in the <c>List Access
        /// Grants</c> response. If the results include the pagination token <c>NextToken</c>,
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
        /// <c>List Access Grants</c> request in order to retrieve the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessGrantsList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.ListAccessGrantsResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.ListAccessGrantsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessGrantsList";
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
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.ListAccessGrantsResponse, GetS3CAccessGrantListCmdlet>(Select) ??
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
            context.ApplicationArn = this.ApplicationArn;
            context.GranteeIdentifier = this.GranteeIdentifier;
            context.GranteeType = this.GranteeType;
            context.GrantScope = this.GrantScope;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Permission = this.Permission;
            
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
            var request = new Amazon.S3Control.Model.ListAccessGrantsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.ApplicationArn != null)
            {
                request.ApplicationArn = cmdletContext.ApplicationArn;
            }
            if (cmdletContext.GranteeIdentifier != null)
            {
                request.GranteeIdentifier = cmdletContext.GranteeIdentifier;
            }
            if (cmdletContext.GranteeType != null)
            {
                request.GranteeType = cmdletContext.GranteeType;
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
            if (cmdletContext.Permission != null)
            {
                request.Permission = cmdletContext.Permission;
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
        
        private Amazon.S3Control.Model.ListAccessGrantsResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.ListAccessGrantsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "ListAccessGrants");
            try
            {
                #if DESKTOP
                return client.ListAccessGrants(request);
                #elif CORECLR
                return client.ListAccessGrantsAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationArn { get; set; }
            public System.String GranteeIdentifier { get; set; }
            public Amazon.S3Control.GranteeType GranteeType { get; set; }
            public System.String GrantScope { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.S3Control.Permission Permission { get; set; }
            public System.Func<Amazon.S3Control.Model.ListAccessGrantsResponse, GetS3CAccessGrantListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessGrantsList;
        }
        
    }
}
