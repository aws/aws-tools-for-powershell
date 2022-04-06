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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Grants an Amazon Web Services service, account, or organization permission to use
    /// a function. You can apply the policy at the function level, or specify a qualifier
    /// to restrict access to a single version or alias. If you use a qualifier, the invoker
    /// must use the full Amazon Resource Name (ARN) of that version or alias to invoke the
    /// function. Note: Lambda does not support adding policies to version $LATEST.
    /// 
    ///  
    /// <para>
    /// To grant permission to another account, specify the account ID as the <code>Principal</code>.
    /// To grant permission to an organization defined in Organizations, specify the organization
    /// ID as the <code>PrincipalOrgID</code>. For Amazon Web Services services, the principal
    /// is a domain-style identifier defined by the service, like <code>s3.amazonaws.com</code>
    /// or <code>sns.amazonaws.com</code>. For Amazon Web Services services, you can also
    /// specify the ARN of the associated resource as the <code>SourceArn</code>. If you grant
    /// permission to a service principal without specifying the source, other accounts could
    /// potentially configure resources in their account to invoke your Lambda function.
    /// </para><para>
    /// This action adds a statement to a resource-based permissions policy for the function.
    /// For more information about function policies, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/access-control-resource-based.html">Lambda
    /// Function Policies</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Add", "LMPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Lambda AddPermission API operation.", Operation = new[] {"AddPermission"}, SelectReturnType = typeof(Amazon.Lambda.Model.AddPermissionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Lambda.Model.AddPermissionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Lambda.Model.AddPermissionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddLMPermissionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action that the principal can use on the function. For example, <code>lambda:InvokeFunction</code>
        /// or <code>lambda:GetFunction</code>.</para>
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
        public System.String Action { get; set; }
        #endregion
        
        #region Parameter EventSourceToken
        /// <summary>
        /// <para>
        /// <para>For Alexa Smart Home functions, a token that must be supplied by the invoker.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventSourceToken { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.AddPermissionRequest.FunctionName
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
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter FunctionUrlAuthType
        /// <summary>
        /// <para>
        /// <para>The type of authentication that your function URL uses. Set to <code>AWS_IAM</code>
        /// if you want to restrict access to authenticated <code>IAM</code> users only. Set to
        /// <code>NONE</code> if you want to bypass IAM authentication to create a public endpoint.
        /// For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/urls-auth.html">
        /// Security and auth model for Lambda function URLs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.FunctionUrlAuthType")]
        public Amazon.Lambda.FunctionUrlAuthType FunctionUrlAuthType { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services service or account that invokes the function. If you specify
        /// a service, use <code>SourceArn</code> or <code>SourceAccount</code> to limit who can
        /// invoke the function through that service.</para>
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
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter PrincipalOrgID
        /// <summary>
        /// <para>
        /// <para>The identifier for your organization in Organizations. Use this to grant permissions
        /// to all the Amazon Web Services accounts under this organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrincipalOrgID { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>Specify a version or alias to add permissions to a published version of the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>Only update the policy if the revision ID matches the ID that's specified. Use this
        /// option to avoid modifying a policy that has changed since you last read it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter SourceAccount
        /// <summary>
        /// <para>
        /// <para>For Amazon S3, the ID of the account that owns the resource. Use this together with
        /// <code>SourceArn</code> to ensure that the resource is owned by the specified account.
        /// It is possible for an Amazon S3 bucket to be deleted by its owner and recreated by
        /// another account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceAccount { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>For Amazon Web Services services, the ARN of the Amazon Web Services resource that
        /// invokes the function. For example, an Amazon S3 bucket or Amazon SNS topic.</para><para>Note that Lambda configures the comparison using the <code>StringLike</code> operator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter StatementId
        /// <summary>
        /// <para>
        /// <para>A statement identifier that differentiates the statement from others in the same policy.</para>
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
        public System.String StatementId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Statement'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.AddPermissionResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.AddPermissionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Statement";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FunctionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-LMPermission (AddPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.AddPermissionResponse, AddLMPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FunctionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventSourceToken = this.EventSourceToken;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FunctionUrlAuthType = this.FunctionUrlAuthType;
            context.Principal = this.Principal;
            #if MODULAR
            if (this.Principal == null && ParameterWasBound(nameof(this.Principal)))
            {
                WriteWarning("You are passing $null as a value for parameter Principal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalOrgID = this.PrincipalOrgID;
            context.Qualifier = this.Qualifier;
            context.RevisionId = this.RevisionId;
            context.SourceAccount = this.SourceAccount;
            context.SourceArn = this.SourceArn;
            context.StatementId = this.StatementId;
            #if MODULAR
            if (this.StatementId == null && ParameterWasBound(nameof(this.StatementId)))
            {
                WriteWarning("You are passing $null as a value for parameter StatementId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lambda.Model.AddPermissionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.EventSourceToken != null)
            {
                request.EventSourceToken = cmdletContext.EventSourceToken;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.FunctionUrlAuthType != null)
            {
                request.FunctionUrlAuthType = cmdletContext.FunctionUrlAuthType;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            if (cmdletContext.PrincipalOrgID != null)
            {
                request.PrincipalOrgID = cmdletContext.PrincipalOrgID;
            }
            if (cmdletContext.Qualifier != null)
            {
                request.Qualifier = cmdletContext.Qualifier;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
            }
            if (cmdletContext.SourceAccount != null)
            {
                request.SourceAccount = cmdletContext.SourceAccount;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            if (cmdletContext.StatementId != null)
            {
                request.StatementId = cmdletContext.StatementId;
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
        
        private Amazon.Lambda.Model.AddPermissionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.AddPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "AddPermission");
            try
            {
                #if DESKTOP
                return client.AddPermission(request);
                #elif CORECLR
                return client.AddPermissionAsync(request).GetAwaiter().GetResult();
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
            public System.String Action { get; set; }
            public System.String EventSourceToken { get; set; }
            public System.String FunctionName { get; set; }
            public Amazon.Lambda.FunctionUrlAuthType FunctionUrlAuthType { get; set; }
            public System.String Principal { get; set; }
            public System.String PrincipalOrgID { get; set; }
            public System.String Qualifier { get; set; }
            public System.String RevisionId { get; set; }
            public System.String SourceAccount { get; set; }
            public System.String SourceArn { get; set; }
            public System.String StatementId { get; set; }
            public System.Func<Amazon.Lambda.Model.AddPermissionResponse, AddLMPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Statement;
        }
        
    }
}
