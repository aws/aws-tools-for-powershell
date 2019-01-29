/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Grants an AWS service or another account permission to use a function. You can apply
    /// the policy at the function level, or specify a qualifier to restrict access to a single
    /// version or alias. If you use a qualifier, the invoker must use the full Amazon Resource
    /// Name (ARN) of that version or alias to invoke the function.
    /// 
    ///  
    /// <para>
    /// To grant permission to another account, specify the account ID as the <code>Principal</code>.
    /// For AWS services, the principal is a domain-style identifier defined by the service,
    /// like <code>s3.amazonaws.com</code> or <code>sns.amazonaws.com</code>. For AWS services,
    /// you can also specify the ARN or owning account of the associated resource as the <code>SourceArn</code>
    /// or <code>SourceAccount</code>. If you grant permission to a service principal without
    /// specifying the source, other accounts could potentially configure resources in their
    /// account to invoke your Lambda function.
    /// </para><para>
    /// This action adds a statement to a resource-based permission policy for the function.
    /// For more information about function policies, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/access-control-resource-based.html">Lambda
    /// Function Policies</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Add", "LMPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Lambda AddPermission API operation.", Operation = new[] {"AddPermission"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
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
        [System.Management.Automation.Parameter]
        public System.String Action { get; set; }
        #endregion
        
        #region Parameter EventSourceToken
        /// <summary>
        /// <para>
        /// <para>For Alexa Smart Home functions, a token that must be supplied by the invoker.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EventSourceToken { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.AddPermissionRequest.FunctionName
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The AWS service or account that invokes the function. If you specify a service, use
        /// <code>SourceArn</code> or <code>SourceAccount</code> to limit who can invoke the function
        /// through that service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Principal { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>Specify a version or alias to add permissions to a published version of the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>Only update the policy if the revision ID matches the ID specified. Use this option
        /// to avoid modifying a policy that has changed since you last read it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter SourceAccount
        /// <summary>
        /// <para>
        /// <para>For AWS services, the ID of the account that owns the resource. Use instead of <code>SourceArn</code>
        /// to grant permission to resources owned by another account (e.g. all of an account's
        /// Amazon S3 buckets). Or use together with <code>SourceArn</code> to ensure that the
        /// resource is owned by the specified account. For example, an Amazon S3 bucket could
        /// be deleted by its owner and recreated by another account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceAccount { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>For AWS services, the ARN of the AWS resource that invokes the function. For example,
        /// an Amazon S3 bucket or Amazon SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter StatementId
        /// <summary>
        /// <para>
        /// <para>A statement identifier that differentiates the statement from others in the same policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StatementId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-LMPermission (AddPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Action = this.Action;
            context.EventSourceToken = this.EventSourceToken;
            context.FunctionName = this.FunctionName;
            context.Principal = this.Principal;
            context.Qualifier = this.Qualifier;
            context.RevisionId = this.RevisionId;
            context.SourceAccount = this.SourceAccount;
            context.SourceArn = this.SourceArn;
            context.StatementId = this.StatementId;
            
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
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Statement;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AddPermissionAsync(request);
                return task.Result;
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
            public System.String Principal { get; set; }
            public System.String Qualifier { get; set; }
            public System.String RevisionId { get; set; }
            public System.String SourceAccount { get; set; }
            public System.String SourceArn { get; set; }
            public System.String StatementId { get; set; }
        }
        
    }
}
